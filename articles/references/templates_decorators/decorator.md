---
uid: Decorator
---
# Decorator

Let's dive into the problem before we look to what a Decorator is. Imagine you are creating a Template that would generate a C# file called `Startup.cs`. For those who are familiar with this file will know that all your startup configuration is made in that file for an ASP.NET WebAPI project. This would allow a developer to specify that OAuth should be configured and that there be a Logging framework configured, Swagger documentation, etc. The problem is that in order to make it possible to have those components configured, it would require that I make them manually in that Template file. And so if I wanted to change a Logging framework or some of the config for OAuth, I would either have to change the Template or add Intent Managed tags to manually take over the configuration of my application. Those are workarounds but they are not sustainable workarounds.

So the way that Intent Architect solves this concern is with the help of Decorators.
If you ever heard of the [Decorator Pattern](https://sourcemaking.com/design_patterns/decorator), then this section will become more clear as we progress, though we will try and explain it in as simple terms as possible for everyone to understand.

Before we can worry about a Decorator, you would need a Template that would advertise to the entire solution "Hey, I am customizable!". But to do that you need to give some sort of "blueprint" (or "contract" for the enterprise developers) that would explain how the template can be customized and how a decorator can customize that template. This follows the Open for Extension, closed for Modification; and Interface Segregation principles (from [SOLID](https://stackify.com/solid-design-principles/)) which allows any developer to extend any Template as long as it meets the Template's expectations.

So Intent Architect has a `Intent.AspNet.Owin` Module that you can install that will allow the `Startup.cs` file to be generated.
If you look at the Template code [here](https://github.com/IntentSoftware/IntentArchitect/blob/release/2.0.0/Modules/Intent.Modules.AspNet.Owin/Templates/OwinStartup/OwinStartupTemplatePartial.cs), you will see that it contains `IHasDecorators<IOwinStartupDecorator>` as an implementable interface.
> [!NOTE]
> Pay special care to the FQDN (Fully Qualified Domain Name) of the interface/class that you are referencing (for Module Builder purposes)

This [interface](https://github.com/IntentSoftware/IntentArchitect/blob/release/2.0.0/Modules/Intent.Modules.AspNet.Owin/Templates/OwinStartup/IOwinStartupDecorator.cs) is the "blueprint" of how you can change the `Startup.cs` file without changing the code.

Notice that it contains two methods that need to be implemented:
```csharp
public interface IOwinStartupDecorator : ITemplateDecorator, IDeclareUsings
{
    IEnumerable<string> Configuration();
    IEnumerable<string> Methods();
}
```

If we look at how its implemented on the [Template side](https://github.com/IntentSoftware/IntentArchitect/blob/release/2.0.0/Modules/Intent.Modules.AspNet.Owin/Templates/OwinStartup/OwinStartupTemplate.tt) you'll notice two areas where substitution will take place in this Text Transform file (T4):
```csharp
[IntentManaged(Mode.Merge)]
public partial class Startup
{
    public void Configuration(IAppBuilder app)
    {<#= Configuration() #>
        CustomConfiguration(app);
    }

    [IntentManaged(Mode.Ignore)]
    public void CustomConfiguration(IAppBuilder app)
    {
        // Put your own custom configuration here
    }<#= Methods() #>
}
```

The underlying [code](https://github.com/IntentSoftware/IntentArchitect/blob/release/2.0.0/Modules/Intent.Modules.AspNet.Owin/Templates/OwinStartup/OwinStartupTemplatePartial.cs) shows how it implements this interface for a decorator to use.

- As mentioned, you need to have an interface specified with a "blueprint": `IHasDecorators<IOwinStartupDecorator>`.

```csharp
partial class OwinStartupTemplate : IntentRoslynProjectItemTemplateBase, IHasDecorators<IOwinStartupDecorator>,...
```

- Ensure that you can receive all the available Decorators by implementing that interface in your Template's backend code file. This will mean that `AddDecorator` and `GetDecorators` be implemented. This is typically accomplished by having an underlying list field receiving and returning all the Decorators that the template is made aware of.

```csharp
public void AddDecorator(IOwinStartupDecorator decorator)
{
    _decorators.Add(decorator);
}

public IEnumerable<IOwinStartupDecorator> GetDecorators()
{
    return _decorators;
}
```

- Leveraging the `GetDecorators()` method in order to accumulate the output of all registered Decorators. See [this](https://github.com/IntentSoftware/IntentArchitect/blob/be3a6a58fc15058d68c57c3e8657a3f28841d35a/Modules/Intent.Modules.AspNet.Owin/Templates/OwinStartup/OwinStartupTemplatePartial.cs#L70) and [this](https://github.com/IntentSoftware/IntentArchitect/blob/be3a6a58fc15058d68c57c3e8657a3f28841d35a/Modules/Intent.Modules.AspNet.Owin/Templates/OwinStartup/OwinStartupTemplatePartial.cs#L95).

Now we can look at how the Decorator looks like. There is another Intent Architect module called `Intent.AspNet.Owin.Jwt` that deals with `OAuth configuration`. Notice that just be installing a separate module, you now have OAuth capabilities in your codebase.

Looking at the [decorator class](https://github.com/IntentSoftware/IntentArchitect/blob/release/2.0.0/Modules/Intent.Modules.AspNet.Owin.Jwt/Decorators/JwtAuthOwinStartupDecorator.cs) you will see that our "blueprint" interface is being implemented directly here to return actual C# code.
Once the Decorator is registered and installed, it will inject code into the two areas that the Template has exposed.

Here is a simple example of the final output when a Template along with all its Decorators have been applied:
```csharp
//...

public void Configuration(IAppBuilder app)
{
    ConfigureAuth(app);
    CustomConfiguration(app);
}

[IntentManaged(Mode.Ignore)]
public void CustomConfiguration(IAppBuilder app)
{
    // Put your own custom configuration here
    
}

public void ConfigureAuth(IAppBuilder app)
{
    JwtSecurityTokenHandler.InboundClaimTypeMap.Clear();
    // Fetches the IssuerName and SigningCertificate on startup from the Authority address
    //app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
    //{
    //    Authority = ""https://localhost:44300/identity"",
    //    ValidationMode = ValidationMode.ValidationEndpoint,
    //    RequiredScopes = new[] { ""api"" },
    //});
    // Uses specified IssuerName and SigningCertificate, does not require the identity server to be online during startup
    app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
    {
        Authority = ConfigurationManager.AppSettings[""IdentityServer.Issuer.Authority""],
        IssuerName = ConfigurationManager.AppSettings[""IdentityServer.Issuer.Name""],
        SigningCertificate = SigningCertificate.GetFromX509Store(
            findType: ConfigurationManager.AppSettings[""IdentityServer.Issuer.SigningCertificate.FindType""],
            findValue: ConfigurationManager.AppSettings[""IdentityServer.Issuer.SigningCertificate.FindValue""]),
        ValidationMode = ValidationMode.Local,
        RequiredScopes = new[] { ""api"" },
    });
}

//...
```

Follow our how-to article that explains how to make your [template decorator ready](xref:MakeTemplateExtensibleThroughDecorators) and how to [create a decorator](xref:CreateNewDecorator) for it.