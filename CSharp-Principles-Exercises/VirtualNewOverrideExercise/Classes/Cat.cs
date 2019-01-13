using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualNewOverrideExercise.Classes
{
    internal class Cat : Animal
    {
        public Cat(string name)
            : base(name)
        {
        }

        public new string ToString()
        {
            return $"Cat with name: {this.Name}.";
        }
    }
}
