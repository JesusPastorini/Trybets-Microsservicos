using TryBets.DTO;

namespace TryBets.Repository;

public interface ITeamRepository
{
    IEnumerable<TeamDTOResponse> Get();    
}