# Why Intent Architect

## The problem with building software

When interviewing developers, we often ask the following questions:

_Have you ever worked on a greenfields project that over time became a [big ball of mud](https://en.wikipedia.org/wiki/Big_ball_of_mud)?_

And then the really interesting question... _Have you ever worked on a greenfields project that __didn't__ become a big ball of mud?_

Most developers acknowledge that almost every system they've ever worked on has become a spaghetti-code jungle, while all developer agree that this is the fate of most software systems. The only systems that escape this fate are either too small to have become unwieldy, are a rewrite (_of the last rewrite_) by the same team, or have a significant amount of code-automation. 

The unfortunate truth is that the vast majority of software systems tend to become increasingly unwieldy, and the cost of maintaining and extending these system continues to rise exponentially.

![Cost vs. Size](../../images/intro/graph_cost_vs_size.png)

So often you will see software systems in successful businesses, with sometimes hundreds of developers, that are barely able to make any significant changes to them. They have become so fragile and difficult to reason about that no matter how much manpower is assigned, the results are the same.

**_The cost to change a software system grows exponentially as the system grows in size and complexity._**

The implications of this on project outcome is dire, especially as the project size increases. The following table, published in the [Standish Group](https://www.standishgroup.com/) CHAOS report of 2015 shows the significant drop in project success for any project considered Moderate in size or bigger.

![Project Size by CHAOS Resolution](../../images/intro/project_size_by_chaos_resolution.png)

This problem is as old as the software industry, and while significant improvements in technologies, methodologies and tooling have helped, the problem persists because the software systems we are building have become so much more complex.

## What about Agile?

Agile methodologies have significantly improved the success rate of projects over the (now outdated) waterfall approach. Agile also claims to flatten the cost of change curve, which is true but not to the extent that agile evangelists would have us believe. The fundamental problem that agile tackles is that of building the wrong thing. By shortening the feedback cycle, validation and correction of the software can be done sooner, thus saving massive reworking costs down the line. In essence, agile helps prevent the need to make significant changes down the line.

The reality, however, is that the growing cost of making changes hasn't been alleviated, but rather that the need to make these changes has largely been _avoided_. The cost of change curve can't be flattened by a methodology, since the causes are primarily of a technical nature.

## The technical causes

We believe there are three fundamental reasons why software tends to become unwieldy. These are discussed below.

### 1. Cost of architecture

The obvious cause of a system become unwieldy is that it lacks an appropriate architecture to support it's growth in the first place. Without patterns to keep coupling low, cohesion high, and the separation of concerns, the spaghetti-code jungle gets thick very quickly. 

Putting these architectural patterns in place is costly and slows the team down in the short term, but as the system grows, they help ensure that the team can maintain a decent velocity.

![Team Velocity vs. Size](../../images/intro/graph_team_velocity_architecture.png)

The implications of ignoring architecture often lead to a completely unmanageable codebase, in addition to often being unable to meet the non-functional requirements (e.g. performance, scalability, etc.). These are the dreaded systems that developers loath, keeping a vomit-bucket nearby as they attempt to reason about its inner workings.

Reaching a point of near-zero velocity is a real phenomenon, and occurs when making any significant change breaks another part of the system, which when changed breaks yet another part of the system, and so on. The web of changes eventually becomes too complex and risky, and the developer has no choice but to roll back. This is unfortunately the state of most large (_legacy_) systems.

### 2. Software entropy

_"As a system is modified, its disorder, or entropy, tends to increase. This is known as software entropy."_ ~ [Software entropy, Wikipedia](https://en.wikipedia.org/wiki/Software_entropy)

Disorder in a system is a form of [technical debt](https://en.wikipedia.org/wiki/Technical_debt) which creeps in as a system is modified. It's the most insidious form of technical debt which over time leads to the big ball of mud. As developers, we try avoid it but the cost of correcting software entropy becomes unaffordable as the system becomes larger. Needing another week or month to refactor the code is a luxury most developers (and businesses) don't have.

Software entropy can take many different forms, from different coding styles to different architectures scattered throughout the application. All successful software gets changed, and so all successful software is subject to entropy.

### 3. Architectural rigidity

Code that _enables_ the functions of a system to be performed is surprisingly pervasive in any system. This is the code that handles service requests, sets transactional boundaries, manages persistance of the application's state, enforces security, etc. While a modern technology exists to handle any of these concerns, the code required to wire this up still makes up the vast majority of code in any system. By some definitions, this is the applications architecture - _the glue of the system_.

As systems get larger, growing in features and functions, so this architectural code is "replicated" as patterns that are unique enough to prevent developers from consolidating them. When a pattern needs to be changed (e.g. to change or upgrade a technology, fix a vulnerability, implement a cross-cutting concern, etc.), each instance of that pattern must be changed. In a large system, this could mean months of rework. Thus developers find themselves constrained by architectural rigidity, and are often forced to compromise leading to entropy and technical debt. 




