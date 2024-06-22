using Application.Airports.Queries.ListAirportsQuery;
using Application.Baggages.Commands.CreateBaggageCommand;
using Application.Baggages.Commands.DeleteBaggageCommand;
using Application.Baggages.Commands.UpdateBaggageCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BaggagesController : Controller
{
    private readonly ISender _mediator;

    public BaggagesController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new ListBaggagesQuery();
        var result = await _mediator.Send(query);

        return result.Match(
            baggage => Ok(baggage),
            _ => Problem()
        );
    }

    [HttpGet("{baggageId:guid}")]
    public async Task<IActionResult> Get(Guid baggageId)
    {
        var query = new GetBaggageByIdQuery(baggageId);
        var result = await _mediator.Send(query);

        return result.Match(
            baggage => Ok(baggage),
            _ => Problem()
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBaggageRequest request)
    {
        var command = new CreateBaggageCommand(
            request.Identification,
            request.TicketId
        );

        var result = await _mediator.Send(command);

        return result.Match(
            baggage => CreatedAtAction(nameof(Get), new { baggageId = baggage.Id }, baggage),
            _ => Problem()
        );
    }

    [HttpPost("{baggageId:guid}")]
    public async Task<IActionResult> Update(Guid baggageId, UpdateBaggageRequest request)
    {
        var command = new UpdateBaggageCommand(baggageId, request.Identification);

        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            _ => NoContent(),
            _ => Problem()
        );
    }

    [HttpDelete("{baggageId:guid}")]
    public async Task<IActionResult> Delete(Guid baggageId)
    {
        var command = new DeleteBaggageCommand(baggageId);

        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            _ => NoContent(),
            _ => Problem()
        );
    }
}