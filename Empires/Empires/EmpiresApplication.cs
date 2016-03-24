namespace Empires
{
    using Core;
    using Core.Factories;
    using IO;

    public class EmpiresApplication
    {
        public static void Main(string[] args)
        {
            var buildingFactory = new BuildingFactory();
            var unitFactory = new UnitFactory();
            var resourceFactory = new ResourceFactory();
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var data = new EmpiresData();

            var engine = new Engine(buildingFactory, resourceFactory, unitFactory, data, reader, writer);
            engine.Run();
        }
    }
}
