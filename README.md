# PC Build Advisor

*A rule-based expert system that recommends a PC build from your use-case and budget.*

![.NET 10](https://img.shields.io/badge/.NET%2010-512BD4?logo=dotnet&logoColor=white)
![Razor Pages](https://img.shields.io/badge/ASP.NET%20Core-Razor%20Pages-512BD4?logo=dotnet&logoColor=white)
![Expert System](https://img.shields.io/badge/AI-Expert%20System-1f6feb)

Pick what you'll use the PC for and how much you want to spend, and the advisor returns a complete,
sensible component list — CPU, GPU, RAM, storage, motherboard, and PSU — with an estimated price.
It's a small **expert system**: instead of hard-coded `if` statements, recommendations come from a
**forward-chaining inference engine** running over an editable knowledge base of rules.

## How it works

The engine implements classic forward chaining:

1. Your choices become **facts** — e.g. `scop_gaming` + `buget_mediu`.
2. The engine scans the **rules** (`IF premises THEN configuration`) and fires the first rule whose
   premises are all satisfied.
3. The rule's conclusion maps to a full **configuration**, which is rendered back to you.

All domain knowledge lives in [`Data/kb.json`](Data/kb.json) — separate from the code — so you can
add use-cases, budget tiers, rules, and builds without recompiling. The current knowledge base
covers **5 use-cases × 3 budget tiers = 15 builds**:

- **Use-cases:** gaming, office, video editing, programming, school
- **Budgets:** low, medium, high

> The domain vocabulary is in Romanian — `scop` = use-case, `buget` = budget, `reguli` = rules,
> `configuratii` = configurations.

## Tech stack

- **ASP.NET Core Razor Pages (.NET 10)**
- **JSON knowledge base** deserialised into a typed model (`KnowledgeBase`, `Rule`, `PcConfig`)
- Inference logic isolated in [`Services/BuildAdvisor.cs`](Services/BuildAdvisor.cs)

## Getting started

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Run

```bash
dotnet run
```

Then open the URL shown in the console, choose a use-case and a budget, and request a recommendation.

## Extending the knowledge base

Edit `Data/kb.json` to teach the advisor new builds:

- add a premise to `premise_posibile`,
- add a rule to `reguli` (`daca` = the required facts, `atunci` = the configuration key),
- add the matching entry to `configuratii`.

No code changes required — the engine picks it up on the next run.

## Project structure

```
├── Data/kb.json          # Knowledge base: premises, rules, configurations
├── Models/PcConfig.cs    # Typed model of the knowledge base
├── Services/BuildAdvisor.cs  # Forward-chaining inference engine
├── Pages/                # Razor Pages UI
└── Program.cs
```
