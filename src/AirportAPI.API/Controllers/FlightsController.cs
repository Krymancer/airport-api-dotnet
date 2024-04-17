using Application.Flights.Commands.CreateFlight;
using Application.Flights.Queries.GetFlight;
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

    [HttpPost]
    public async Task<IActionResult> CreateFlight(CreateFlightRequest request)
    {
        var command = new CreateFlightCommand(
            request.OriginIATACode,
            request.DestinationIATACode,
            request.Departure,
            request.Arrival);

        var createFlightResult = await _mediator.Send(command);

        return createFlightResult.MatchFirst(
            flight => Ok(new CreateFlightResponse(flight.Number)),
            error => Problem(error.Description)
        );
    }

    [HttpGet("{flightId:guid}")]
    public async Task<IActionResult> GetFlight(Guid flightId)
    {
        var query = new GetFlightQuery(flightId);
        var getFlightResult = await _mediator.Send(query);

        return getFlightResult.MatchFirst(
            flight => Ok(new FlightResponse(flight.Number, flight.Departure, flight.Arrival)),
            error => Problem(error.Description)
        );
    }
}