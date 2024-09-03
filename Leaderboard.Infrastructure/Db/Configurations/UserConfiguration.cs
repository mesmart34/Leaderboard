using Leaderboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leaderboard.Infrastructure.Db.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<TableUser>
{
    public void Configure(EntityTypeBuilder<TableUser> builder)
    {
        builder.ToTable("users");
        
        builder.Property(x => x.FirstName);
        builder.Property(x => x.LastName);
        builder.Property(x => x.Email);
        builder.Property(x => x.Password);
        builder.Property(x => x.IsAdmin);
        
        builder.AddDateUpdatedAndCreated();
    }
}