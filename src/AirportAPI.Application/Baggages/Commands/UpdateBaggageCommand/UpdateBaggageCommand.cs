using ErrorOr;
using MediatR;

namespace Application.Baggages.Commands.UpdateBaggageCommand;

public record UpdateBaggageCommand(Guid BaggageId, string Identification) : IRequest<ErrorOr<Updated>>;