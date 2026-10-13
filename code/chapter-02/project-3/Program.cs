using System;
using System.Globalization;

class CoreAffect
{
    public string ValenceType => "float";
    public string ArousalType => "float";
    public string MotivationalIntensityType => "float";

    public CoreAffectConstruct Create(float valence, float arousal, float motivationalIntensity)
    {
        return new CoreAffectConstruct(valence, arousal, motivationalIntensity);
    }
}

class CoreAffectConstruct
{
    public CoreAffectConstruct(float valence, float arousal, float motivationalIntensity)
    {
        Valence = valence;
        Arousal = arousal;
        MotivationalIntensity = motivationalIntensity;
    }

    public float Valence { get; }
    public float Arousal { get; }
    public float MotivationalIntensity { get; }

    public double Magnitude()
    {
        return Math.Sqrt(Valence * Valence + Arousal * Arousal + MotivationalIntensity * MotivationalIntensity);
    }
}

class Program
{
    static int Main(string[] args)
    {
        if (args.Length != 3)
        {
            Console.Error.WriteLine("Usage: dotnet run -- 0.8 0.6 0.9");
            return 1;
        }

        var concept = new CoreAffect();
        var construct = concept.Create(
            float.Parse(args[0], CultureInfo.InvariantCulture),
            float.Parse(args[1], CultureInfo.InvariantCulture),
            float.Parse(args[2], CultureInfo.InvariantCulture));

        Console.WriteLine("CoreAffect Concept");
        Console.WriteLine($"valence: {concept.ValenceType}");
        Console.WriteLine($"arousal: {concept.ArousalType}");
        Console.WriteLine($"motivationalIntensity: {concept.MotivationalIntensityType}");
        Console.WriteLine();
        Console.WriteLine("Construct Created");
        Console.WriteLine($"valence: {construct.Valence.ToString(CultureInfo.InvariantCulture)}");
        Console.WriteLine($"arousal: {construct.Arousal.ToString(CultureInfo.InvariantCulture)}");
        Console.WriteLine($"motivationalIntensity: {construct.MotivationalIntensity.ToString(CultureInfo.InvariantCulture)}");
        Console.WriteLine($"magnitude: {Math.Round(construct.Magnitude(), 3).ToString(CultureInfo.InvariantCulture)}");
        Console.WriteLine();
        Console.WriteLine("Result");
        Console.WriteLine("A core affect construct realizes the declared dimensions of valence, arousal, and motivational intensity.");
        Console.WriteLine("Identity conditions remain fixed. Only the affective values vary.");
        return 0;
    }
}
