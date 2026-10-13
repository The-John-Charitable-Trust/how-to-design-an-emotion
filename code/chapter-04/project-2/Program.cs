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

// Goal layer: edible and pest are not part of the Grub concept.
// They are goal-relative evaluations of an already admissible instance.
class ForagingGoal
{
    public string Name => "ForagingGoal";
    public bool Edible(GrubInstance g, string culturalContext) => culturalContext == "food";
}

class PestControlGoal
{
    public string Name => "PestControlGoal";
    public bool Pest(GrubInstance g, string culturalContext) => culturalContext == "pest";
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
        var foraging = new ForagingGoal();
        var pestControl = new PestControlGoal();
        bool edible = foraging.Edible(instance, culturalContext);
        bool pest = pestControl.Pest(instance, culturalContext);
        Console.WriteLine($"{foraging.Name}.edible: {edible}");
        Console.WriteLine($"{pestControl.Name}.pest: {pest}");
        Console.WriteLine($"Category: {Classify(edible, pest)}");
        Console.WriteLine("ConceptualIdentity: grub");
    }

    static string Classify(bool edible, bool pest)
    {
        if (edible) return "food";
        if (pest) return "pest";
        return "undetermined";
    }
}
