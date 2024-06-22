using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagersController : Controller
{
    private readonly ISender _mediator;

    public ManagersController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new ListManagersQuery();
        var result = await _mediator.Send(query);

        return result.Match(
            managers => Ok(managers),
            _ => Problem()
        );
    }

    [HttpGet("{managerId:guid}")]
    public async Task<IActionResult> Get(Guid managerId)
    {
        var query = new GetManagerByIdQuery(managerId);
        var result = await _mediator.Send(query);

        return result.Match(
            manager => Ok(manager),
            _ => Problem()
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateManagerRequest request)
    {
        var command = new CreateManagerCommand(
            request.Name,
            request.CPF,
            request.Email,
            request.Username,
            request.Password,
            request.BirthDate
        );

        var result = await _mediator.Send(command);

        return result.Match(
            manager => CreatedAtAction(nameof(Get), new { managerId = manager.Id }, manager),
            _ => Problem()
        );
    }

    [HttpPost("{managerId:guid}")]
    public async Task<IActionResult> Update(Guid managerId, UpdateManagerRequest request)
    {
        var command = new UpdateManagerCommand(managerId, request.Name, request.CPF, request.Email, request.Username);

        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            _ => NoContent(),
            _ => Problem()
        );
    }

    [HttpDelete("{managerId:guid}")]
    public async Task<IActionResult> Delete(Guid managerId)
    {
        var command = new DeleteManagerCommand(managerId);

        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            _ => NoContent(),
            _ => Problem()
        );
    }
}