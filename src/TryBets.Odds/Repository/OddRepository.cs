using TryBets.Odds.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Globalization;

namespace TryBets.Odds.Repository;

public class OddRepository : IOddRepository
{
    protected readonly ITryBetsContext _context;
    public OddRepository(ITryBetsContext context)
    {
        _context = context;
    }

    public Match Patch(int MatchId, int TeamId, string BetValue)
    {
        // Converter o valor da aposta para decimal
        decimal betDecimalValue = decimal.Parse(BetValue.Replace(",", "."), CultureInfo.InvariantCulture);

        // Encontrar a partida
        var match = _context.Matches.FirstOrDefault(m => m.MatchId == MatchId);
        if (match == null)
        {
            throw new Exception("Match not found");
        }

        // Encontrar a equipe
        var team = _context.Teams.FirstOrDefault(t => t.TeamId == TeamId);
        if (team == null)
        {
            throw new Exception("Team not found");
        }

        // Verificar se a equipe está na partida
        if (match.MatchTeamAId != TeamId && match.MatchTeamBId != TeamId)
        {
            throw new Exception("Team is not in this match");
        }

        // Atualizar os valores da partida de acordo com a equipe selecionada
        if (match.MatchTeamAId == TeamId)
        {
            match.MatchTeamAValue += betDecimalValue;
        }
        else
        {
            match.MatchTeamBValue += betDecimalValue;
        }

        // Atualizar a partida no banco de dados
        _context.Matches.Update(match);
        _context.SaveChanges();

        return match;
    }
}