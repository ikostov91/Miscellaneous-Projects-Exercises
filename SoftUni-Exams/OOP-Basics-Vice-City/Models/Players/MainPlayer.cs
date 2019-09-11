using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Basics_Vice_City.Models.Players
{
    public class MainPlayer : Player
    {
        private const string NAME = "Tommy Vercetti";

        public MainPlayer()
            : base(NAME, 100)
        {
        }
    }
}
