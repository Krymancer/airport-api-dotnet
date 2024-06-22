using Application.Flights.Commands.CreateFlight;
using Application.Flights.Commands.DeleteFlight;
using Application.Flights.Commands.UpdateFlight;
using Application.Flights.Queries.GetFlightById;
using Application.Flights.Queries.ListFlights;
using Contracts.Flights.Requests;
using Contracts.Flights.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightsController : Controller
{
    private readonly ISender _mediator;

    public FlightsController(ISender mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new ListFlightsQuery();
        var getFlightsResult = await _mediator.Send(query);

        return getFlightsResult.MatchFirst(
            flights => Ok(flights.Select(f => new FlightResponse(f.Number, f.Departure, f.Arrival))),
            error => Problem(error.Description)
        );
    }

    [HttpGet("{flightId:guid}")]
    public async Task<IActionResult> Get(Guid flightId)
    {
        var query = new GetFlightByIdQuery(flightId);
        var getFlightResult = await _mediator.Send(query);

        return getFlightResult.MatchFirst(
            flight => Ok(new FlightResponse(flight.Number, flight.Departure, flight.Arrival)),
            error => Problem(error.Description)
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFlightRequest request)
    {
        var command = new CreateFlightCommand(
            request.FlightNumber,
            request.OriginAirportId,
            request.DestinationAirportId,
            request.Departure,
            request.Arrival);

        var createFlightResult = await _mediator.Send(command);

        return createFlightResult.MatchFirst(
            flight => Ok(new CreateFlightResponse(flight.Number)),
            error => Problem(error.Description)
        );
    }

    [HttpPost("{flightId:guid}")]
    public async Task<IActionResult> Update(Guid flightId)
    {
        var command = new UpdateFlightCommand(flightId);
        var updateFlightResult = await _mediator.Send(command);

        return updateFlightResult.Match<IActionResult>(
            _ => NoContent(),
            _ => Problem()
        );
    }

    [HttpDelete("{flightId:guid}")]
    public async Task<IActionResult> Delete(Guid flightId)
    {
        var command = new DeleteFlightCommand(flightId);
        var deleteFlightResult = await _mediator.Send(command);

        return deleteFlightResult.Match<IActionResult>(
            _ => NoContent(),
            _ => Problem()
        );
    }
}