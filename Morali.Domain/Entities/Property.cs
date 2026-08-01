using Morali.Domain.Enums;

namespace Morali.Domain.Entities;

public class Property
{
    public Guid Id { get; private set; }
    public PropertyType Type { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int Bedrooms { get; private set; }
    public int Baths { get; private set; }
    public int ParkingSpaces { get; private set; }
    public int EnSuites { get; private set; }
    public string Currency { get; private set; }
    public long RentPrice { get; private set; }
    public long CondoFee { get; private set; }
    public long OtherFees { get; private set; }
    public long TotalPrice { get; private set; }
    public bool AllowsPets { get; private set; }
    public string ZipCode { get; private set; }
    public string Number { get; private set; }
    public string Street { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Uf { get; private set; }
    public string Country { get; private set; }
    public string CountryCode { get; private set; }
    public Guid UserId { get; private set; }
    public bool IsActive { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    
    public User User { get; private set; }

    public static Property Create(
        PropertyType type,
        string title,
        string description,
        int bedrooms,
        int baths,
        int parkingSpaces,
        int enSuites,
        string currency,
        long rentPrice,
        long condoFee,
        long otherFees,
        long totalPrice,
        Guid userId,
        bool allowsPets,
        string zipCode,
        string number,
        string street,
        string neighborhood,
        string city,
        string state,
        string uf,
        string country,
        string countryCode
    )
        => new()
        {
            Id = Guid.NewGuid(),
            Type = type,
            Title = title,
            Description = description,
            Bedrooms =  bedrooms,
            Baths = baths,
            ParkingSpaces =  parkingSpaces,
            EnSuites =  enSuites,
            Currency = currency,
            RentPrice = rentPrice,
            CondoFee = condoFee,
            OtherFees = otherFees,
            TotalPrice = totalPrice,
            UserId = userId,
            AllowsPets =  allowsPets,
            ZipCode = zipCode,
            Number = number,
            Street = street,
            Neighborhood = neighborhood,
            City = city,
            State = state,
            Uf = uf,
            Country = country,
            CountryCode = countryCode,
            IsActive = true,
            IsDeleted = false,
            DeletedAt = null,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        };

    public void Delete()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;
        DeletedAt = DateTime.UtcNow;
    }

    public void ToggleActive()
    {
        IsActive = !IsActive;
    }
    
    private Property() {}
}