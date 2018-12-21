# The case for Intent Architect

## The problem with Software Engineering

When interviewing developers, we often ask the following questions:

**_Have you ever worked on a greenfields project that over time became a [big ball of mud](https://en.wikipedia.org/wiki/Big_ball_of_mud)?_**

And then the really interesting question... 

**_Have you ever worked on a greenfields project that __didn't__ become a big ball of mud?_**

Don't worry, you're not alone. The only software systems that escape this fate are either too small to have become unwieldy, are a rewrite (_of the last rewrite_) by the same team, or have a significant amount of code-automation. The unfortunate truth is that the vast majority of software systems tend to become increasingly unwieldy, and the costs to businesses are exponential, and even debilitating.

![Cost vs. Size](../../images/intro/graph_cost_vs_size.png)

So often you will see software systems in large corporations, with hundreds of developers, that are barely able to make any significant changes to these system. They have become so fragile and difficult to reason about that no matter how much manpower is assigned, the results are the same.

**_The cost to change a software system grows exponentially as the system grows in size and complexity._**

This problem is as old as the software industry, and while significant improvements in technologies, methodologies and tooling have helped to some degree, the problem is pervasive. 

The million dollar questions is **_why?_**

## Why?

We believe there are three main causes for software

### 1. Lack of appropriate architecture
The obvious cause of a system become unwieldy is that it lacks an appropriate architecture to support it's growth in the first place. Without patterns to keep coupling low, cohesion high, and the separation of concerns, the spaghetti-code jungle gets thick very quickly. 

Putting these architectural patterns in place is costly and slows the team down in the short term, but as the system grows, they help ensure that the team can maintain a decent velocity.

![Cost vs. Size](../../images/intro/graph_team_velocity_architecture.png)

Besides not meeting the non-functional requirements (e.g. performance, scalability, etc.), the implications of ignoring architecture often lead to a completely unmanageable codebase. These are the dreaded systems that developers loath, keeping a vomit-bucket nearby as they attempt to reason about its inner workings. 

Reaching a point of near-zero velocity is when making any change breaks another part of the system, which when changed breaks yet another part of the system, and so on. The web of changes eventually becomes too complex and risky, and the developer has no choice but to roll the change back.

### 2. Software Entropy

_"As a system is modified, its disorder, or entropy, tends to increase. This is known as software entropy."_ ~ [Software entropy, Wikipedia](https://en.wikipedia.org/wiki/Software_entropy)

Disorder in a system is a form of [technical debt](https://en.wikipedia.org/wiki/Technical_debt) which creeps in as a system is modified. It's the most insidious form of technical debt which over time leads to the big ball of mud. As developers, we try avoid it but the cost of correcting software entropy becomes unaffordable as the system becomes larger. Needing another week or month to refactor the code is a luxury most developers (and businesses) don't have.

Software entropy can take many different forms, from different coding styles to different architectures scattered throughout the application. All successful software gets changed, and so all successful software is subject to entropy. 

### 3. Architectural Rigidity





