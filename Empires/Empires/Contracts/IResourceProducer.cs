namespace Empires.Contracts
{
    using Models.EventHandlers;

    public interface IResourceProducer
    {
        event ResourceProducedEventHandler OnResourceProduced;
    }
}
