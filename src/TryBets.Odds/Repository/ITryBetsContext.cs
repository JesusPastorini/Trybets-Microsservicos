using TryBets.Odds.Models;
using Microsoft.EntityFrameworkCore;

namespace TryBets.Odds.Repository;

public interface ITryBetsContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Team> Teams { get; set;}
    public DbSet<Match> Matches { get; set;}
    public DbSet<Bet> Bets { get; set; }
    public int SaveChanges();
}