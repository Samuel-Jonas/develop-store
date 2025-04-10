using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IPersonRepository
{
    Task<Person> CreateAsync(Person person, CancellationToken cancellationToken = default);
    
    Task<Person?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<List<Person>> GetAllAsync(CancellationToken cancellationToken = default);
    
    Task<Person> UpdatePersonTypeAsync(Guid id, PersonType personType, CancellationToken cancellationToken = default);
    
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}