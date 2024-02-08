namespace TryBets.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Bet
{
    [Key]
    public int BetId { get; set; }
    
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public int MatchId { get; set; }
    [ForeignKey("MatchId")]
    public int TeamId { get; set; }
    [ForeignKey("TeamId")]
    public decimal BetValue { get; set; }
    public virtual User? User { get; set; }
    public virtual Match? Match { get; set;}
    public virtual Team? Team { get; set; }
}
