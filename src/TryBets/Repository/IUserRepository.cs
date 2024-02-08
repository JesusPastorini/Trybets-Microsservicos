using TryBets.DTO;
using TryBets.Models;

namespace TryBets.Repository;

public interface IUserRepository
{
    User Post(User user);
    User Login(AuthDTORequest login);
}