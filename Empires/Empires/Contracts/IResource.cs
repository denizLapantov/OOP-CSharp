namespace Empires.Contracts
{
    using Enums;

    public interface IResource
    {
        ResourceType ResourceType { get; }

        int Quantity { get; }
    }
}
