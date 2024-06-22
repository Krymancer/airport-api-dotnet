using Domain.Entities;

namespace Application.Common.Interfaces;

public interface ITicketRepository
{
    Task AddTicketAsync(Ticket ticket);
    Task<IEnumerable<Ticket>> ListTickets();
    Task<Ticket?> GetByIdAsync(Guid ticketId);
    Task UpdateTicketAsync(Ticket ticket);
    Task RemoveTicketAsync(Ticket ticket);
}