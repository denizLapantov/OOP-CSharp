using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public abstract class HouseHold
    {
        private int numberOfRooms;
        private decimal roomElecticity;
        private readonly decimal income;
        private decimal money;

        protected HouseHold(decimal income,int numberOfRooms, decimal roomElecticity)
        {
            this.money = 0;
            this.income = income;
            this.numberOfRooms = numberOfRooms;
            this.roomElecticity = roomElecticity;
        }

        public virtual int Population => 1;

        public virtual decimal Consumption => this.numberOfRooms * this.roomElecticity;

        public void PayBills()
        {
            this.money -= this.Consumption;
        }

        public bool CanPayBills()
        {
            return this.money >= this.Consumption;
        }

        public void GetIncome()
        {
            this.money += this.income;
        }
    }
}