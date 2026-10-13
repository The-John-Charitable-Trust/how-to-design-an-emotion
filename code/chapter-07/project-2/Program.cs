using System;

class Identifier
{
    public string Symbol { get; set; }
}

class Concept
{
    public string Name { get; set; }
    public string Type { get; set; }
}

class Construct
{
    public int Value { get; set; }
}

class Referent
{
    public string Context { get; set; }
}

class Interpreter
{
    public string Agent { get; set; }
    public string Goal { get; set; }

    public string GenerateMeaning(Identifier id, Concept concept, Construct construct, Referent referent)
    {
        return $"Meaning: '{id.Symbol}' refers to the value {construct.Value} ({concept.Type}) in the context of {referent.Context}, for the goal of {Goal}. Interpreter: {Agent}.";
    }
}

class Program
{
    static void Main(string[] args)
    {
        string input = args.Length > 0 ? args[0] : "7";

        var identifier = new Identifier { Symbol = input };
        var concept = new Concept { Name = "Integer", Type = "int" };
        var referent = new Referent { Context = "days in a week" };

        var interpreter = new Interpreter 
        { 
            Agent = "Cezjah", 
            Goal = "Determine how many days are in a week" 
        };

        if (int.TryParse(input, out int value))
        {
            var construct = new Construct { Value = value };
            Console.WriteLine(interpreter.GenerateMeaning(identifier, concept, construct, referent));
        }
        else
        {
            Console.WriteLine($"Result: INVALID INSTANTIATION - '{input}' is not a valid Integer.");
        }
    }
}
