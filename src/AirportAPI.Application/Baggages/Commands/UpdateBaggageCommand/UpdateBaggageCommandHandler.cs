using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Baggages.Commands.UpdateBaggageCommand;

public class UpdateBaggageCommandHandler : IRequestHandler<UpdateBaggageCommand, ErrorOr<Updated>>
{
    private readonly IBaggageRepository _baggageRepository;
    private readonly IUnityOfWork _unityOfWork;

    public UpdateBaggageCommandHandler(IBaggageRepository baggageRepository, IUnityOfWork unityOfWork)
    {
        _baggageRepository = baggageRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Updated>> Handle(UpdateBaggageCommand request, CancellationToken cancellationToken)
    {
        var baggage = await _baggageRepository.GetByIdAsync(request.BaggageId);

        if (baggage is null) return Error.NotFound();

        baggage.Update(request.Identification);

        await _baggageRepository.UpdateBaggageAsync(baggage);
        await _unityOfWork.CommitChangesAsync();

        return Result.Updated;
    }
}