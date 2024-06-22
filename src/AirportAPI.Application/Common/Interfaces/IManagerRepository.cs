using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IManagerRepository
{
    Task AddManagerAsync(Manager manager);
    Task<IEnumerable<Manager>> ListManagers();
    Task<Manager?> GetByIdAsync(Guid managerId);
    Task UpdateManagerAsync(Manager manager);
    Task RemoveManagerAsync(Manager manager);
}