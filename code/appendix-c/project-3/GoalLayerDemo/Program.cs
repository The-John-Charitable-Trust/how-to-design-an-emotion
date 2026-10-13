using System;
using System.Collections.Generic;

namespace GoalLayerDemo
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

    interface IGoal
    {
        bool Select(Fish fish);
    }

    class PetGoal : IGoal
    {
        public bool Select(Fish fish) => fish.Type == FishType.PET;
    }

    class DinnerGoal : IGoal
    {
        public bool Select(Fish fish) => fish.Type == FishType.FOOD;
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

            IGoal goal = args.Length > 0 && args[0] == "dinner"
                ? new DinnerGoal()
                : new PetGoal();

            Console.WriteLine($"Active Goal: {goal.GetType().Name}\n");

            foreach (var fish in fishList)
            {
                if (goal.Select(fish))
                {
                    Console.WriteLine($"Selected: {fish}");
                }
            }
        }
    }
}
