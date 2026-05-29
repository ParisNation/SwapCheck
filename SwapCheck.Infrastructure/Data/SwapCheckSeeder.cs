using SwapCheck.Domain.Entities;
using SwapCheck.Domain.Enums;

namespace SwapCheck.Infrastructure.Data
{
    public class SwapCheckSeeder
    {
        private readonly SwapCheckDbContext _context;
        
        public SwapCheckSeeder(SwapCheckDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {

            if(_context.Vehicles.Any())
            {
                return;
            }

            var vehicles = new List<Vehicle>
            {
                new Vehicle { Id = Guid.NewGuid(), Make = "Land Rover", Model = "Discovery", Year = 2003},
                new Vehicle { Id = Guid.NewGuid(), Make = "Chevrolet", Model = "Camaro", Year = 1969},
                new Vehicle { Id = Guid.NewGuid(), Make = "Ford", Model = "Mustang", Year = 1965},
                new Vehicle { Id = Guid.NewGuid(), Make = "Dodge", Model = "Charger", Year = 2025}
            };
            _context.Vehicles.AddRange(vehicles);
            await _context.SaveChangesAsync();

            if(_context.Engines.Any())
            {
                return;
            }

            var engines = new List<Engine>
            {
                new Engine { Id = Guid.NewGuid(), EngineName = "Rover V8", Displacement = 4.6, Manufacturer = "Land Rover", CylindersCount = Cylinders.Eight, Aspiration = AspirationType.NaturallyAspirated, Fuel = FuelType.Gasoline},
                new Engine { Id = Guid.NewGuid(), EngineName = "Chevrolet LS3", Displacement = 6.2, Manufacturer = "Chevrolet", CylindersCount = Cylinders.Eight, Aspiration = AspirationType.NaturallyAspirated, Fuel = FuelType.Gasoline},
                new Engine { Id = Guid.NewGuid(), EngineName = "Ford Coyote", Displacement = 5.0, Manufacturer = "Ford", CylindersCount = Cylinders.Eight, Aspiration = AspirationType.NaturallyAspirated, Fuel = FuelType.Gasoline},
                new Engine { Id = Guid.NewGuid(), EngineName = "Dodge HEMI", Displacement = 5.7, Manufacturer = "Dodge", CylindersCount = Cylinders.Eight, Aspiration = AspirationType.NaturallyAspirated, Fuel = FuelType.Gasoline}
            };

            _context.Engines.AddRange(engines);
            await _context.SaveChangesAsync();
            
            if(_context.SwapCompatibilities.Any())
            {
                return;
            }
            
            var landRover = _context.Vehicles.First(v => v.Make == "Land Rover" );
            var chevrolet = _context.Vehicles.First(v => v.Make == "Chevrolet" );
            var ford = _context.Vehicles.First(v => v.Make == "Ford" );
            var dodge = _context.Vehicles.First(v => v.Make == "Dodge" );

            var roverV8 = _context.Engines.First(e => e.EngineName == "Rover V8" );
            var ls3 = _context.Engines.First(e => e.EngineName == "Chevrolet LS3" );
            var coyote = _context.Engines.First(e => e.EngineName == "Ford Coyote" );
            var hemi = _context.Engines.First(e => e.EngineName == "Dodge HEMI" );

            var compatibilities = new List<SwapCompatibility>
            {
                new SwapCompatibility
                {
                    Id = Guid.NewGuid(),
                    VehicleId = landRover.Id,
                    EngineId = roverV8.Id,
                    IsCompatible = true,
                    DifficultyLevel = SwapDifficulty.DirectBolt,
                    Notes = "Factory fit - original engine"
                },
                new SwapCompatibility
                {
                    Id = Guid.NewGuid(),
                    VehicleId = landRover.Id,
                    EngineId = ls3.Id,
                    IsCompatible = false,
                    DifficultyLevel = SwapDifficulty.CustomFabrication,
                    Notes = "Requires custom mounts and adapter plate"
                },
                new SwapCompatibility
                {
                    Id = Guid.NewGuid(),
                    VehicleId = chevrolet.Id,
                    EngineId = ls3.Id,
                    IsCompatible = true,
                    DifficultyLevel = SwapDifficulty.DirectBolt,
                    Notes = "Factory fit - original engine"
                },
                new SwapCompatibility
                {
                    Id = Guid.NewGuid(),
                    VehicleId = ford.Id,
                    EngineId = coyote.Id,
                    IsCompatible = true,
                    DifficultyLevel = SwapDifficulty.DirectBolt,
                    Notes = "Factory fit - original engine"
                },
                new SwapCompatibility
                {
                    Id = Guid.NewGuid(),
                    VehicleId = dodge.Id,
                    EngineId = hemi.Id,
                    IsCompatible = true,
                    DifficultyLevel = SwapDifficulty.DirectBolt,
                    Notes = "Factory fit - original engine"
                }
            };
            _context.SwapCompatibilities.AddRange(compatibilities);
            await _context.SaveChangesAsync();
        } 
    }
}