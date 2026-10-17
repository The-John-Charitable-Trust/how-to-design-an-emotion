using System;

namespace IdentityLayerDemo
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

    class Program
    {
        static void Main(string[] args)
        {
            string mode = args.Length > 0 ? args[0].ToLowerInvariant() : "valid";

            if (mode == "invalid")
            {
                string requestedType = "TOY";

                if (!Enum.TryParse(requestedType, out FishType type) || !Enum.IsDefined(typeof(FishType), type))
                {
                    Console.WriteLine($"Rejected: {requestedType} is not a FishType");
                    Console.WriteLine("Reason: Type must be PET or FOOD");
                    return;
                }

                Console.WriteLine($"Fish instance created: {new Fish("Goldfish", type)}");
                return;
            }

            var goldfish = new Fish("Goldfish", FishType.PET);
            var salmon = new Fish("Salmon", FishType.FOOD);

            Console.WriteLine($"Fish instance created: {goldfish}");
            Console.WriteLine($"Fish instance created: {salmon}");
            Console.WriteLine("Shared structure: Fish (Species, Type)");
        }
    }
}
