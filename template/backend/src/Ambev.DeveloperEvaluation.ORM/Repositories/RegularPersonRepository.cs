using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class RegularPersonRepository : IRegularPersonRepository
{
    private readonly DefaultContext _context;

    public RegularPersonRepository(DefaultContext context)
    {
        _context = context;
    }
    
    public async Task<RegularPerson> CreateAsync(RegularPerson person, CancellationToken cancellationToken = default)
    {
        await _context.Regulars.AddAsync(person, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return person;
    }

    public async Task<RegularPerson?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Regulars
            .Where(rp => rp.DeletedAt != null)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task<List<RegularPerson>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Regulars
            .Where(rp => rp.DeletedAt != null)
            .ToListAsync(cancellationToken);
    }

    public async Task<RegularPerson> UpdateAsync(RegularPerson person, CancellationToken cancellationToken = default)
    {
        var existingRegularPerson = await _context.Regulars
            .AsTracking()
            .Where(rp => rp.DeletedAt != null)
            .FirstOrDefaultAsync(o => o.Id == person.Id, cancellationToken);

        if (existingRegularPerson == null)
        {
            throw new Exception("Regular Person not found");
        }

        if (existingRegularPerson.FirstName != person.FirstName)
        {
            existingRegularPerson.FirstName = person.FirstName;
        }

        if (existingRegularPerson.LastName != person.LastName)
        {
            existingRegularPerson.LastName = person.LastName;
        }

        if (existingRegularPerson.City != person.City)
        {
            existingRegularPerson.City = person.City;
        }

        if (existingRegularPerson.Street != person.Street)
        {
            existingRegularPerson.Street = person.Street;
        }

        if (existingRegularPerson.Number != person.Number)
        {
            existingRegularPerson.Number = person.Number;
        }

        if (existingRegularPerson.Zipcode != person.Zipcode)
        {
            existingRegularPerson.Zipcode = person.Zipcode;
        }

        if (existingRegularPerson.Geolocation != person.Geolocation)
        {
            existingRegularPerson.Geolocation = person.Geolocation;
        }
        
        existingRegularPerson.UpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync(cancellationToken);
        return existingRegularPerson;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var existingRegularPerson = await _context.Regulars
            .Where(rp => rp.DeletedAt != null)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        if (existingRegularPerson == null)
        {
            return false;
        }
        
        existingRegularPerson.DeletedAt = DateTime.Now;
        existingRegularPerson.UpdatedAt = DateTime.Now;
        
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}