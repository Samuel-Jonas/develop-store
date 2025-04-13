using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly DefaultContext _context;

    public PersonRepository(DefaultContext context)
    {
        _context = context;
    }
    
    public async Task<Person> CreateAsync(Person person, CancellationToken cancellationToken = default)
    {
        await _context.People.AddAsync(person, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return person;
    }

    public async Task<Person?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.People
            .Where(p => p.DeletedAt == null)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task<List<Person>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.People
            .Where(p => p.DeletedAt == null)
            .ToListAsync(cancellationToken);
    }

    public async Task<Person> UpdatePersonTypeAsync(Guid id, PersonType personType, CancellationToken cancellationToken = default)
    {
        var existingPerson = await _context.People
            .Where(p => p.DeletedAt == null)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        if (existingPerson == null)
        {
            throw new Exception("Person not found");
        }
        
        existingPerson.Type = personType;
        existingPerson.UpdatedAt = DateTime.UtcNow;
        
        await _context.SaveChangesAsync(cancellationToken);
        return existingPerson;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var existingPerson = await _context.People
            .Where(p => p.DeletedAt == null)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        if (existingPerson == null)
        {
            return false;
        }
        
        existingPerson.DeletedAt = DateTime.UtcNow;
        existingPerson.UpdatedAt = DateTime.UtcNow;
        
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}