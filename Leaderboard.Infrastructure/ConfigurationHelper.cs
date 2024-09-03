using System.Linq.Expressions;
using Leaderboard.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leaderboard.Infrastructure;

public static class ConfigurationHelper
{
    public static void AddId<T>(this EntityTypeBuilder<T> builder)
        where T : class, IHasId
    {
        builder.Property(x => x.Id)
            .IsRequired();
    }
    
    public static void AddDateUpdatedAndCreated<T>(this EntityTypeBuilder<T> builder)
        where T : class, IHasDateCreatedAndUpdated
    {
        builder.Property(x => x.DateUpdated)
            .IsRequired();
        
        builder.Property(x => x.DateCreated)
            .IsRequired();
    }
    
    public static void AddUserUpdatedAndCreated<T>(this EntityTypeBuilder<T> builder)
        where T : class, IHasUserUpdatedAndCreated, IHasUserUpdatedAndCreatedReference
    {
        builder.Property(x => x.UserCreatedId)
            .IsRequired();

        builder.HasOne(x => x.UserCreated)
            .WithMany()
            .HasForeignKey(x => x.UserCreatedId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(x => x.UserUpdatedId)
            .IsRequired();
        
        builder.HasOne(x => x.UserUpdated)
            .WithMany()
            .HasForeignKey(x => x.UserUpdatedId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}