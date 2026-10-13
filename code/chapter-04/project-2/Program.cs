using System;

class GrubConcept
{
    public bool IsAdmissible(string organism, bool larvalStage, bool livingMatter)
    {
        return organism.Equals("grub", StringComparison.OrdinalIgnoreCase)
            && larvalStage
            && livingMatter;
    }
}

class GrubInstance
{
    public string Organism { get; }
    public bool LarvalStage { get; }
    public bool LivingMatter { get; }

    public GrubInstance(string organism, bool larvalStage, bool livingMatter)
    {
        Organism = organism;
        LarvalStage = larvalStage;
        LivingMatter = livingMatter;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string culturalContext = args.Length > 0 ? args[0].ToLowerInvariant() : "food";

        var concept = new GrubConcept();
        var instance = new GrubInstance("grub", larvalStage: true, livingMatter: true);
        bool isValid = concept.IsAdmissible(instance.Organism, instance.LarvalStage, instance.LivingMatter);

        Console.WriteLine($"Organism: {instance.Organism}");
        Console.WriteLine($"LarvalStage: {instance.LarvalStage}");
        Console.WriteLine($"LivingMatter: {instance.LivingMatter}");
        Console.WriteLine($"IsAdmissible(): {isValid}");

        if (!isValid)
        {
            return;
        }

        Console.WriteLine($"CulturalContext: {culturalContext}");
        Console.WriteLine($"Category: {Classify(culturalContext)}");
        Console.WriteLine("ConceptualIdentity: grub");
    }

    static string Classify(string culturalContext)
    {
        return culturalContext switch
        {
            "food" => "food",
            "pest" => "pest",
            _ => "undetermined"
        };
    }
}
