using System;

namespace Project4
{
    public class ExternalSituation
    {
        public string Name { get; }

        public ExternalSituation(string name)
        {
            Name = name;
        }
    }

    public class FeelingState
    {
        public string Context { get; }
        public int ArousalLevel { get; }

        public FeelingState(string context, int arousalLevel)
        {
            Context = context;
            ArousalLevel = arousalLevel;
        }
    }

    public class Goal
    {
        public string Name { get; }

        public Goal(string name)
        {
            Name = name;
        }
    }

    public class EmotionMeaning
    {
        public string Label { get; }

        public EmotionMeaning(string label)
        {
            Label = label;
        }
    }

    public static class EmotionPipeline
    {
        public static FeelingState GenerateFeeling(ExternalSituation situation)
        {
            if (situation.Name == "footsteps_behind")
                return new FeelingState("dark_street", 7);

            return new FeelingState("neutral_space", 1);
        }

        public static EmotionMeaning Interpret(FeelingState feeling, Goal goal)
        {
            if (feeling.Context == "dark_street" && feeling.ArousalLevel >= 7 && goal.Name == "stay_safe")
                return new EmotionMeaning("Fear");

            if (feeling.Context == "dark_street" && feeling.ArousalLevel >= 7 && goal.Name == "meet_friend")
                return new EmotionMeaning("Relief");

            return new EmotionMeaning("Undetermined");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string situationName = args.Length > 0 ? args[0] : "footsteps_behind";
            string goalName = args.Length > 1 ? args[1] : "stay_safe";

            var situation = new ExternalSituation(situationName);
            var feeling = EmotionPipeline.GenerateFeeling(situation);
            var goal = new Goal(goalName);
            var emotion = EmotionPipeline.Interpret(feeling, goal);

            Console.WriteLine($"Situation: {situation.Name}");
            Console.WriteLine($"Feeling: Context={feeling.Context}, Arousal={feeling.ArousalLevel}");
            Console.WriteLine($"Goal: {goal.Name}");
            Console.WriteLine($"Emotion: {emotion.Label}");
            Console.WriteLine("Result: The execution flow preserves phase separation between situation, feeling, and emotion.");
        }
    }
}
