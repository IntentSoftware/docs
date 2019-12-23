# Modules Overview
Modules are the building blocks and extension points of Intent Architect. They typically encapsulate _how_ your metadata should be realized as code in your application. While the outputs of each Module are not restricted to a particular language, creating the Modules must be done using C# and .NET (a modern and powerful strongly typed language).

## Creating Modules
We have a tutorial that explains how to create new Modules [here](../../tutorials/create_your_own_module.md).

## Module Components
Every Module requires an **[imodspec file](imodspec_file.md)** to describe it and what components it contains.
- **[Templates](../templates/overview.md)** - Templates are the artifacts which are responsible for generating code.
- **[Decorators](decorators.md)** - Decorators effectively extend the output of templates that support them. This is very useful when writing templates that are going to be used across projects and need to be extensible and flexible.
- **[Factory Extensions](factory_extensions.md)** - Extend the software factory by hooking into the execution life-cycle, template life-cycle, or output transformations. Can be used to alter output from templates, change metadata, run installers, or anything really.
- **[Metadata](imodspec_file.md)** - Install predefined metadata into your application on installing of the Module. This is very useful when you have predefined Stereotypes or Types that your templates depend upon.

## Packaging
To package a Module from a `csproj` (C# Project) into a Module that is able to be installed into an Intent Architect application, a packager is required. This is provided as a NuGet package `Intent.IntentArchitectPackager`, which can be installed by running the following:

```
Install-Package Intent.IntentArchitectPackager
```

On successful compiling of the project, the Module will be packaged into a folder at `%SolutionFolder%\Intent.Modules`. By creating a repository at this folder from within Intent Architect's Modules manager, you can install this module into your application.