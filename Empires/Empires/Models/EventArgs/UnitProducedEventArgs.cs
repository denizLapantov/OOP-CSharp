namespace Empires.Models.EventArgs
{
    using System;

    using Contracts;

    public class UnitProducedEventArgs : EventArgs
    {
        // Added constructor and made setter private
        public UnitProducedEventArgs(IUnit unit)
        {
            this.Unit = unit;
        }

        public IUnit Unit { get; }
    }
}
