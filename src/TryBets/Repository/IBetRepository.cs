using TryBets.DTO;
using TryBets.Models;

namespace TryBets.Repository;

public interface IBetRepository
{
    BetDTOResponse Post(BetDTORequest betRequest, string email);
    BetDTOResponse Get(int BetId, string email);
}