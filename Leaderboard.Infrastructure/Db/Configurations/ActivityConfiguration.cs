using Leaderboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leaderboard.Infrastructure.Db.Configurations;

public class ActivityConfiguration : IEntityTypeConfiguration<TableActivity>
{
    public void Configure(EntityTypeBuilder<TableActivity> builder)
    {
        builder.AddId();

        builder.Property(x => x.Name)
            .IsRequired();
        
        builder.AddUserUpdatedAndCreated();
        builder.AddDateUpdatedAndCreated();
    }
}