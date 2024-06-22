using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Baggages.Commands.DeleteBaggageCommand;

public class DeleteBaggageCommandHandler : IRequestHandler<DeleteBaggageCommand, ErrorOr<Deleted>>
{
    private readonly IBaggageRepository _baggageRepository;
    private readonly IUnityOfWork _unityOfWork;

    public DeleteBaggageCommandHandler(IBaggageRepository baggageRepository, IUnityOfWork unityOfWork)
    {
        _baggageRepository = baggageRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteBaggageCommand request, CancellationToken cancellationToken)
    {
        var baggage = await _baggageRepository.GetByIdAsync(request.BaggageId);

        if (baggage is null) return Error.NotFound();

        await _baggageRepository.RemoveBaggageAsync(baggage);
        await _unityOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}