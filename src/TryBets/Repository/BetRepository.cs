using TryBets.DTO;
using TryBets.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TryBets.Repository;

public class BetRepository : IBetRepository
{
    protected readonly ITryBetsContext _context;
    public BetRepository(ITryBetsContext context)
    {
        _context = context;
    }

    public BetDTOResponse Post(BetDTORequest betRequest, string email)
    {
        User findedUser = _context.Users.FirstOrDefault(x => x.Email == email)!;
        if (findedUser == null) throw new Exception("User not founded");

        Match findedMatch = _context.Matches.FirstOrDefault(m => m.MatchId == betRequest.MatchId)!;
        if (findedMatch == null) throw new Exception("Match not founded");

        Team findedTeam = _context.Teams.FirstOrDefault(t => t.TeamId == betRequest.TeamId)!;
        if (findedTeam == null) throw new Exception("Team not founded");

        if (findedMatch.MatchFinished) throw new Exception("Match finished");

        if (findedMatch.MatchTeamAId != betRequest.TeamId && findedMatch.MatchTeamBId != betRequest.TeamId ) throw new Exception("Team is not in this match");

        Bet newBet = new Bet
        {
            UserId = findedUser.UserId,
            MatchId = betRequest.MatchId,
            TeamId = betRequest.TeamId,
            BetValue = betRequest.BetValue
        };
        _context.Bets.Add(newBet);
        _context.SaveChanges();

        Bet createdBet = _context.Bets.Include(b => b.Team).Include(b => b.Match).Where(b => b.BetId == newBet.BetId).FirstOrDefault()!;
        
        if (findedMatch.MatchTeamAId == betRequest.TeamId) findedMatch.MatchTeamAValue += betRequest.BetValue;
        else findedMatch.MatchTeamBValue += betRequest.BetValue;
        _context.Matches.Update(findedMatch);
        _context.SaveChanges();

        return new BetDTOResponse
        {
            BetId = createdBet.BetId,
            MatchId = createdBet.MatchId,
            TeamId = createdBet.TeamId,
            BetValue = createdBet.BetValue,
            MatchDate = createdBet.Match!.MatchDate,
            TeamName = createdBet.Team!.TeamName,
            Email = createdBet.User!.Email
        };
    }
    public BetDTOResponse Get(int BetId, string email)
    {
        User findedUser = _context.Users.FirstOrDefault(x => x.Email == email)!;
        if (findedUser == null) throw new Exception("User not founded");

        Bet findedBet = _context.Bets.Include(b => b.Team).Include(b => b.Match).Where(b => b.BetId == BetId).FirstOrDefault()!;
        if (findedBet == null) throw new Exception("Bet not founded");

        if (findedBet.User!.Email != email) throw new Exception("Bet view not allowed");

         return new BetDTOResponse
        {
            BetId = findedBet.BetId,
            MatchId = findedBet.MatchId,
            TeamId = findedBet.TeamId,
            BetValue = findedBet.BetValue,
            MatchDate = findedBet.Match!.MatchDate,
            TeamName = findedBet.Team!.TeamName,
            Email = findedBet.User!.Email
        };
    }
}