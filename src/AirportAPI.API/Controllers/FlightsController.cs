using Airport.Contracts.Flights.Requests;
using Airport.Contracts.Flights.Responses;
using Application.Flights.Commands.CreateFlight;
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
            request.DestiantionIATACode,
            request.Departure,
            request.Arrival);

        var createFlightResponse = await _mediator.Send(command);

        if (createFlightResponse.IsError)
        {
            return Problem();
        }

        var response = new CreateFlightResponse(createFlightResponse.Value);
        return Ok(response);
    }
}