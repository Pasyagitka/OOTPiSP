﻿using System;
using Lab07;

namespace Lab06
{
    internal abstract class Fish : Animal, IVitalActivity
    {
        public Fish(string name, int year, int weight = 1) : base(name, year)
        {
            if (weight < 0)
                throw new WrongWeightException("Вес не может быть отрицательным!");
            this.weight = weight;
            this.feedingStrategy = feedingStrategies.omnivore;
        }

        public override void Move()
        {
            Console.WriteLine("Рыба плывет");
        }

        public void Eat()
        {
            Console.WriteLine("Рыба ест");
        }

        public void Sleep()
        {
            Console.WriteLine("Рыба спит... ZzZ...");
        }

        public override string ToString()
        {
            return "Рыба: Name: " + name + ", Year: " + dateOfBirth + ", Weight: " + weight + ", Feeding Strategy: " + feedingStrategy;
        }

        public abstract void VitalActivity();
    }
}