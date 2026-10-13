using System;

namespace IdentityLayerDemo
{
    class Fish
    {
        public string Species { get; }
        public bool IsAquatic { get; }
        public bool IsOrganism { get; }

        public Fish(string species, bool isAquatic, bool isOrganism)
        {
            if (!isAquatic || !isOrganism)
            {
                throw new ArgumentException("Object does not satisfy Fish admissibility conditions");
            }

            Species = species;
            IsAquatic = isAquatic;
            IsOrganism = isOrganism;
        }

        public override string ToString() => Species;
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = args.Length > 0 ? args[0].ToLowerInvariant() : "goldfish";

            try
            {
                Fish fish = CreateCandidate(input);
                Console.WriteLine($"Valid Fish created: {fish}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Rejected: {input} is not a Fish");
                Console.WriteLine($"Reason: {ex.Message}");
            }
        }

        static Fish CreateCandidate(string input)
        {
            return input switch
            {
                "goldfish" => new Fish("Goldfish", true, true),
                "salmon" => new Fish("Salmon", true, true),
                "rock" => new Fish("Rock", false, false),
                "dog" => new Fish("Dog", false, true),
                _ => throw new ArgumentException("Unknown candidate")
            };
        }
    }
}
