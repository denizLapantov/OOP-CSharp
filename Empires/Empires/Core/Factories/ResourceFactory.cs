namespace Empires.Core.Factories
{
    using Contracts;
    using Enums;
    using Models;

    public class ResourceFactory : IResourceFactory
    {
        public IResource CreateResource(ResourceType resourceType, int quantity)
        {
            var resource = new Resource(resourceType, quantity);

            return resource;
        }
    }
}
