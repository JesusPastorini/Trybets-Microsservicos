namespace TryBets.DTO;
public class MatchDTOResponse
{
    public int MatchId { get; set; }
    public DateTime MatchDate { get; set; }
    public int MatchTeamAId { get; set; }
    public int MatchTeamBId { get; set; }
    public string? TeamAName { get; set; }
    public string? TeamBName { get; set; }
    public string? MatchTeamAOdds { get; set;}
    public string? MatchTeamBOdds { get; set;}
    public bool MatchFinished { get; set;}
    public int? MatchWinnerId { get; set; }
}