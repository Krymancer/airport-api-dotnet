using Application.FlightClasses.Commands.CreateFlightClassesCommand;
using Application.FlightClasses.Commands.DeleteFlightClassesCommand;
using Application.FlightClasses.Commands.UpdateFlightClassesCommand;
using Application.FlightClasses.Queries.GetFlightClassesByIdQuery;
using Application.FlightClasses.Queries.ListFlightClassesQuery;
using Contracts.FlightClasses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightClassesController : Controller
{
    private readonly ISender _mediator;

    public FlightClassesController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new ListFlightClassesQuery();
        var result = await _mediator.Send(query);

        return result.Match(
            flightClasses => Ok(flightClasses),
            _ => Problem()
        );
    }

    [HttpGet("{flightClassId:guid}")]
    public async Task<IActionResult> Get(Guid flightClassId)
    {
        var query = new GetFlightClassByIdQuery(flightClassId);
        var result = await _mediator.Send(query);

        return result.Match(
            flightClass => Ok(flightClass),
            _ => Problem()
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFlightClassRequest request)
    {
        var command = new CreateFlightClassCommand(
            request.FlightClass,
            request.Seats,
            request.SeatPrice,
            request.FlightId
        );

        var result = await _mediator.Send(command);

        return result.Match(
            flightClass => CreatedAtAction(nameof(Get), new { flightClassId = flightClass.Id }, flightClass),
            _ => Problem()
        );
    }

    [HttpPost("{flightClassId:guid}")]
    public async Task<IActionResult> Update(Guid flightClassId, UpdateFlightClassRequest request)
    {
        var command = new UpdateFlightClassCommand(flightClassId, request.FlightClass, request.Seats, request.SeatPrice,
            request.FlightId);

        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            _ => NoContent(),
            _ => Problem()
        );
    }

    [HttpDelete("{flightClassId:guid}")]
    public async Task<IActionResult> Delete(Guid flightClassId)
    {
        var command = new DeleteFlightClassCommand(flightClassId);

        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            _ => NoContent(),
            _ => Problem()
        );
    }
}