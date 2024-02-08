namespace TryBets.Bets.Models;
using System.ComponentModel.DataAnnotations;

public class Team
{
    [Key]
    public int TeamId { get; set; }
    public string? TeamName { get; set; }
    public virtual ICollection<Match>? MatchesA { get; set;}
    public virtual ICollection<Match>? MatchesB { get; set;}
    public virtual ICollection<Bet>? Bets { get; set;}
}