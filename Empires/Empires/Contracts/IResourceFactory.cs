namespace Empires.Contracts
{
    using Enums;

    public interface IResourceFactory
    {
        IResource CreateResource(ResourceType resourceType, int quantity);
    }
}
