namespace MobileRankingSystem.Models;

public class MatchResult
{
    public MatchResult(Team teamA, Team teamB, Team? winner, int teamAScore, int teamBScore)
    {
        TeamA = teamA;
        TeamB = teamB;
        Winner = winner;
        TeamAScore = teamAScore;
        TeamBScore = teamBScore;
    }

    public Team TeamA { get; }
    public Team TeamB { get; }
    public Team? Winner { get; }
    public int TeamAScore { get; }
    public int TeamBScore { get; }

    public bool IsDraw => TeamAScore == TeamBScore;
}
