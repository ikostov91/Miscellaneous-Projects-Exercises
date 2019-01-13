using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualNewOverrideExercise.Classes
{
    internal abstract class Animal
    {
        private string name;

        public Animal(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return $"Animal with name: {this.Name}.";
        }
    }
}
