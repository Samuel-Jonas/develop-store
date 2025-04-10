using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IRegularPersonRepository
{
    Task<RegularPerson> CreateAsync(RegularPerson person, CancellationToken cancellationToken = default);
    
    Task<RegularPerson?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<List<RegularPerson>> GetAllAsync(CancellationToken cancellationToken = default);
    
    Task<RegularPerson> UpdateAsync(RegularPerson person, CancellationToken cancellationToken = default);
    
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}