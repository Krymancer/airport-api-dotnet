using Application.Tickets.Commands.CreateTicketCommand;
using Application.Tickets.Commands.DeleteTicketCommand;
using Application.Tickets.Commands.UpdateTicketCommand;
using Application.Tickets.Queries.GetTicketByIdQuery;
using Application.Tickets.Queries.ListTicketsQuery;
using Contracts.Tickets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketsController : Controller
{
    private readonly ISender _mediator;

    public TicketsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new ListTicketsQuery();
        var result = await _mediator.Send(query);

        return result.Match(
            tickets => Ok(tickets),
            _ => Problem()
        );
    }

    [HttpGet("{ticketId:guid}")]
    public async Task<IActionResult> Get(Guid ticketId)
    {
        var query = new GetTicketByIdQuery(ticketId);
        var result = await _mediator.Send(query);

        return result.Match(
            ticket => Ok(ticket),
            _ => Problem()
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTicketRequest request)
    {
        var command = new CreateTicketCommand(
            request.Identification,
            request.Price,
            request.SeatNumber,
            request.FlightId,
            request.PassengerId,
            request.LuggageCheckIn
        );

        var result = await _mediator.Send(command);

        return result.Match(
            ticket => CreatedAtAction(nameof(Get), new { ticketId = ticket.Id }, ticket),
            _ => Problem()
        );
    }

    [HttpPost("{ticketId:guid}")]
    public async Task<IActionResult> Update(Guid ticketId, UpdateTicketRequest request)
    {
        var command = new UpdateTicketCommand(ticketId, request.Identification, request.Price, request.SeatNumber,
            request.FlightId,
            request.PassengerId, request.LuggageCheckIn);

        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            _ => NoContent(),
            _ => Problem()
        );
    }

    [HttpDelete("{ticketId:guid}")]
    public async Task<IActionResult> Delete(Guid ticketId)
    {
        var command = new DeleteTicketCommand(ticketId);

        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            _ => NoContent(),
            _ => Problem()
        );
    }
}