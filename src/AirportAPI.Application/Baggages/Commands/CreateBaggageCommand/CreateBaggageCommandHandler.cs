using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Validators;
using ErrorOr;
using MediatR;

namespace Application.Baggages.Commands.CreateBaggageCommand;

public class CreateBaggageCommandHandler : IRequestHandler<CreateBaggageCommand, ErrorOr<Baggage>>
{
    private readonly IBaggageRepository _airportRepository;
    private readonly IUnityOfWork _unityOfWork;

    public CreateBaggageCommandHandler(IBaggageRepository airportRepository, IUnityOfWork unityOfWork)
    {
        _airportRepository = airportRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Baggage>> Handle(CreateBaggageCommand request, CancellationToken cancellationToken)
    {
        var baggage = new Baggage(request.Identification, request.TicketId);
        var validator = new BaggageValidator();

        var validationResult = await validator.ValidateAsync(baggage, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .ConvertAll(error => Error.Validation(
                    error.PropertyName,
                    error.ErrorMessage));

            return errors;
        }

        await _airportRepository.AddBaggageAsync(baggage);
        await _unityOfWork.CommitChangesAsync();

        return baggage;
    }
}