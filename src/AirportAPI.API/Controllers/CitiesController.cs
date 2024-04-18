using Application.Cities.Commands.CreateCity;
using Application.Cities.Queries.GetCitiesQuery;
using Contracts.Cities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class CitiesController : Controller
{
    private readonly ISender _mediator;

    public CitiesController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var getCititesQuery = new GetCitiesQuery();
        var getCitiesQueryResult = await _mediator.Send(getCititesQuery);

        return getCitiesQueryResult.Match(
            cities => Ok(cities),
            err => Problem()
        );
    }

    [HttpGet("{cityId:guid}")]
    public async Task<IActionResult> Get(Guid cityId)
    {
        return Ok(cityId);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCityRequest request)
    {
        var createCityCommand = new CreateCityCommand(
            request.Name,
            request.UF
        );

        var createCityCommandResult = await _mediator.Send(createCityCommand);

        return createCityCommandResult.Match(
            city => CreatedAtAction(nameof(Get), new { cityId = city.Id }, city),
            err => Problem()
        );
    }

    [HttpDelete("{cityId:guid}")]
    public async Task<IActionResult> Delete(Guid cityId)
    {
        return NoContent();
    }
}