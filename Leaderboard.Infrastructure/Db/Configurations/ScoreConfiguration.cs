using Leaderboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leaderboard.Infrastructure.Db.Configurations;

public class ScoreConfiguration : IEntityTypeConfiguration<TableScore>
{
    public void Configure(EntityTypeBuilder<TableScore> builder)
    {
        builder.AddId();
        
        builder.Property(x => x.ActivityId)
            .IsRequired();

        builder.HasOne(x => x.Activity)
            .WithMany()
            .HasForeignKey(x => x.ActivityId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.AddUserUpdatedAndCreated();
        builder.AddDateUpdatedAndCreated();
    }
}