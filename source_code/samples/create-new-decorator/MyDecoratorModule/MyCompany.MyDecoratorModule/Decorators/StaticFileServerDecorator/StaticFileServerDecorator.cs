using System;
using System.Collections.Generic;
using Intent.Engine;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.DecoratorTemplate", Version = "1.0")]

namespace MyCompany.MyDecoratorModule.Decorators.StaticFileServerDecorator
{
    [IntentManaged(Mode.Merge, Body = Mode.Merge, Signature = Mode.Fully)]
    public class StaticFileServerDecorator : MyCompany.MyModule.Templates.StartupTemplate.IStartupTemplateContract
    {
        public const string Identifier = "MyDecoratorModule.StaticFileServerDecorator";

        private readonly IApplication _application;

        public StaticFileServerDecorator(IApplication application)
        {
            _application = application;
        }

        public int Priority => 1;

        public string ConfigureCode()
        {
            return @"app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), ""MyStaticFiles"")),
        RequestPath = ""/StaticFiles""
    });";
        }
    }
}