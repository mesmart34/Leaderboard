using Leaderboard.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Leaderboard.Application.Entities.Score.AddScoreCommand;

public class AddScoreCommand : IRequest<TableScore?>
{
    [FromRoute]
    public Guid ActivityId { get; set; }
    
    [FromBody]
    public Guid UserId { get; set; }
    [FromBody]
    public int Value { get; set; }
    [FromBody]
    public DateTime PeriodStart { get; set; }
    [FromBody]
    public DateTime PeriodEnd { get; set; }
}