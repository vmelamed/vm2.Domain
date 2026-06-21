# vm2.Domain — Claude Context

@~/.claude/CLAUDE.md
@~/repos/vm2/CLAUDE.md
@.github/CONVENTIONS.md

## Package Identity

- Repo: <https://github.com/vmelamed/vm2.Domain>
- NuGet: <https://www.nuget.org/packages/vm2.Domain/>
- Status: *TODO* — in design / Unpublished / Published, stable
- Target: .NET 10.0+

## What This Package Does

Contains:
- abstractions for Domain-Driven Design (DDD) entities, values, aggregates
- abstractions for some infrastructural concerns
- some base implementations of the abstractions

Key design decisions:

- The concept entity is captured on two levels:
  1. Non-generic `IEntity` interface, requiring a unique identifier for the entity, with the identifier accessed as an `object`.
     Allows the entity to be used in contexts where the specific type of the identifier is unimportant or is not known. It can be used as a "marker" interface.
  1. Generic `IEntity<TEntityId>` interface inherits from the non-generic `IEntity` interface, and provides type-safe access to the unique identifier of the entity.

## Common Local Commands

```bash
# Build
dotnet build vm2.Domain.slnx

# Run tests (xUnit v3, MTP v2 — each project is a compiled executable)
dotnet test --project tests/Domain.Tests/Domain.Tests.csproj

# Run test executables (xUnit v3, MTP v2 — each project is a compiled to an executable) on Linux:
tests/Domain/bin/Debug/net10.0/Domain.Tests # or
tests/Domain/bin/Debug/net10.0/Domain.Tests.exe #  on Windows

# Run a single test by method name (xUnit v3, MTP v2 filter syntax)
dotnet test --project tests/Domain.Tests/Domain.Tests.csproj --filter "MethodName_WhenCondition_ShouldOutcome"

# Pack NuGet package
dotnet pack vm2.Domain.slnx --configuration Release

# Run benchmarks (Release only)
dotnet run --project benchmarks/Domain.Benchmarks --configuration Release -- --filter "*"

# If the benchmark tests are already built, you can run the compiled executable directly:
benchmarks/Domain.Benchmarks/bin/Release/net10.0/Domain.Benchmarks --help
benchmarks/Domain.Benchmarks/bin/Release/net10.0/Domain.Benchmarks --filter "*" # on Linux
benchmarks/Domain.Benchmarks/bin/Release/net10.0/Domain.Benchmarks.exe --filter "*" # on Windows
```

Tests use MTP v2 (Microsoft Testing Platform v2) with xUnit v3 — they compile to standalone executables.
Use `dotnet test --project <path>` per project; solution-wide `dotnet test` is not supported with MTP v2.

## Performance Characteristics

- *TODO* Hot paths, allocation behavior, benchmark numbers if known.

## Known Trade-offs and Design Notes

- *TODO*

## Active Work / Known Issues

- *TODO*

## Prompting Notes for This Package

- *TODO* Key invariants Claude must preserve, what to inject for testability, any non-obvious constraints.
