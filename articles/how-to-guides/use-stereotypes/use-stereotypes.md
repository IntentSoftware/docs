# Use Stereotypes

Extending meta-data in Intent Architect is commonly achieved through Stereotypes. This guide will describe how to create one and how to use it inside a template in order to affect how the source code gets generated.

If you have followed through the [Create Module](xref:guide/creating-modules-net/create-a-simple-module) tutorial, it will be useful to note that we will be extending the Template in order to add a C# attribute `[Serializeable]` depending on whether the `Serializeable` stereotype is applied to an Element or not.

## Creating a Stereotype Definition

In Intent Architect, open the Module solution (as was created in the tutorial) and select the Project that represents the Module that will generate the code for a C# Entity.

Inside Module Builder designer you will need to create a Stereotype Definition first before it can be applied. Right click on any of the Tree view folders (found on the right-hand-side panel) and select `New Stereotype-Definition`.

>[!NOTE]
>You may find that you need to include the package where this new Stereotype Definition was created in to be included with the current Module. In order to do that, click on the Package itself and set the Properties:
>
> * Include in Module: _Checked_
> * Reference in Designer: `Module Builder`

Supply the following in the Stereotype Definition:

 * Name: Serializable
 * Target Mode: Elements that reference
 * Targets: EntityBase
 * Apply mode: Always

Now we want to add a Property to this Stereotype Definition. Right click on this Stereotype Definition and select `Add Property`.

Supply the following Property values for this Stereotype Property:

 * Name: Enabled
 * Control Type: Checkbox
 * Default value: _Unchecked_

