using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public abstract class Couple : HouseHold
    {
        private decimal tvCost;
        private decimal fridgeCost;

        protected Couple(decimal income, int numberOfRooms, decimal roomElecticity,decimal tvCost,decimal fridgeCost) 
            : base(income, numberOfRooms, roomElecticity)
        {
            this.tvCost = tvCost;
            this.fridgeCost = fridgeCost;
        }

        public override decimal Consumption => this.fridgeCost + this.tvCost + base.Consumption;

        public override int Population => 1 + base.Population;
    }
}