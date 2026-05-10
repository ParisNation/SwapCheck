using SwapCheck.Domain.Enums;

namespace SwapCheck.Domain.Entities
{
    public class SwapCompatibility
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public virtual Vehicle? Vehicle { get; set; }
        public Guid EngineId { get; set; }
        public virtual Engine? Engine { get; set; }
        public bool IsCompatible { get; set; }
        public SwapDifficulty DifficultyLevel { get; set; }
        public string? Notes { get; set; }

    }
}