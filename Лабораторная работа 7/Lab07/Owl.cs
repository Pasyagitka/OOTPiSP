﻿using System;
using System.Diagnostics;

namespace Lab06
{
    partial class Owl : Bird
    {
        public Owl(string name, int year, int weight = 1) : base(name, year)
        {
            Debug.Assert(weight > 0,  "Assert: Вес не может быть отрицательным!");
            this.weight = weight;
            this.feedingStrategy = feedingStrategies.omnivore;
            this.aboutowl.habitat = "Belarus";
            this.aboutowl.color = "Grey";
        }

        public override void Move()
        {
            Console.WriteLine("Сова летит");
        }

        public override string ToString()
        {
            return "Name: " + this.name + ", Year: " + this.dateOfBirth + ", Weight: " + this.weight + ", Feeding Strategy: " + this.feedingStrategy + ", Habitat: " + this.aboutowl.habitat + ", Color: " + this.aboutowl.color;
        }
    }
}