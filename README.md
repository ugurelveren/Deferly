# Deferly

[![Build Status](https://github.com/ugurelveren/Deferly/actions/workflows/build.yml/badge.svg)](https://github.com/ugurelveren/Deferly/actions/workflows/build.yml)


A simple C# library providing a `DeferContext` for registering deferred actions that execute in Last-In-First-Out (LIFO) order when the context is disposed. Inspired by Go's `defer`, this library helps ensure cleanup code runs predictably at the end of a scope.

---

## Table of Contents
1. [Getting Started](#getting-started)
2. [Usage](#usage)
   - [DeferContext](#defercontext)
   - [Defer Helper](#defer-helper)
4. [Running Tests](#running-tests)
5. [Contributing](#contributing)
6. [License](#license)

---

## Getting Started

This library targets .NET Standard and can be used in any .NET Core or .NET Framework project. It provides two main types:

- `DeferContext`: A disposable context for registering actions that run when disposed.
- `Defer`: A static helper with shortcuts to create contexts and register actions.

Use `DeferContext` in a `using` block (or a `using` declaration) to ensure all registered callbacks run at the end of the scope.

---

## Usage

### DeferContext

```csharp
using Defer;

public void MyMethod()
{
    using (var context = new DeferContext())
    {
        // Register cleanup actions
        context.Defer(() => Console.WriteLine("Cleanup A"));
        context.Defer(() => Console.WriteLine("Cleanup B"));

        // Main logic here
    }
    // When the using block ends, deferred actions run in LIFO: B, then A.
}
```

### Defer Helper

Alternatively, use the static `Defer` helper to create contexts and register actions:

```csharp
using Defer;

public void AnotherMethod()
{
    // Create a new DeferContext
    var context = Defer.Create();
    try
    {
        Defer.OnExit(context, () => Console.WriteLine("Cleanup via helper"));
        // ... work ...
    }
    finally
    {
        // Ensure all deferred actions run
        context.Dispose();
    }
}
```

---

## Running Tests

This project includes xUnit tests covering core behaviors of `DeferContext` and the `Defer` helper.

1. Navigate to the `tests/Deferly.Tests` folder.  
2. Run `dotnet test`:
   ```bash
   cd tests/Defer.Tests
   dotnet test
   ```
---

## Contributing

Contributions are welcome! Please follow these guidelines:

1. Fork the repository and create a new branch for your feature or fix.  
2. Ensure all existing tests pass, and add new tests for any new behavior.  
3. Adhere to existing code style conventions (use `var` where appropriate, PascalCase for public members, etc.).  
4. Open a pull request with a description of changes.

---

## License

This project is licensed under the [MIT License](LICENSE).
