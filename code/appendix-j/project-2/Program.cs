using System;
using System.Collections.Generic;

class EmotionResult
{
    public string Goal { get; set; } = "";
    public string SelectedConcept { get; set; } = "";
    public string Identifier { get; set; } = "";
    public string Action { get; set; } = "";
}

class Program
{
    static void Main(string[] args)
    {
        string stimulus = args.Length > 0 ? args[0].ToLowerInvariant() : "snake";
        string goal = args.Length > 1 ? args[1].ToLowerInvariant() : "safety";

        var result = Interpret(stimulus, goal);

        Console.WriteLine($"Goal: {result.Goal}");
        Console.WriteLine($"SelectedConcept: {result.SelectedConcept}");
        Console.WriteLine($"Identifier: {result.Identifier}");
        Console.WriteLine($"Action: {result.Action}");
    }

    static EmotionResult Interpret(string stimulus, string goal)
    {
        if (stimulus == "snake" && goal == "safety")
        {
            return new EmotionResult
            {
                Goal = "safety",
                SelectedConcept = "fear",
                Identifier = "Fear(snake)",
                Action = "withdraw"
            };
        }

        if (stimulus == "snake" && goal == "curiosity")
        {
            return new EmotionResult
            {
                Goal = "curiosity",
                SelectedConcept = "interest",
                Identifier = "Interest(snake)",
                Action = "approach cautiously"
            };
        }

        return new EmotionResult
        {
            Goal = goal,
            SelectedConcept = "undetermined",
            Identifier = "None",
            Action = "no action"
        };
    }
}
