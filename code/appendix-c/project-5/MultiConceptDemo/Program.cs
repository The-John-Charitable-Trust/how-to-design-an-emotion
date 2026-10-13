using System;
using System.Collections.Generic;

namespace MultiConceptDemo
{
    enum CarRole { TRANSPORT, STATUS, SHELTER }

    class Car
    {
        public string Model { get; set; }
        public int Value { get; set; }

        public Car(string model, int value)
        {
            Model = model;
            Value = value;
        }

        public override string ToString() => $"{Model} (${Value})";
    }

    interface IGoal
    {
        bool Select(Car car);
        string Name { get; }
    }

    class TransportGoal : IGoal
    {
        public string Name => "Transport";
        public bool Select(Car car) => true; // all cars transport
    }

    class StatusGoal : IGoal
    {
        public string Name => "Status";
        public bool Select(Car car) => car.Value > 50000;
    }

    class ShelterGoal : IGoal
    {
        public string Name => "Shelter";
        public bool Select(Car car) => true; // simplified
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>
            {
                new Car("Honda Civic", 25000),
                new Car("Mercedes S-Class", 120000)
            };

            var goals = new List<IGoal>
            {
                new TransportGoal(),
                new StatusGoal(),
                new ShelterGoal()
            };

            foreach (var goal in goals)
            {
                Console.WriteLine($"Goal: {goal.Name}");
                foreach (var car in cars)
                {
                    if (goal.Select(car))
                    {
                        Console.WriteLine($"  Selected: {car}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
