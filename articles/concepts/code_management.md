# Code Management

## Traditional source-code generation

Most source-code generation systems provide a once-off generation experience. The benefit of this is the productivity boost that developers achieve. The code, once generated, is then customized and managed by the developer.

Another form of source-code generation is continuous and overwrites the generated code on each run. Productivity is also a major benefit but with the added advantage that the code remains _managed_ by the generation mechanism (usually some kind of template). This means that the developer can manage and upgrade the pattern, instead of each instance of it's implementation (of which there could be hundreds). This offers great refactoring power but comes with a critical disadvantage. 

The disadvantage of this is that any particular instance of the pattern cannot be customized, and for many developers this is a deal breaker. The generated pattern may be perfect for 95% of the cases but 5% of the time it needs customization and the inability to do this easily is often enough to negate the positive upside.