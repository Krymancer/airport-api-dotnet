using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PassengersController : Controller
{
    private readonly ISender _mediator;

    public PassengersController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new ListPassengersQuery();
        var result = await _mediator.Send(query);

        return result.Match(
            passengers => Ok(passengers),
            _ => Problem()
        );
    }

    [HttpGet("{passengerId:guid}")]
    public async Task<IActionResult> Get(Guid passengerId)
    {
        var query = new GetPassengerByIdQuery(passengerId);
        var result = await _mediator.Send(query);

        return result.Match(
            passenger => Ok(passenger),
            _ => Problem()
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePassengerRequest request)
    {
        var command = new CreatePassengerCommand(
            request.Name,
            request.CPF,
            request.Email,
            request.BirthDate
        );

        var result = await _mediator.Send(command);

        return result.Match(
            passenger => CreatedAtAction(nameof(Get), new { passengerId = passenger.Id }, passenger),
            _ => Problem()
        );
    }

    [HttpPost("{passengerId:guid}")]
    public async Task<IActionResult> Update(Guid passengerId, UpdatePassengerRequest request)
    {
        var command = new UpdatePassengerCommand(passengerId, request.Name, request.CPF, request.Email);

        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            _ => NoContent(),
            _ => Problem()
        );
    }

    [HttpDelete("{passengerId:guid}")]
    public async Task<IActionResult> Delete(Guid passengerId)
    {
        var command = new DeletePassengerCommand(passengerId);

        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            _ => NoContent(),
            _ => Problem()
        );
    }
}