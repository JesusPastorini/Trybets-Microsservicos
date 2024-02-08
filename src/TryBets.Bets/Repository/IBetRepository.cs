using TryBets.Bets.DTO;
using TryBets.Bets.Models;

namespace TryBets.Bets.Repository;

public interface IBetRepository
{
    BetDTOResponse Post(BetDTORequest betRequest, string email);
    BetDTOResponse Get(int BetId, string email);
}