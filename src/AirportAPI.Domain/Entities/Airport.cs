﻿namespace Domain.Entities;

public class Airport
{
    public Airport(string iataCode, string name, Guid? id = null)
    {
        IATACode = iataCode;
        Name = name;
        Id = id ?? Guid.NewGuid();
    }

    private Airport()
    {
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string IATACode { get; private set; }
    public Guid CityId { get; private set; }

    public virtual City? City { get; private set; }
}