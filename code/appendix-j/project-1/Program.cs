using System;
using System.Collections.Generic;

class PreparationTrace
{
    public string Simulation { get; set; } = "";
    public string Prediction { get; set; } = "";
    public string BodyBudget { get; set; } = "";
    public string Referent { get; set; } = "";
    public List<string> CandidateSchemas { get; set; } = new();
}

class Program
{
    static void Main(string[] args)
    {
        string stimulus = args.Length > 0 ? args[0].ToLowerInvariant() : "snake";

        PreparationTrace trace = BuildTrace(stimulus);

        Console.WriteLine($"Simulation: {trace.Simulation}");
        Console.WriteLine($"Prediction: {trace.Prediction}");
        Console.WriteLine($"BodyBudget: {trace.BodyBudget}");
        Console.WriteLine($"Referent: {trace.Referent}");
        Console.WriteLine($"CandidateSchemas: {string.Join(", ", trace.CandidateSchemas)}");
        Console.WriteLine("Result: No emotion constructed. Interpretation has not yet occurred.");
    }

    static PreparationTrace BuildTrace(string stimulus)
    {
        return stimulus switch
        {
            "snake" => new PreparationTrace
            {
                Simulation = "dim trail",
                Prediction = "possible danger",
                BodyBudget = "high arousal, negative valence",
                Referent = "snake-in-dim-light + high arousal",
                CandidateSchemas = new List<string> { "threat", "caution", "false alarm" }
            },
            _ => new PreparationTrace
            {
                Simulation = "uncertain context",
                Prediction = "underdetermined relevance",
                BodyBudget = "moderate arousal, neutral valence",
                Referent = $"{stimulus}-in-context + moderate arousal",
                CandidateSchemas = new List<string> { "novelty", "caution", "unknown" }
            }
        };
    }
}
