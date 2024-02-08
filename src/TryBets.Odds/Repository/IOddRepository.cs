using TryBets.Odds.Models;

namespace TryBets.Odds.Repository;

public interface IOddRepository
{
    Match Patch(int MatchId, int TeamId, string BetValue);
}