using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Lab06
{

    //Создать Зоопарк. Найти средний вес животных заданного вида в зоопарке, количество хищных птиц, вывести всех животных отсортированных по году рождения.
    public static class Controller
    {
        public static void AverageWeight(Zoo zoo, string animalspecies)
        {
            int weight = 0;
            int counter = 0;
            for (int i = 0; i < zoo.List.Count; i++)
            {
                if (zoo.List[i].name == animalspecies)
                {
                    weight += zoo.List[i].weight;
                    counter++;
                }
            }
            Console.WriteLine("Средний вес животных вида {0} равен {1}", animalspecies, weight / counter);
        }

        public static int PredatoryBirds(Zoo zoo)
        {
            int counter = 0;
            foreach (var item in zoo.List)
            {
                if (item.feedingStrategy == Animal.feedingStrategies.omnivore)
                {
                    counter++;
                }
            }
            return counter;
        }

        public static void SortByYear(Zoo zoo)
        {
            Animal temp;
            for (int i = 0; i < zoo.List.Count; i++)
            {
                for (int j = i + 1; j < zoo.List.Count; j++)
                {
                    if (zoo.List[i].dateOfBirth > zoo.List[j].dateOfBirth)
                    {
                        temp = zoo.List[i];
                        zoo.List[i] = zoo.List[j];
                        zoo.List[j] = temp;
                    }
                }
            }
            Console.WriteLine("Отсортированный по дате рождения зоопарк: ");
            zoo.ShowZoo();
        }
    }
}
