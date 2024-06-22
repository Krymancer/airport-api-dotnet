using Application.Airports.Commands.CreateAirportCommand;
using Application.Airports.Commands.DeleteAirportCommand;
using Application.Airports.Queries.ListAirportsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AirportsController : Controller
{
    private readonly ISender _mediator;

    public AirportsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new ListAirportsQuery();
        var result = await _mediator.Send(query);

        return result.Match(
            airports => Ok(airports),
            _ => Problem()
        );
    }

    [HttpGet("{airportId:guid}")]
    public async Task<IActionResult> Get(Guid airportId)
    {
        var query = new GetAirportByIdQuery(airportId);
        var result = await _mediator.Send(query);

        return result.Match(
            airport => Ok(airport),
            _ => Problem()
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAirportRequest request)
    {
        var command = new CreateAirportCommand(
            request.IATACode,
            request.Name,
            request.CityId
        );

        var result = await _mediator.Send(command);

        return result.Match(
            airport => CreatedAtAction(nameof(Get), new { airportId = airport.Id }, airport),
            _ => Problem()
        );
    }

    [HttpPost("{airportId:guid}")]
    public async Task<IActionResult> Update(Guid airportId, UpdateAirportRequest request)
    {
        var command = new UpdateAirportCommand(airportId, request.Name, request.IATACode);

        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            _ => NoContent(),
            _ => Problem()
        );
    }

    [HttpDelete("{airportId:guid}")]
    public async Task<IActionResult> Delete(Guid airportId)
    {
        var command = new DeleteAirportCommand(airportId);

        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            _ => NoContent(),
            _ => Problem()
        );
    }
}