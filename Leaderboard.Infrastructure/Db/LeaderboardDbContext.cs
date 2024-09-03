using Leaderboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Leaderboard.Infrastructure.Db;

public class LeaderboardDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<TableActivity> Activities => Set<TableActivity>();
    public DbSet<TableScore> Scores => Set<TableScore>();
    public DbSet<TableUser> Users => Set<TableUser>();
}