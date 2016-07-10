using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public class YoungCouple : Couple
    {
        private const int NumberOfRooms = 2;
        private const int ElectricityCost = 20;

        private decimal laptopCost;

        public YoungCouple(decimal salaryOne,decimal salaryTwo, decimal tvCost, decimal fridgeCost,decimal laptopCost)
            : base(salaryOne + salaryTwo, NumberOfRooms, ElectricityCost, tvCost, fridgeCost)
        {
            this.laptopCost = laptopCost;
        }

        protected YoungCouple(decimal income, int numberOfRooms, decimal roomElecticity, decimal tvCost, decimal fridgeCost, decimal laptopCost) 
            : base(income, numberOfRooms, roomElecticity, tvCost, fridgeCost)
        {
            this.laptopCost = laptopCost;
        }

        public override decimal Consumption => this.laptopCost * 2 + base.Consumption;
    }
}