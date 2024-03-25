using TryBets.Bets.DTO;
using TryBets.Bets.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TryBets.Bets.Repository;

public class BetRepository : IBetRepository
{
    protected readonly ITryBetsContext _context;
    public BetRepository(ITryBetsContext context)
    {
        _context = context;
    }

    public BetDTOResponse Post(BetDTORequest betRequest, string email)
    {
        // Encontrar usuário
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        // Encontrar partida
        var match = _context.Matches.FirstOrDefault(m => m.MatchId == betRequest.MatchId);
        if (match == null)
        {
            throw new Exception("Match not found");
        }

        // Encontrar equipe
        var team = _context.Teams.FirstOrDefault(t => t.TeamId == betRequest.TeamId);
        if (team == null)
        {
            throw new Exception("Team not found");
        }

        // Verificar se a partida está finalizada
        if (match.MatchFinished)
        {
            throw new Exception("Match finished");
        }

        // Verificar se a equipe está na partida
        if (match.MatchTeamAId != betRequest.TeamId && match.MatchTeamBId != betRequest.TeamId)
        {
            throw new Exception("Team is not in this match");
        }

        // Criar nova aposta
        var newBet = new Bet
        {
            MatchId = betRequest.MatchId,
            TeamId = betRequest.TeamId,
            BetValue = betRequest.BetValue,
            UserId = user.UserId
        };

        _context.Bets.Add(newBet);
        _context.SaveChanges();

        // Atualizar valores da partida
        if (match.MatchTeamAId == betRequest.TeamId)
        {
            match.MatchTeamAValue += betRequest.BetValue;
        }
        else
        {
            match.MatchTeamBValue += betRequest.BetValue;
        }

        _context.Matches.Update(match);
        _context.SaveChanges();

        // Retornar a resposta da aposta
        return new BetDTOResponse
        {
            MatchId = newBet.MatchId,
            MatchDate = match.MatchDate,
            TeamId = newBet.TeamId,
            TeamName = team.TeamName,
            BetId = newBet.BetId,
            BetValue = newBet.BetValue,
            Email = user.Email
        };
    }
    public BetDTOResponse Get(int BetId, string email)
    {
        // Encontrar usuário
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        // Encontrar aposta
        var bet = _context.Bets
            .Include(b => b.Team)
            .Include(b => b.Match)
            .FirstOrDefault(b => b.BetId == BetId && b.UserId == user.UserId);

        if (bet == null)
        {
            throw new Exception("Bet not found");
        }

        // Verificar se o usuário tem permissão para ver esta aposta
        if (bet.User!.Email != email)
        {
            throw new Exception("Bet view not allowed");
        }

        // Retornar a resposta da aposta
        return new BetDTOResponse
        {
            MatchId = bet.MatchId,
            MatchDate = bet.Match!.MatchDate,
            TeamId = bet.TeamId,
            TeamName = bet.Team!.TeamName,
            BetId = bet.BetId,
            BetValue = bet.BetValue,
            Email = bet.User!.Email
        };
    }
}