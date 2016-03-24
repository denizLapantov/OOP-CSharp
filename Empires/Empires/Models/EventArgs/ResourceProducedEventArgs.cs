namespace Empires.Models.EventArgs
{
    using System;

    using Contracts;

    public class ResourceProducedEventArgs : EventArgs
    {
        // Added constructor and made setter private
        public ResourceProducedEventArgs(IResource resource)
        {
            this.Resource = resource;
        }

        public IResource Resource { get; }
    }
}
