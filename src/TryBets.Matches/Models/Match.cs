namespace TryBets.Matches.Models;
using System.ComponentModel.DataAnnotations;

public class Match
{
    [Key]
    public int MatchId { get; set; }
    public DateTime MatchDate { get; set; }
    public int MatchTeamAId { get; set; }
    public int MatchTeamBId { get; set; }
    public decimal MatchTeamAValue { get; set;}
    public decimal MatchTeamBValue { get; set;}
    public bool MatchFinished { get; set;}
    public int? MatchWinnerId { get; set; }

    public virtual Team? MatchTeamA { get; set; }
    public virtual Team? MatchTeamB { get; set; }
    public virtual ICollection<Bet>? Bets { get; set;}
    
    
}
