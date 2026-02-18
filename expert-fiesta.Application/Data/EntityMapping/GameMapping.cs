using expert_fiesta.Application.Data.ValueConverters;
using expert_fiesta.Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace expert_fiesta.Application.Data.EntityMapping;

public class GameMapping : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder
            .ToTable("Games")
            .HasKey(g => g.Id);

        builder
            .Property(g => g.Name)
            .HasMaxLength(128)
            .IsRequired();

        builder
            .Property(g => g.Description)
            .HasMaxLength(255);

        builder
            .Property(g => g.PlayHours)
            .HasDefaultValue(2);

        builder
            .Property(g => g.ReleaseDate)
            .HasColumnType("character(8)")
            .HasConversion(new DateConverter());
    }
}