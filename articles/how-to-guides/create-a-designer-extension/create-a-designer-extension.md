---
uid: how-to-guides.create-a-designer-extension
note: This one will only cover the new element creation. We will need to write one that will form part of 'creating a new designer' that will allow you to define your visuals too.
---
# Create a Designer Extension

If you have worked in Intent Architect's available set of designers such as the Services or the Domain designer, chances are you might have asked yourself the question whether you could change them to some extent.
In this how-to you will learn how to add your own Element to a Domain designer (or any other designer) and be able to reference it in the designer as if it is an actual type and be able to generate content from that new element.

Create a new Module Builder application and give it the name `DomainDesignerExtension`.

![Domain Design Extension Creation](images/design-extension-creation.png)

And select the `Module Builder - C#` option and click on `Create`.

![Domain Design Extension Customize](images/design-extension-customize.png)

Once the installation dialog is complete you can click on `Close`.

![Installation Dialog](images/installation-dialog.png)

Click on the `Module Builder` designer and create a package with the name `MyDomainExtension`.

After that, go ahead and install the metadata for the Domain designer.

<p><video style="max-width: 100%" muted="true" loop="true" autoplay="true" src="videos/install-domain-module-metadata.mp4"></video></p>

Return to the `Module Builder` designer and setup the following:

Reference the Domain designer in the `MyDomainExtension` package.
This will make our elements bundled with the `MyDomainExtension` package and targeting the `Domain` designer.

<p><video style="max-width: 100%" muted="true" loop="true" autoplay="true" src="videos/design-setup-designer-reference.mp4"></video></p>

Create our `Domain Event` Element with its `Property` Element so that we have something to install in the `Domain` designer.

<p><video style="max-width: 100%" muted="true" loop="true" autoplay="true" src="videos/design-setup-element.mp4"></video></p>

Create the Package extension and Folder extension elements which will allow us to setup the Creation of our `Domain Event` element within Packages and Folders inside the `Domain` designer.

<p><video style="max-width: 100%" muted="true" loop="true" autoplay="true" src="videos/design-setup-element-creation.mp4"></video></p>

Lastly, let's setup a Stereotype that will allow us to reference our newly created `Domain Event` within a `Class` element.

<p><video style="max-width: 100%" muted="true" loop="true" autoplay="true" src="videos/design-setup-stereotype.mp4"></video></p>

Run the Software Factory to apply the following changes in staging

![Staging files](images/software-factory-run.png)

You can click on `Apply` and once that is done continue to build the solution in Visual Studio.

![Visual Studio Build](images/visual-studio-build.png)

# Test your Designer Extension Module

Open up the [Repository Manager](xref:how-to-guides.manage-repositories) to point to your newly created Module folder.

![Manage Repositories](images/repo-manager-module-folder.png)

Add your Repository to the list as shown in the image above. Let it point to your folder where your compiled Module is located.

Open or create the Intent Architect application where you want to install your newly created Module.
Click on the Modules option on the panel to the left.
Select your repository from the drop-down on the right and locate your Module to install.

![Install Module](images/test-module-install.png)

Now you can see your new Designer extension in action

<p><video style="max-width: 100%" muted="true" loop="true" autoplay="true" src="videos/test-module-domain.mp4"></video></p>