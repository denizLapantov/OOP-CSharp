using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public class OldCouple : Couple
    {
        private const int NumberOfRooms = 3;
        private const int ElectricityCost = 15;

        private decimal stoveCost;

        public OldCouple(decimal pensionOne,decimal pensionTwo, decimal tvCost, decimal fridgeCost,decimal stoveCost)
            : base(pensionOne + pensionTwo, NumberOfRooms, ElectricityCost, tvCost, fridgeCost)
        {
            this.stoveCost = stoveCost;
        }

        public override decimal Consumption => this.stoveCost + base.Consumption;
    }
}