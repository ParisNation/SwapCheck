using SwapCheck.Domain.Enums;

namespace SwapCheck.Application.DTOs
{
    public record VehicleDto (Guid Id, string Make, string Model, int Year);
    public record EngineDto (Guid Id, string EngineName, string Manufacturer, MountPattern MountPattern, EngineSize EngineSize);
    public record SwapCompatibilityDto (Guid Id, VehicleDto Vehicle, EngineDto Engine, bool IsCompatible, SwapDifficulty Difficulty, string Notes);

}