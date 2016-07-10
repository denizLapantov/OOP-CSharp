using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public class AloneYoung : Single
    {
        private const int NumberOfRooms = 1;
        private const int ElectricityCost = 10;

        private decimal laptopCost;

        public AloneYoung(decimal salary,decimal laptopCost)
            : base(salary, NumberOfRooms, ElectricityCost)
        {
            this.laptopCost = laptopCost;
        }

        public override decimal Consumption => this.laptopCost + base.Consumption;
    }
}