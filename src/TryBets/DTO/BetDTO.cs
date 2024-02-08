namespace TryBets.DTO;

public class BetDTORequest
{
    public int MatchId { get; set; }
    public int TeamId { get; set; }
    public decimal BetValue { get; set; }
}

public class BetDTOResponse
{
    public int BetId { get; set; }
    public int MatchId { get; set; }
    public int TeamId { get; set; }
    public decimal BetValue { get; set; }
    public DateTime MatchDate { get; set; }
    public string? TeamName { get; set; }
    public string? Email { get; set; }
}
