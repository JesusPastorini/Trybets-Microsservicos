using TryBets.DTO;

namespace TryBets.Repository;

public interface IMatchRepository
{
    IEnumerable<MatchDTOResponse> Get(bool MatchFinished);
}