
using System;

namespace EmotionFactoryExample
{
    // <<abstract>> Emotion
    public abstract class Emotion
    {
        public string Valence { get; protected set; }
        public string Context { get; protected set; }
        public string Expression { get; protected set; }

        protected Emotion(string valence, string context, string expression)
        {
            Valence = valence;
            Context = context;
            Expression = expression;
        }

        public virtual void Describe()
        {
            Console.WriteLine($"Type: {GetType().Name}");
            Console.WriteLine($"Valence: {Valence}");
            Console.WriteLine($"Context: {Context}");
            Console.WriteLine($"Expression: {Expression}");
        }
    }

    public class Joy : Emotion
    {
        public Joy() : base("positive", "safe", "smile") { }
    }

    public class Fear : Emotion
    {
        public Fear() : base("negative", "danger", "wide-eyes") { }
    }

    public class Anger : Emotion
    {
        public Anger() : base("negative", "obstacle", "frown") { }
    }

    public static class EmotionFactory
    {
        public static Emotion CreateEmotion(string type)
        {
            switch (type.ToLower())
            {
                case "joy":
                    return new Joy();
                case "fear":
                    return new Fear();
                case "anger":
                    return new Anger();
                default:
                    throw new ArgumentException($"Unknown emotion type: {type}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Emotion Construction Example\n");

            if (args.Length == 0)
            {
                Console.WriteLine("Please supply an emotion type (joy, fear, anger)");
                return;
            }

            string requestedEmotion = args[0];

            try
            {
                Emotion emotion = EmotionFactory.CreateEmotion(requestedEmotion);

                Console.WriteLine($"Input parameter: {requestedEmotion}\n");
                Console.WriteLine("Constructed Emotion\n");

                emotion.Describe();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
