using SwapCheck.Domain.Enums;

namespace SwapCheck.Domain.Entities
{
    public class Engine
    {
        public Guid Id { get; set; }
        public string? EngineName { get; set; }
        public string? Manufacturer { get; set; }
        public double Displacement { get; set; }
        public Cylinders CylindersCount { get; set; }
        public int Horsepower { get; set; }
        public int Torque { get; set; }
        public AspirationType Aspiration { get; set; }
        public FuelType Fuel { get; set; }
        public Orientation EngineOrientation { get; set; }
        public TransBoltPattern TransBoltPattern { get; set; }
        public EngineSize EngineSize { get; set; }
        public MountPattern MountPattern { get; set; }
        public bool RequiresStandaloneECU { get; set; }
        public bool IsPlugAndPlay { get; set; }
        public double Dimension { get; set; }
        public double Weight { get; set; }
        
        public ICollection<SwapCompatibility> SwapCompatibilities { get; set; } = new List<SwapCompatibility>();

    }
}