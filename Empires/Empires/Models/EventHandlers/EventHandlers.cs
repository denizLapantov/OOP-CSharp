namespace Empires.Models.EventHandlers
{
    // Moved event handlers to separate file
    using EventArgs;

    public delegate void UnitProducedEventHandler(object sender, UnitProducedEventArgs e);

    public delegate void ResourceProducedEventHandler(object sender, ResourceProducedEventArgs e);
}
