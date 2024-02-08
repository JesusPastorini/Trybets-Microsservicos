using TryBets.Matches.DTO;

namespace TryBets.Matches.Repository;

public interface ITeamRepository
{
    IEnumerable<TeamDTOResponse> Get();    
}