using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public class Child
    {
        private decimal[] consumption;

        public Child(decimal[] consumption)
        {
            this.consumption = consumption;
        }

        public decimal GetTotalConsumption()
        {
            return this.consumption.Sum();
        }
    }
}