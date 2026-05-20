using SwapCheck.Domain.Enums;

namespace SwapCheck.Application.DTOs
{
    public record VehicleDto (Guid Id, string Make, string Model, int Year);
    public record EngineDto (Guid Id, string EngineName, string Manufacturer, MountPattern MountPattern, EngineSize EngineSize);

    public class SwapCompatibilityDto
    {
        public Guid Id { get; set; }
        public bool IsCompatible { get; set; }
        public SwapDifficulty DifficultyLevel { get; set; }
        public string? Notes { get; set; }
        public EngineDto? Engine { get; set; }
    }
}