---
uid: references.code-management.csharp-code-management
---
# C# Code Management

## Disabling auto-formatting

By default the Software Factory will automatically format files under code management. If this is undesired you can disable this behaviour by setting the the `AutoFormat` property to `false` in the `DefineFileConfig` method of your template:

```csharp
protected override CSharpFileConfig DefineFileConfig()
{
    return new CSharpFileConfig(
        className: "MyClass",
        @namespace: OutputTarget.GetNamespace())
    {
        AutoFormat = false
    };
}
```
