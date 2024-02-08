using TryBets.DTO;

namespace TryBets.Repository;

public class TeamRepository : ITeamRepository
{
    protected readonly ITryBetsContext _context;
    public TeamRepository(ITryBetsContext context)
    {
        _context = context;
    }

    public IEnumerable<TeamDTOResponse> Get()
    {
        return _context.Teams.Select(t => new TeamDTOResponse {
            TeamId = t.TeamId,
            TeamName = t.TeamName
        }).ToList();
    }
}