using System;

class Right
{
    public string IdentifierType => "string";
    public string ValueType => "string";
    public string AssertionType => "string";
    public string AttestationType => "string";

    public RightConstruct Create(string identifier, string value, string assertion, string attestation)
    {
        return new RightConstruct(identifier, value, assertion, attestation);
    }
}

class RightConstruct
{
    public RightConstruct(string identifier, string value, string assertion, string attestation)
    {
        Identifier = identifier;
        Value = value;
        Assertion = assertion;
        Attestation = attestation;
    }

    public string Identifier { get; }
    public string Value { get; }
    public string Assertion { get; }
    public string Attestation { get; }

    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Attestation);
    }
}

class Program
{
    static int Main(string[] args)
    {
        if (args.Length != 4)
        {
            Console.Error.WriteLine("Usage: dotnet run -- \"drivingRight\" \"Operate a motor vehicle on public roads\" \"I have authority to drive\" \"state-issued driver's license\"");
            return 1;
        }

        var concept = new Right();
        var construct = concept.Create(args[0], args[1], args[2], args[3]);

        Console.WriteLine("Right Concept");
        Console.WriteLine($"identifier: {concept.IdentifierType}");
        Console.WriteLine($"value: {concept.ValueType}");
        Console.WriteLine($"assertion: {concept.AssertionType}");
        Console.WriteLine($"attestation: {concept.AttestationType}");
        Console.WriteLine();
        Console.WriteLine("Construct Created");
        Console.WriteLine($"identifier: \"{construct.Identifier}\"");
        Console.WriteLine($"value: \"{construct.Value}\"");
        Console.WriteLine($"assertion: \"{construct.Assertion}\"");
        Console.WriteLine($"attestation: \"{construct.Attestation}\"");
        Console.WriteLine();
        Console.WriteLine("Validation");
        Console.WriteLine("The right is modeled as attested authority to gain or keep a value.");
        Console.WriteLine($"The construct is {(construct.IsValid() ? "valid" : "invalid")} because the claim is paired with substantiating attestation.");
        return 0;
    }
}
