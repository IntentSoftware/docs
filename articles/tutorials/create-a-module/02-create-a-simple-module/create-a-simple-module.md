---
uid: tutorials.create-a-module.create-a-simple-module
---
# Create a simple module

## Create a new application

On the home screen click `Create a new module`.

Fill in a `Name` and review/change the `Location` as desired, then click `NEXT`.

Ensure the following components are selected:
- `Module Builder Core`
- `Module Builder - C#`
- `Visual Studio Integration`

Click `CREATE`.

An `Application Installation` dialogue will pop up showing the progress of downloading and installing modules and metadata for the application, once it's finished it will show `Process complete.` and you can click the `CLOSE` button:

<p><video style="max-width: 100%" muted="true" loop="true" autoplay="true" src="videos/create-a-new-module.mp4"></video></p>


## Create a package

Click on `Module Builder` on the left of the screen to enter the designer.

Click `CREATE NEW PACKAGE`.

Enter a name for the [Package](xref:references.packages) (such as `MyModules.Entities`) and click `DONE`.

<p><video style="max-width: 100%" muted="true" loop="true" autoplay="true" src="videos/create-the-package.mp4"></video></p>

## Create a template

Right-click the package and click the `New C# Template` option:

Name it `EntityBase` and select a type of `Single File`:

<p><video style="max-width: 100%" muted="true" loop="true" autoplay="true" src="videos/create-the-template.mp4"></video></p>

## Run the software factory

We are now ready to run the software factory. Press the play button near the top right of the screen and the run will start.

> [!NOTE]
> If your changes are unsaved you will be asked if you want to save them before proceeding.

Once the software has run the templates it pauses to give you an opportunity to review the proposed changes, once you are satisfied doing so you can press the `APPLY CHANGES` button to continue. Once the remainder of the software factory run is complete, press the `CLOSE` button.

<p><video style="max-width: 100%" muted="true" loop="true" autoplay="true" src="videos/run-the-software-factory.mp4"></video></p>

## Edit the template in Visual Studio

During the software factory run, Intent Architect generated a complete Visual Studio solution along with the `EntityBase` template which was added the [create a template](#create-a-template) step above.

Navigate to the folder where the `.sln` and associated files have been placed and open the `.sln` file Visual Studio solution.

> [!TIP]
> Intent Architect can open the folder the output was placed by you going to the Application `Settings` and pressing the path under the `Relative Output Location` input:
> 
> ![Open the output path folder](images/open-the-output-path-folder.png)

Go to the `MyModules` Project and expand the `Templates` folder and then the  `EntityBase` folder.

Open the `EntityBaseTemplate.tt` file and update its content to the following:

```csharp
<#@ template language="C#" inherits="CSharpTemplateBase<object>" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Collections.Generic" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="Intent.Modules.Common" #>
<#@ import namespace="Intent.Modules.Common.Templates" #>
<#@ import namespace="Intent.Modules.Common.CSharp.Templates" #>
<#@ import namespace="Intent.Templates" #>
<#@ import namespace="Intent.Metadata.Models" #>
using System;

[assembly: DefaultIntentManaged(Mode.Fully)]

namespace <#= Namespace #>
{
    public abstract class <#= ClassName #>
    {
        public DateTime CreatedDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }
    }
}
```

Save your changes and build the project.

<p><video style="max-width: 100%" muted="true" loop="true" autoplay="true" src="videos/edit-template-and-build-in-visual-studio.mp4"></video></p>

Once the build has been completed you will notice that the `Build` log includes the following line:
`Successfully created package C:\Dev\MyModules\Intent.Modules\MyModules.Entities.1.0.0.imod`

This was output by the Intent Packager and lets you know where it has placed the built Module.

## Summary

Congratulations, you have created an Intent Architect Module!

## Next Steps

[Install and run the module](xref:tutorials.create-a-module.install-and-run-the-module)
