using System;

namespace Project2
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

        public bool IsSemioticallyAvailable()
        {
            return !string.IsNullOrWhiteSpace(Context) && ArousalLevel > 0;
        }
    }

    public class EmotionalMeaning
    {
        public string Label { get; }

        public EmotionalMeaning(string label)
        {
            Label = label;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string context = args.Length > 0 ? args[0] : "dark_garage";
            int arousal = args.Length > 1 ? int.Parse(args[1]) : 7;
            string mode = args.Length > 2 ? args[2] : "available";

            var feeling = new FeelingState(context, arousal);

            Console.WriteLine($"Feeling: Context={feeling.Context}, Arousal={feeling.ArousalLevel}");
            Console.WriteLine($"Semiotic availability: {feeling.IsSemioticallyAvailable().ToString().ToLower()}");

            if (mode == "available")
            {
                Console.WriteLine("Meaning: none");
                Console.WriteLine("Result: Feeling is eligible for interpretation but not yet meaningful.");
                return;
            }

            if (mode == "fear")
            {
                var meaning = new EmotionalMeaning("Fear");
                Console.WriteLine($"Meaning: {meaning.Label}");
                Console.WriteLine("Result: Semantic achievement has occurred.");
                return;
            }

            Console.WriteLine("Meaning: none");
            Console.WriteLine("Result: Unknown mode.");
        }
    }
}
