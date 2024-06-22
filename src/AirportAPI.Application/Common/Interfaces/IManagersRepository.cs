using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IManagersRepository
{
    Task AddManagerAsync(Manager manager);
    Task<IEnumerable<Manager>> ListManagers();
    Task<Manager?> GetByIdAsync(Guid managerId);
    Task UpdateManagerAsync(Manager manager);
    Task RemoveManagerAsync(Manager manager);
}