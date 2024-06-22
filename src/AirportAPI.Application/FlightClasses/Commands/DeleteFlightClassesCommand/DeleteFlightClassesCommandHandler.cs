using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.FlightClasses.Commands.DeleteFlightClassesCommand;

public class DeleteFlightClassCommandHandler : IRequestHandler<DeleteFlightClassCommand, ErrorOr<Deleted>>
{
    private readonly IFlightClassesRepository _flightClassRepository;
    private readonly IUnityOfWork _unityOfWork;

    public DeleteFlightClassCommandHandler(IFlightClassesRepository flightClassRepository, IUnityOfWork unityOfWork)
    {
        _flightClassRepository = flightClassRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteFlightClassCommand request, CancellationToken cancellationToken)
    {
        var flightClass = await _flightClassRepository.GetByIdAsync(request.FlightClassId);

        if (flightClass is null) return Error.NotFound();

        await _flightClassRepository.RemoveFlightClassAsync(flightClass);
        await _unityOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}