using MobileRankingSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace MobileRankingSystem.Services;

public class RankingService
{
    public IReadOnlyList<TeamRanking> GenerateRankings(IEnumerable<MatchResult> results)
    {
        var scores = new Dictionary<string, int>();
        var matchesPlayed = new Dictionary<string, int>();
        var teamLookup = new Dictionary<string, Team>();

        foreach (var result in results)
        {
            RegisterTeam(result.TeamA);
            RegisterTeam(result.TeamB);

            Increment(matchesPlayed, result.TeamA.Name);
            Increment(matchesPlayed, result.TeamB.Name);

            if (result.IsDraw)
            {
                AddPoints(result.TeamA.Name, 1);
                AddPoints(result.TeamB.Name, 1);
            }
            else if (result.Winner is not null)
            {
                AddPoints(result.Winner.Name, 3);
            }
        }

        return scores
            .Select(kvp =>
            {
                teamLookup.TryGetValue(kvp.Key, out var team);
                return new TeamRanking(
                    kvp.Key,
                    kvp.Value,
                    matchesPlayed.TryGetValue(kvp.Key, out var played) ? played : 0)
                { Team = team };
            })
            .OrderByDescending(r => r.Points)
            .ThenByDescending(r => r.AverageSkill)
            .Select((ranking, index) => ranking with { Rank = index + 1 })
            .ToList();

        void RegisterTeam(Team team)
        {
            if (!scores.ContainsKey(team.Name))
            {
                scores[team.Name] = 0;
            }

            teamLookup[team.Name] = team;
        }

        void AddPoints(string teamName, int points)
        {
            scores[teamName] = scores.TryGetValue(teamName, out var current) ? current + points : points;
        }

        static void Increment(IDictionary<string, int> dictionary, string teamName)
        {
            dictionary[teamName] = dictionary.TryGetValue(teamName, out var current) ? current + 1 : 1;
        }
    }

    public IReadOnlyList<Team> CreateBalancedTeams(IEnumerable<Player> players)
    {
        var orderedPlayers = players
            .OrderByDescending(p => p.SkillRating)
            .ToList();

        var teams = new List<Team>();
        int teamNumber = 1;

        while (orderedPlayers.Count >= 2)
        {
            var strongest = orderedPlayers.First();
            orderedPlayers.RemoveAt(0);

            var weakest = orderedPlayers.Last();
            orderedPlayers.RemoveAt(orderedPlayers.Count - 1);

            teams.Add(new Team($"Team {teamNumber++}", new[] { strongest, weakest }));
        }

        if (orderedPlayers.Any())
        {
            var fallbackTeam = teams.OrderBy(t => t.TotalSkill).FirstOrDefault();
            if (fallbackTeam is null)
            {
                teams.Add(new Team($"Team {teamNumber}", orderedPlayers.ToList()));
            }
            else
            {
                var updatedPlayers = fallbackTeam.Players.Concat(orderedPlayers).ToList();
                teams.Remove(fallbackTeam);
                teams.Add(new Team(fallbackTeam.Name, updatedPlayers));
            }
        }

        return teams;
    }
}

public record TeamRanking(string TeamName, int Points, int MatchesPlayed)
{
    public int Rank { get; init; }

    public string Summary => $"{Points} pts · {MatchesPlayed} matches";

    public string PlayersSummary => string.Join(", ", Team?.Players.Select(p => $"{p.Name} ({p.SkillRating})") ?? Enumerable.Empty<string>());

    public int AverageSkill => Team is null || !Team.Players.Any()
        ? 0
        : (int)Team.Players.Average(p => p.SkillRating);

    internal Team? Team { get; init; }
}
