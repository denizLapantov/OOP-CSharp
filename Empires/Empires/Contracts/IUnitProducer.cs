namespace Empires.Contracts
{
    using Models.EventHandlers;

    public interface IUnitProducer
    {
        event UnitProducedEventHandler OnUnitProduced;
    }
}
