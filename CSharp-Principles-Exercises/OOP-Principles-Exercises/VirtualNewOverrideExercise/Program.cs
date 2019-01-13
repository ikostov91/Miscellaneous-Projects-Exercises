using System;
using VirtualNewOverrideExercise.Classes;

namespace VirtualNewOverrideExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal cat1 = new Cat("Cat(animal)");
            Cat cat2 = new Cat("Cat(cat)");

            Animal dog1 = new Dog("Dog(animal)");
            Dog dog2 = new Dog("Dog(dog)");

            Console.WriteLine(cat1.ToString());
            Console.WriteLine(cat2.ToString());
            Console.WriteLine("-----------");
            Console.WriteLine(dog1.ToString());
            Console.WriteLine(dog2.ToString());
        }
    }
}
