using System;

class IntegerConcept
{
    public string IdentifierType => "string";
    public string ValueType => "int";

    public IntegerConstruct Create(string identifier, int value)
    {
        return new IntegerConstruct(identifier, value);
    }
}

class IntegerConstruct
{
    public IntegerConstruct(string identifier, int value)
    {
        Identifier = identifier;
        Value = value;
    }

    public string Identifier { get; }
    public int Value { get; }
}

class Program
{
    static int Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.Error.WriteLine("Usage: dotnet run -- \"Seven\" 7");
            return 1;
        }

        var concept = new IntegerConcept();
        var construct = concept.Create(args[0], int.Parse(args[1]));

        Console.WriteLine("Integer Concept");
        Console.WriteLine($"identifier type: {concept.IdentifierType}");
        Console.WriteLine($"value type: {concept.ValueType}");
        Console.WriteLine();
        Console.WriteLine("Construct Created");
        Console.WriteLine($"identifier: \"{construct.Identifier}\"");
        Console.WriteLine($"int value: {construct.Value}");
        Console.WriteLine();
        Console.WriteLine("Result");
        Console.WriteLine("The identifier names the construct; the concept declares the integer identity conditions.");
        Console.WriteLine("Identity conditions remain fixed. Only the assigned value realizes the construct.");
        return 0;
    }
}
