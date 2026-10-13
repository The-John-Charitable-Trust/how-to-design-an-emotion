using System;

namespace Project1
{
    public class EmotionConcept
    {
        public string Name { get; }
        public string RequiredContext { get; }
        public int MinimumArousal { get; }

        public EmotionConcept(string name, string requiredContext, int minArousal)
        {
            Name = name;
            RequiredContext = requiredContext;
            MinimumArousal = minArousal;
        }

        public bool IsValid(EmotionInstance instance)
        {
            return instance.Context == RequiredContext && instance.ArousalLevel >= MinimumArousal;
        }
    }

    public class EmotionInstance
    {
        public string Context { get; }
        public int ArousalLevel { get; }

        public EmotionInstance(string context, int arousal)
        {
            Context = context;
            ArousalLevel = arousal;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var fear = new EmotionConcept("Fear", "danger", 6);

            string context = args.Length > 0 ? args[0] : "danger";
            int arousal = args.Length > 1 ? int.Parse(args[1]) : 7;

            var instance = new EmotionInstance(context, arousal);

            Console.WriteLine($"Concept: {fear.Name}");
            Console.WriteLine($"Instance: Context={instance.Context}, Arousal={instance.ArousalLevel}");

            bool valid = fear.IsValid(instance);

            Console.WriteLine(valid
                ? "Result: VALID instance of concept."
                : "Result: INVALID instance (violates identity conditions).");
        }
    }
}
