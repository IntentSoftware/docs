using Intent.Templates;
using System;

namespace MyCompany.MyModule.Templates.StartupTemplate
{
    public interface IStartupTemplateContract : ITemplateDecorator
    {
        string ConfigureCode();
    }
}
