using FluentValidation;
using SwapCheck.Application.Queries.GetCompatibleEngines;

namespace SwapCheck.Application.Validators
{
    public class GetCompatibleEnginesValidator : AbstractValidator<GetCompatibleEnginesQuery>
    {
        public GetCompatibleEnginesValidator()
        {
            RuleFor(x => x.VehicleId)
                .NotEmpty()
                .WithMessage("VehicleId is required");   
        }
    }
}