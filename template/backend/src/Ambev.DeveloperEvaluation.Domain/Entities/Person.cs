using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Person : BaseEntity
{
    public Guid UserId { get; set; }

    public PersonType Type { get; set; }
    
    public User User { get; set; } = default!;
    public RegularPerson? RegularPerson { get; set; }
}