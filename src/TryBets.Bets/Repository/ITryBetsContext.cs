using TryBets.Bets.Models;
using Microsoft.EntityFrameworkCore;

namespace TryBets.Bets.Repository;

public interface ITryBetsContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Team> Teams { get; set;}
    public DbSet<Match> Matches { get; set;}
    public DbSet<Bet> Bets { get; set; }
    public int SaveChanges();
}