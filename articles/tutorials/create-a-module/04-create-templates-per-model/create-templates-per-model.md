---
uid: tutorials.creating-modules-net.create-templates-per-model
---
# Create Templates per Model
In this next tutorial we will extend our `MyModules.Entities` Module to create and manage domain entities based off the `Domain` designer.


## Install the `Domain` Designer
To create a new class for each entity we design in the `Domain`, we must install the Designer into our Module Builder.

1. Open the `MyModules.Entities` Application.
2. Navigate to the `Modules` tab.
3. Select the Intent Architect website repository https://intentarchitect.com.
4. Search for the `Intent.Modelers.Domain` Module.
5. In the Module details pane, expand the `Options` and check the `Install Metadata only` checkbox.
    >[!NOTE]
    >By selecting the `Install Metadata only` option, Intent Architect will not install the Designer or run the Module during a Software Factory Execution. This feature is typically used in the Module Builder.

6. Click `Install` to install the Module.

<p><video style="max-width: 100%" muted="true" loop="true" autoplay="true" src="videos/modules-install-domain-metadata-only.mp4"></video></p>


## Create a new Template
Next, we will create a new Template that we can configure to receive the models from the `Domain` Designer and create a new C# class for each entity.

1. Navigate to the `Module Builder` Designer
2. Create a new Template, call it `Entity` and set it's type to be `File per Model`.
3. In the properties, under `Template Settings`, set it's `Designer` to `Domain` and Model Type to `Class`.
    >[!NOTE]
    >These options are available because we installed the `Intent.Modelers.Domain` Module's metadata in the previous step.
4. Save you changes.
5. Rerun the Software Factory Execution.
6. Click `APPLY CHANGES`.

<p><video style="max-width: 100%" muted="true" loop="true" autoplay="true" src="videos/module-builder-create-entity-template.mp4"></video></p>

>[!WARNING]
>It is always recommended to inspect the changes that Intent Architect wants to make to your codebase _before_ applying the changes.

## Implement Template Logic
Next, we will implement the logic of the `Entity` Template, essentially _templatizing_ our entities pattern. In this tutorial we will create `public` properties for each _attribute_ and _association_ that we describe in the `Domain` Designer.

1. Open the `MyModule.Entities` code solution in your IDE (e.g. Visual Studio).
2. Open the `EntityTemplate.tt` file.
3. Implement the following logic:

## Reinstall and test Module
