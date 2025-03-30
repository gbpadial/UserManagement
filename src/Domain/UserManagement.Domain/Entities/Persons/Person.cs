using System;

namespace UserManagement.Domain.Entities.Persons;

public abstract class Person
{
    protected Person(string name, string postalCode, string? address)
    {
        Name = name;
        ZipCode = postalCode;
        Address = address;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ZipCode { get; set; }
    public string? Address { get; set; }
}
