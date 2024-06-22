using ErrorOr;
using MediatR;

namespace Application.FlightClasses.Commands.DeleteFlightClassesCommand;

public record DeleteFlightClassCommand(Guid FlightClassId) : IRequest<ErrorOr<Deleted>>;