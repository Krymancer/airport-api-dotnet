using Application.Cities.Commands.CreateCity;
using Application.Cities.Commands.DeleteCity;
using Application.Cities.Commands.UpdateCity;
using Application.Cities.Queries.GetCityById;
using Application.Cities.Queries.ListCities;
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
        var getCitiesQuery = new ListCitiesQuery();
        var getCitiesQueryResult = await _mediator.Send(getCitiesQuery);

        return getCitiesQueryResult.Match(
            cities => Ok(cities),
            _ => Problem()
        );
    }

    [HttpGet("{cityId:guid}")]
    public async Task<IActionResult> Get(Guid cityId)
    {
        var getCityByIdQuery = new GetCityByIdQuery(cityId);
        var getCityByIdQueryResult = await _mediator.Send(getCityByIdQuery);

        return getCityByIdQueryResult.Match(
            city => Ok(city),
            _ => Problem()
        );
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
            _ => Problem()
        );
    }

    [HttpPost("{cityId:guid}")]
    public async Task<IActionResult> Update(Guid cityId)
    {
        var updateCityCommand = new UpdateCityCommand(cityId);

        var updateCityCommandResult = await _mediator.Send(updateCityCommand);

        return updateCityCommandResult.Match<IActionResult>(
            _ => NoContent(),
            _ => Problem()
        );
    }

    [HttpDelete("{cityId:guid}")]
    public async Task<IActionResult> Delete(Guid cityId)
    {
        var deleteCityCommand = new DeleteCityCommand(cityId);

        var deleteCityCommandResult = await _mediator.Send(deleteCityCommand);

        return deleteCityCommandResult.Match<IActionResult>(
            _ => NoContent(),
            _ => Problem()
        );
    }
}