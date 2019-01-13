using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualNewOverrideExercise.Classes
{
    internal class Dog : Animal
    {
        public Dog(string name)
            : base(name)
        {
        }

        public override string ToString()
        {
            return $"Dog with name: {this.Name}.";
        }
    }
}
