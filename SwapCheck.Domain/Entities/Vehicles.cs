using SwapCheck.Domain.Enums;

namespace SwapCheck.Domain.Entities
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public MountPattern MountPattern { get; set; }
        public EngineSize EngineSize { get; set; }
        public ICollection<SwapCompatibility> SwapCompatibilities { get; set; } = new List<SwapCompatibility>();
    }
}