namespace Empires.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.EventArgs;

    public class Engine : IRunnable
    {
        private readonly IBuildingFactory buildingFactory;
        private readonly IResourceFactory resourceFactory;
        private readonly IUnitFactory unitFactory;
        private readonly IEmpiresData data;
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;

        public Engine(
            IBuildingFactory buildingFactory, 
            IResourceFactory resourceFactory, 
            IUnitFactory unitFactory, 
            IEmpiresData data, 
            IInputReader reader, 
            IOutputWriter writer)
        {
            this.buildingFactory = buildingFactory;
            this.resourceFactory = resourceFactory;
            this.unitFactory = unitFactory;
            this.data = data;
            this.reader = reader;
            this.writer = writer;
        }

        // Made method virtual
        public virtual void Run()
        {
            while (true)
            {
                string[] input = this.reader.ReadLine().Split();

                this.ExecuteCommand(input);
                this.UpdateBuildings();
            }
        }

        // Made method virtual and protected to allow extension (new commands)
        protected virtual void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "empire-status":
                    this.ExecuteStatusCommand();
                    break;
                case "armistice":
                    Environment.Exit(0);
                    break;
                case "skip":
                    break;
                case "build":
                    this.ExecuteBuildCommand(inputParams[1]);
                    break;
                default:
                    throw new ArgumentException("Unknown command.");
            }
        }

        private void UpdateBuildings()
        {
            foreach (IBuilding building in this.data.Buildings)
            {
                building.Update();
            }
        }

        private void ExecuteBuildCommand(string buildingType)
        {
            IBuilding building = 
                this.buildingFactory.CreateBuilding(buildingType, this.unitFactory, this.resourceFactory);

            // Subscribe for events in the building; add methods to the events - these methods will be invoked when the events fire
            building.OnResourceProduced += this.AddResource;
            building.OnUnitProduced += this.AddUnit;

            this.data.AddBuilding(building);
        }

        // When event OnResourceProduced is fired, this method is invoked
        private void AddResource(object sender, ResourceProducedEventArgs e)
        {
            var resource = e.Resource;
            this.data.Resources[resource.ResourceType] += resource.Quantity;
        }

        // When event OnUnitProduced is fired, this method is invoked
        private void AddUnit(object sender, UnitProducedEventArgs e)
        {
            var unit = e.Unit;
            this.data.AddUnit(unit);
        }

        private void ExecuteStatusCommand()
        {
            StringBuilder output = new StringBuilder();

            this.AppendTreasuryInfo(output);
            this.AppendBuildingsInfo(output);
            this.AppendUnitsInfo(output);

            this.writer.Print(output.ToString().Trim());
        }

        private void AppendUnitsInfo(StringBuilder output)
        {
            output.AppendLine("Units:");
            if (this.data.Units.Any())
            {
                foreach (var unit in this.data.Units)
                {
                    output.AppendLine($"--{unit.Key}: {unit.Value}");
                }
            }
            else
            {
                output.AppendLine("N/A");
            }
        }

        private void AppendBuildingsInfo(StringBuilder output)
        {
            output.AppendLine("Buildings:");
            if (this.data.Buildings.Any())
            {
                foreach (IBuilding building in this.data.Buildings)
                {
                    output.AppendLine(building.ToString());
                }
            }
            else
            {
                output.AppendLine("N/A");
            }
        }

        private void AppendTreasuryInfo(StringBuilder output)
        {
            output.AppendLine("Treasury:");
            foreach (var resource in this.data.Resources)
            {
                output.Append($"--{resource.Key}: {resource.Value}{Environment.NewLine}");
            }
        }
    }
}
