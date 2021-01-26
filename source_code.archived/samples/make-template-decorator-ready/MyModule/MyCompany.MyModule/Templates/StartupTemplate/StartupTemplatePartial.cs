using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intent.Engine;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;



[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.RoslynProjectItemTemplate.Partial", Version = "1.0")]

namespace MyCompany.MyModule.Templates.StartupTemplate
{
    [IntentManaged(Mode.Merge)]
    partial class StartupTemplate : IntentRoslynProjectItemTemplateBase<object>, IHasDecorators<MyCompany.MyModule.Templates.StartupTemplate.IStartupTemplateContract>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "MyModule.Templates.StartupTemplate";

        public StartupTemplate(IProject project, object model) : base(TemplateId, project, model)
        {
        }

        public override RoslynMergeConfig ConfigureRoslynMerger()
        {
            return new RoslynMergeConfig(new TemplateMetadata(Id, "1.0"));
        }

        [IntentManaged(Mode.Merge, Body = Mode.Ignore, Signature = Mode.Fully)]
        protected override RoslynDefaultFileMetadata DefineRoslynDefaultFileMetadata()
        {
            return new RoslynDefaultFileMetadata(
                overwriteBehaviour: OverwriteBehaviour.Always,
                fileName: "Startup",
                fileExtension: "cs",
                defaultLocationInProject: "",
                className: "Startup",
                @namespace: "${Project.Name}"
            );
        }

        private ICollection<MyCompany.MyModule.Templates.StartupTemplate.IStartupTemplateContract> _decorators = new List<MyCompany.MyModule.Templates.StartupTemplate.IStartupTemplateContract>();

        [IntentManaged(Mode.Fully)]
        public void AddDecorator(MyCompany.MyModule.Templates.StartupTemplate.IStartupTemplateContract decorator)
        {
            _decorators.Add(decorator);
        }

        [IntentManaged(Mode.Fully)]
        public IEnumerable<MyCompany.MyModule.Templates.StartupTemplate.IStartupTemplateContract> GetDecorators()
        {
            return _decorators;
        }

        #region GetConfigureCode
        private string GetConfigureCode()
        {
            return GetDecorators()
                .OrderBy(o => o.Priority)
                .Aggregate(new StringBuilder(), (sb, dec) => sb.AppendLine(dec.ConfigureCode())).ToString();
        }
        #endregion
    }
}