using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StorageMaster.Models
{
    public class SolidStateDrive : Product
    {
        private const double DefaultWeight = 0.2;

        public SolidStateDrive(double price)
            : base(price, DefaultWeight)
        {
        }
    }
}
