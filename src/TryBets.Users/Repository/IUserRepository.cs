using TryBets.Users.DTO;
using TryBets.Users.Models;

namespace TryBets.Users.Repository;

public interface IUserRepository
{
    User Post(User user);
    User Login(AuthDTORequest login);
}