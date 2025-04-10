using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class RegularPerson : BaseEntity
{
    public Person Person { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string City { get; set; }

    public string Street { get; set; }

    public string Number { get; set; }

    public string Zipcode { get; set; }

    public NetTopologySuite.Geometries.Point? Geolocation { get; set; }

    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}