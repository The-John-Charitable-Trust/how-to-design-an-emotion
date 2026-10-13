using System;

namespace Project3
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

    public class EmotionInterpretation
    {
        public string Label { get; }

        public EmotionInterpretation(string label)
        {
            Label = label;
        }
    }

    public static class Interpreter
    {
        public static EmotionInterpretation Interpret(FeelingState feeling, Goal goal)
        {
            if (feeling.Context == "backstage" && feeling.ArousalLevel >= 7)
            {
                if (goal.Name == "perform_well")
                    return new EmotionInterpretation("Excitement");

                if (goal.Name == "avoid_failure")
                    return new EmotionInterpretation("Anxiety");
            }

            return new EmotionInterpretation("Undetermined");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string context = args.Length > 0 ? args[0] : "backstage";
            int arousal = args.Length > 1 ? int.Parse(args[1]) : 8;
            string goalName = args.Length > 2 ? args[2] : "perform_well";

            var feeling = new FeelingState(context, arousal);
            var goal = new Goal(goalName);

            var emotion = Interpreter.Interpret(feeling, goal);

            Console.WriteLine($"Feeling: Context={feeling.Context}, Arousal={feeling.ArousalLevel}");
            Console.WriteLine($"Goal: {goal.Name}");
            Console.WriteLine($"Emotion: {emotion.Label}");
            Console.WriteLine("Result: The same feeling yields different meanings under different goals.");
        }
    }
}
