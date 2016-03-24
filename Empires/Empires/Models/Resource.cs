namespace Empires.Models
{
    using System;

    using Contracts;
    using Enums;

    public class Resource : IResource
    {
        // Added field and validation
        private int quantity;

        public Resource(ResourceType resourceType, int quantity)
        {
            this.ResourceType = resourceType;
            this.Quantity = quantity;
        }

        public ResourceType ResourceType { get; }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.quantity), "Resource quantity cannot be negative.");
                }

                this.quantity = value;
            }
        }
    }
}
