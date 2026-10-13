using System;
using System.Collections.Generic;

namespace IdentityLayerDemo;

public abstract class Organism
{
    public required string Name { get; init; }
    public bool IsOrganism => true;
}

public sealed class Fish : Organism
{
    public required string Habitat { get; init; }
    public bool IsAquatic => string.Equals(Habitat, "Aquatic", StringComparison.OrdinalIgnoreCase);

    public static Fish Create(string name, string habitat)
    {
        if (!string.Equals(habitat, "Aquatic", StringComparison.OrdinalIgnoreCase))
        {
            throw new IdentityViolationException(
                $"Identity violation: '{name}' cannot instantiate Fish because Habitat='{habitat}'. A Fish must be aquatic.");
        }

        return new Fish
        {
            Name = name,
            Habitat = habitat
        };
    }
}

public sealed class IdentityViolationException : Exception
{
    public IdentityViolationException(string message) : base(message) { }
}

internal static class Program
{
    private static readonly Dictionary<string, Func<int>> Commands = new(StringComparer.OrdinalIgnoreCase)
    {
        ["valid"] = RunValid,
        ["invalid"] = RunInvalid,
        ["batch"] = RunBatch,
        ["help"] = ShowHelp
    };

    private static int Main(string[] args)
    {
        if (args.Length == 0)
        {
            return ShowHelp();
        }

        var command = args[0];
        if (Commands.TryGetValue(command, out var action))
        {
            return action();
        }

        Console.WriteLine($"Unknown command: {command}");
        Console.WriteLine();
        return ShowHelp();
    }

    private static int ShowHelp()
    {
        Console.WriteLine("IdentityLayerDemo");
        Console.WriteLine("Demonstrates upstream admissibility conditions for the Fish concept.");
        Console.WriteLine();
        Console.WriteLine("Commands:");
        Console.WriteLine("  dotnet run --project IdentityLayerDemo -- valid");
        Console.WriteLine("  dotnet run --project IdentityLayerDemo -- invalid");
        Console.WriteLine("  dotnet run --project IdentityLayerDemo -- batch");
        Console.WriteLine("  dotnet run --project IdentityLayerDemo -- help");
        return 0;
    }

    private static int RunValid()
    {
        Console.WriteLine("Scenario: Valid Fish Instantiation");
        Console.WriteLine("----------------------------------");

        var goldfish = Fish.Create("Goldfish", "Aquatic");
        Console.WriteLine($"Created: {goldfish.Name}");
        Console.WriteLine($"IsOrganism: {goldfish.IsOrganism}");
        Console.WriteLine($"IsAquatic: {goldfish.IsAquatic}");
        Console.WriteLine("Result: admissible instance of Fish.");
        return 0;
    }

    private static int RunInvalid()
    {
        Console.WriteLine("Scenario: Invalid Fish Instantiation");
        Console.WriteLine("------------------------------------");

        try
        {
            _ = Fish.Create("House Cat", "Terrestrial");
            Console.WriteLine("Unexpected success.");
            return 1;
        }
        catch (IdentityViolationException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Result: rejected at the identity layer.");
            return 0;
        }
    }

    private static int RunBatch()
    {
        Console.WriteLine("Scenario: Batch Admissibility Test");
        Console.WriteLine("----------------------------------");

        var candidates = new (string Name, string Habitat)[]
        {
            ("Goldfish", "Aquatic"),
            ("Salmon", "Aquatic"),
            ("House Cat", "Terrestrial"),
            ("Eagle", "Aerial")
        };

        foreach (var candidate in candidates)
        {
            try
            {
                var fish = Fish.Create(candidate.Name, candidate.Habitat);
                Console.WriteLine($"ACCEPTED: {fish.Name} satisfies Fish identity conditions.");
            }
            catch (IdentityViolationException ex)
            {
                Console.WriteLine($"REJECTED: {ex.Message}");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Conclusion: admissibility is decided before goal selection or contextual use.");
        return 0;
    }
}
