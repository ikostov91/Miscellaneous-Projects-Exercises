using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models
{
    public class Gpu : Product
    {
        private const double DefaultWeight = 0.7;

        public Gpu(double price)
            : base(price, DefaultWeight)
        {
        }
    }
}
