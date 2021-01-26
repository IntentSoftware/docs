using System;
using Intent.Engine;
using Intent.Modules.Common.Registrations;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.DecoratorRegistration.Template", Version = "1.0")]

namespace MyCompany.MyDecoratorModule.Decorators.StaticFileServerDecorator
{
    [IntentManaged(Mode.Merge, Body = Mode.Merge, Signature = Mode.Fully)]
    public class StaticFileServerDecoratorRegistration : DecoratorRegistration<MyCompany.MyModule.Templates.StartupTemplate.IStartupTemplateContract>
    {
        public override string DecoratorId => MyCompany.MyDecoratorModule.Decorators.StaticFileServerDecorator.StaticFileServerDecorator.Identifier;

        public override MyCompany.MyModule.Templates.StartupTemplate.IStartupTemplateContract CreateDecoratorInstance(IApplication application)
        {
            return new MyCompany.MyDecoratorModule.Decorators.StaticFileServerDecorator.StaticFileServerDecorator(application);
        }
    }
}