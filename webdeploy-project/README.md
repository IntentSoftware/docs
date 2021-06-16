# Intent Architect Documentation publishing solution

This is a Visual Studio Solution which is configured with Web Deploy to be able to publish the docs.

## Pre-requisites

### `Docs` virtual application configured for the Azure web application

To isolate Web Deploys of the docs and the main website, the `/docs` directory is configured as a virtual directory. Also, so that it can have its own `Web.config` file and a server side redirect, the virtual directory is configured as an application too.

To configure this in the Azure Portal:

- Go to the resource of the `App Service` for the main website.
- Go to `Configuration`.
- Go to the `Path mappings` tab.
- Under `Virtual applications and directories`, press `New virtual application or directory` and enter the following details:
  - `Virtual path`: `/docs`
  - `Physical path`: `site\docs`
  - `Directory`: ⬛
  - `Preload enabled`: ✅

## Deploying

Azure Pipelines is configured to deploy these docs every time there is a merge into `master`.

## Additional notes

### Web.config file

Application Insights only there to avoid errors which occur otherwise, some sort of interplay with the main website at the root directory.

### `Properties\*.pubxml` files

Appends `\docs` to the `<DeployIisAppPath />` which allows full sync over Web Deploy and `<SkipExtraFilesOnServer>False</SkipExtraFilesOnServer>` deletes extra files on the server which aren't present locally, but within the docs folder only.

Has the following XML added which includes the DocFX files:

```xml
<Target Name="DocsCollectFiles">
  <ItemGroup>
    <_DocFiles Include="..\..\_site\**\*" />
    <FilesForPackagingFromProject Include="%(_DocFiles.Identity)">
      <DestinationRelativePath>%(RecursiveDir)%(Filename)%(Extension)</DestinationRelativePath>
    </FilesForPackagingFromProject>
  </ItemGroup>
</Target>
<PropertyGroup>
  <CopyAllFilesToSingleFolderForPackageDependsOn>DocsCollectFiles;</CopyAllFilesToSingleFolderForPackageDependsOn>
  <CopyAllFilesToSingleFolderForMsdeployDependsOn>DocsCollectFiles;</CopyAllFilesToSingleFolderForMsdeployDependsOn>
</PropertyGroup>
```
