using ErrorOr;
using MediatR;

namespace Application.Baggages.Commands.DeleteBaggageCommand;

public record DeleteBaggageCommand(Guid BaggageId): IRequest<ErrorOr<Deleted>>;