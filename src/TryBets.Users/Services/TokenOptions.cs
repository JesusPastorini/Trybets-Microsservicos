namespace TryBets.Users.Services;

public class TokenOptions
{
    public const string Token = "token";
    public string? Secret { get; set; }
    public int ExpiresDay { get; set; }
}