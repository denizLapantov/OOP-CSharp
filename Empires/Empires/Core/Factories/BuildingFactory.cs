namespace Empires.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    public class BuildingFactory : IBuildingFactory
    {
        public IBuilding CreateBuilding(string buildingType, IUnitFactory unitFactory, IResourceFactory resourceFactory)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.ToLowerInvariant() == buildingType);

            if (type == null)
            {
                throw new ArgumentException("Unknown building type.");
            }

            var building = (IBuilding)Activator.CreateInstance(type, unitFactory, resourceFactory);

            return building;
        }
    }
}
