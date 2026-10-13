using System;

namespace Project5
{
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

    public static class Reinterpreter
    {
        public static EmotionMeaning Interpret(FeelingState feeling, Goal goal, string update)
        {
            if (feeling.Context == "dark_street" && feeling.ArousalLevel >= 7 && goal.Name == "stay_safe")
            {
                if (update == "unknown_person")
                    return new EmotionMeaning("Fear");

                if (update == "recognized_friend")
                    return new EmotionMeaning("Relief");
            }

            return new EmotionMeaning("Undetermined");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string context = args.Length > 0 ? args[0] : "dark_street";
            int arousal = args.Length > 1 ? int.Parse(args[1]) : 7;
            string goalName = args.Length > 2 ? args[2] : "stay_safe";
            string update = args.Length > 3 ? args[3] : "unknown_person";

            var feeling = new FeelingState(context, arousal);
            var goal = new Goal(goalName);
            var emotion = Reinterpreter.Interpret(feeling, goal, update);

            Console.WriteLine($"Feeling: Context={feeling.Context}, Arousal={feeling.ArousalLevel}");
            Console.WriteLine($"Goal: {goal.Name}");
            Console.WriteLine($"Update: {update}");
            Console.WriteLine($"Emotion: {emotion.Label}");
            Console.WriteLine("Result: The same feeling is reinterpreted when contextual knowledge changes.");
        }
    }
}
