using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public class YoungCoupleWithChildren : YoungCouple
    {
        private const int NumberOfRooms = 2;
        private const int ElectricityCost = 30;

        private Child[] children;

        public YoungCoupleWithChildren(decimal salarayOne,decimal salaryTwo, decimal tvCost, decimal fridgeCost, decimal laptopCost,Child[] children)
            : base(salaryTwo + salarayOne, NumberOfRooms, ElectricityCost, tvCost, fridgeCost, laptopCost)
        {
            this.children = children;
        }

        public override decimal Consumption => this.children.Sum(x => x.GetTotalConsumption()) + base.Consumption;

        public override int Population => this.children.Length + base.Population;
    }
}