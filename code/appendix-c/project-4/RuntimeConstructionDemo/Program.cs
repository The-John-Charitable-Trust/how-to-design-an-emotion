using System;
using System.Collections.Generic;

namespace RuntimeConstructionDemo
{
    enum FishType { PET, FOOD }

    class Fish
    {
        public string Species { get; set; }
        public FishType Type { get; set; }

        public Fish(string species, FishType type)
        {
            Species = species;
            Type = type;
        }

        public override string ToString() => $"{Species} ({Type})";
    }

    class ConceptSpecification
    {
        public Func<Fish, bool> Constraint { get; set; }
    }

    class RuntimeConceptBuilder
    {
        public ConceptSpecification Build(string goal)
        {
            if (goal.Equals("pet", StringComparison.OrdinalIgnoreCase))
            {
                return new ConceptSpecification
                {
                    Constraint = f => f.Type == FishType.PET
                };
            }

            if (goal.Equals("dinner", StringComparison.OrdinalIgnoreCase))
            {
                return new ConceptSpecification
                {
                    Constraint = f => f.Type == FishType.FOOD
                };
            }

            throw new Exception("Unknown goal");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var fishList = new List<Fish>
            {
                new Fish("Goldfish", FishType.PET),
                new Fish("Salmon", FishType.FOOD)
            };

            string goal = args.Length > 0 ? args[0] : "pet";

            var builder = new RuntimeConceptBuilder();
            var spec = builder.Build(goal);

            Console.WriteLine($"Runtime Goal: {goal}\n");

            foreach (var fish in fishList)
            {
                if (spec.Constraint(fish))
                {
                    Console.WriteLine($"Admissible under goal: {fish}");
                }
            }
        }
    }
}
