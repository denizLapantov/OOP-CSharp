namespace Empires.Models.Buildings
{
    using System;

    using Contracts;
    using Enums;
    using EventArgs;
    using EventHandlers;

    public abstract class Building : IBuilding
    {
        private const int ProductionDelay = 1;

        private int cyclesCount = 0;

        // Encapsulated fields, moved event handlers to separate file
        private readonly string unitType;
        private int unitCycleLength;
        private readonly ResourceType resourceType;
        private int resourceCycleLength;
        private int resourceQuantity;
        private readonly IUnitFactory unitFactory;
        private readonly IResourceFactory resourceFactory;

        protected Building(
            string unitType,
            int unitCycleLength,
            ResourceType resourceType,
            int resourceCycleLength,
            int resourceQuantity,
            IUnitFactory unitFactory,
            IResourceFactory resourceFactory)
        {
            this.unitType = unitType;
            this.UnitCycleLength = unitCycleLength;
            this.resourceType = resourceType;
            this.ResourceCycleLength = resourceCycleLength;
            this.ResourceQuantity = resourceQuantity;
            this.unitFactory = unitFactory;
            this.resourceFactory = resourceFactory;
        }

        private bool CanProduceResource
        {
            get
            {
                bool canProduceResource = this.cyclesCount > ProductionDelay
                    && (this.cyclesCount - ProductionDelay) % this.resourceCycleLength == 0;

                return canProduceResource;
            }
        }

        private bool CanProduceUnit
        {
            get
            {
                bool canProduceUnit = this.cyclesCount > ProductionDelay
                    && (this.cyclesCount - ProductionDelay) % this.unitCycleLength == 0;

                return canProduceUnit;
            }
        }

        private int UnitCycleLength
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(this.unitCycleLength), 
                        "The length of the production cycle for units should be positive.");
                }

                this.unitCycleLength = value;
            }
        }

        private int ResourceCycleLength
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(this.resourceCycleLength), 
                        "The length of the production cycle for units should be positive.");
                }

                this.resourceCycleLength = value;
            }
        }

        private int ResourceQuantity
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(this.resourceQuantity), 
                        "The resource quantity produced by the building cannot be negative.");
                }

                this.resourceQuantity = value;
            }
        }

        // Made method virtual to allow modifications in derived classes
        public virtual void Update()
        {
            this.cyclesCount++;

            if (this.CanProduceResource && this.OnResourceProduced != null)
            {
                var resource = this.resourceFactory.CreateResource(this.resourceType, this.resourceQuantity);

                // Fire event - all methods attached to the event will be executed (e.g. AddResource from Engine)
                this.OnResourceProduced(this, new ResourceProducedEventArgs(resource));
            }

            if (this.CanProduceUnit && this.OnUnitProduced != null)
            {
                var unit = this.unitFactory.CreateUnit(this.unitType);

                // Fire event - all methods attached to the event will be executed (e.g. AddUnitfrom Engine)
                this.OnUnitProduced(this, new UnitProducedEventArgs(unit));
            }
        }

        public override string ToString()
        {
            int turnsUntilUnit = this.unitCycleLength - (this.cyclesCount - ProductionDelay) % this.unitCycleLength;
            int turnsUntilResource = this.resourceCycleLength - (this.cyclesCount - ProductionDelay) % this.resourceCycleLength;

            var result = string.Format(
                "--{0}: {1} turns ({2} turns until {3}, {4} turns until {5})",
                this.GetType().Name,
                this.cyclesCount - ProductionDelay,
                turnsUntilUnit,
                this.unitType,
                turnsUntilResource,
                this.resourceType);

            return result;
        }

        public event UnitProducedEventHandler OnUnitProduced;

        public event ResourceProducedEventHandler OnResourceProduced;
    }
}
