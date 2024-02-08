using TryBets.Matches.DTO;

namespace TryBets.Matches.Repository;

public interface IMatchRepository
{
    IEnumerable<MatchDTOResponse> Get(bool MatchFinished);
}