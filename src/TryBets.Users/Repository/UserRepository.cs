using TryBets.Users.Models;
using TryBets.Users.DTO;

namespace TryBets.Users.Repository;

public class UserRepository : IUserRepository
{
    protected readonly ITryBetsContext _context;
    public UserRepository(ITryBetsContext context)
    {
        _context = context;
    }

    public User Post(User user)
    {
        var newUser = _context.Users.Where(x => x.Email == user.Email);
        if (newUser.Count() > 0)
        {
            throw new Exception("E-mail already used");
        }

        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }
    public User Login(AuthDTORequest login)
    {
        var user = _context.Users.SingleOrDefault(x => x.Email == login.Email);

        if (user == null || user.Password != login.Password)
        {
            throw new Exception("Authentication failed");
        }

        return user;

    }
}