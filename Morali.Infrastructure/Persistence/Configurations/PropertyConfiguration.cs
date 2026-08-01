using Morali.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Morali.Infrastructure.Persistence.Configurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.ToTable("Properties");
        
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Type)
            .IsRequired();
        
        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.Description)
            .IsRequired();
        
        builder.Property(e => e.Bedrooms)
            .IsRequired();
        
        builder.Property(e => e.Baths)
            .IsRequired();
        
        builder.Property(e => e.ParkingSpaces)
            .IsRequired();
        
        builder.Property(e => e.EnSuites)
            .IsRequired();
        
        builder.Property(e => e.RentPrice)
            .IsRequired();
        
        builder.Property(e => e.Currency)
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(e => e.CondoFee)
            .IsRequired();
        
        builder.Property(e => e.OtherFees)
            .IsRequired();
        
        builder.Property(e => e.IsActive)
            .IsRequired();
        
        builder.Property(e => e.UserId)
            .IsRequired();
        
        builder.Property(e => e.IsDeleted)
            .IsRequired();
        
        builder.Property(e => e.DeletedAt);
        
        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        builder.Property(e => e.UpdatedAt);
        
        builder
            .HasOne(e => e.User)
            .WithMany(e => e.Properties)
            .HasForeignKey(e => e.UserId)
            .IsRequired();
    }
}