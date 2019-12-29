using System.Collections.Generic;
using Intent.Engine;
using Intent.Modelers.Services.Api;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;


[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.RoslynProjectItemTemplate.Partial", Version = "1.0")]

namespace MyCompany.MyModule.Templates.ControllerTemplate
{
    [IntentManaged(Mode.Merge)]
    partial class ControllerTemplate : IntentRoslynProjectItemTemplateBase<IServiceModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "MyModule.Templates.ControllerTemplate";

        public ControllerTemplate(IProject project, IServiceModel model) : base(TemplateId, project, model)
        {
            AddTypeSource(templateId: ControllerTemplate.TemplateId, collectionFormat: "IEnumerable<{0}>");
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
                fileName: "${Model.Name}",
                fileExtension: "cs",
                defaultLocationInProject: "Controllers",
                className: "${Model.Name}",
                @namespace: "${Project.Name}.Controllers"
            );
        }


    }
}