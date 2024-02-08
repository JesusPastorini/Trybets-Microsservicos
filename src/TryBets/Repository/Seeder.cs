using TryBets.Models;
using TryBets.DTO;

namespace TryBets.Repository
{
    public class Seeder
    {
        public static void Seed(ITryBetsContext _context) {
            try 
            {
                var teamsCount = _context.Teams.Count();
                if (teamsCount == 0) 
                {
                    _context.Teams.Add(new Team{ TeamName = "Sharks" });
                    _context.Teams.Add(new Team{ TeamName = "Eagles" });
                    _context.Teams.Add(new Team{ TeamName = "Wolves" });
                    _context.Teams.Add(new Team{ TeamName = "Tigers" });
                    _context.Teams.Add(new Team{ TeamName = "Lions" });
                    _context.Teams.Add(new Team{ TeamName = "Dragons" });
                    _context.Teams.Add(new Team{ TeamName = "Snakes" });
                    _context.Teams.Add(new Team{ TeamName = "Bulls" });
                    _context.SaveChanges();
                }

                var matchesCount = _context.Matches.Count();
                if (matchesCount == 0)
                {
                    _context.Matches.Add(new Match{ MatchDate = new DateTime(2023, 07, 23, 15, 0, 0), MatchTeamAId = 1, MatchTeamBId = 8, MatchTeamAValue = 300, MatchTeamBValue = 700, MatchFinished = true, MatchWinnerId = 1});
                    _context.Matches.Add(new Match{ MatchDate = new DateTime(2023, 07, 24, 15, 0, 0), MatchTeamAId = 2, MatchTeamBId = 7, MatchTeamAValue = 450, MatchTeamBValue = 1800, MatchFinished = true, MatchWinnerId = 7});
                    _context.Matches.Add(new Match{ MatchDate = new DateTime(2023, 07, 25, 15, 0, 0), MatchTeamAId = 3, MatchTeamBId = 6, MatchTeamAValue = 7000, MatchTeamBValue = 5570, MatchFinished = true, MatchWinnerId = 3});
                    _context.Matches.Add(new Match{ MatchDate = new DateTime(2023, 07, 26, 15, 0, 0), MatchTeamAId = 4, MatchTeamBId = 5, MatchTeamAValue = 500, MatchTeamBValue = 500, MatchFinished = true, MatchWinnerId = 5});
                    _context.Matches.Add(new Match{ MatchDate = new DateTime(2024, 03, 15, 14, 0, 0), MatchTeamAId = 1, MatchTeamBId = 2, MatchTeamAValue = 300, MatchTeamBValue = 300, MatchFinished = false, MatchWinnerId = null});
                    _context.Matches.Add(new Match{ MatchDate = new DateTime(2024, 03, 16, 14, 0, 0), MatchTeamAId = 3, MatchTeamBId = 4, MatchTeamAValue = 300, MatchTeamBValue = 300, MatchFinished = false, MatchWinnerId = null});
                    _context.Matches.Add(new Match{ MatchDate = new DateTime(2024, 03, 17, 14, 0, 0), MatchTeamAId = 5, MatchTeamBId = 6, MatchTeamAValue = 300, MatchTeamBValue = 300, MatchFinished = false, MatchWinnerId = null});
                    _context.Matches.Add(new Match{ MatchDate = new DateTime(2024, 03, 18, 14, 0, 0), MatchTeamAId = 7, MatchTeamBId = 8, MatchTeamAValue = 300, MatchTeamBValue = 300, MatchFinished = false, MatchWinnerId = null});
                    _context.SaveChanges();
                }
            } catch (Exception ex) {
                Console.Write(ex.ToString());
            }
        }
    }
}