using System.Text.Json;
using Leaderboard.Domain.Entities;
using Leaderboard.Infrastructure.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace Leaderboard.Application.Entities.User.Queries;

public class GetUserByIdQueryHandler(LeaderboardDbContext dbContext, IDistributedCache distributedCache) : IRequestHandler<GetUserByIdQuery, TableUser?>
{
    public async Task<TableUser?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var bytes = await distributedCache.GetAsync($"user-{request.Id}", cancellationToken);
        TableUser? user;
        if (bytes != null)
        {
            var userStream = new MemoryStream(bytes);
            user = await JsonSerializer.DeserializeAsync<TableUser>(userStream, cancellationToken: cancellationToken);
        }
        else
        { 
            user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        }
        return user;
    }
}
