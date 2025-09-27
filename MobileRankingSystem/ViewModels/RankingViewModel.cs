using System.Collections.Generic;
using System.Collections.ObjectModel;
using MobileRankingSystem.Models;
using MobileRankingSystem.Services;

namespace MobileRankingSystem.ViewModels;

public class RankingViewModel
{
    public RankingViewModel()
    {
        var rankingService = new RankingService();

        var players = new List<Player>
        {
            new("Alice", 85),
            new("Bob", 78),
            new("Charlie", 90),
            new("Diana", 72),
            new("Evelyn", 88),
            new("Frank", 80),
            new("Grace", 76),
            new("Hector", 83)
        };

        var teams = rankingService.CreateBalancedTeams(players);

        var matches = new List<MatchResult>
        {
            new(teams[0], teams[1], teams[0], 21, 17),
            new(teams[2], teams[3], teams[3], 18, 21),
            new(teams[0], teams[2], teams[0], 25, 20),
            new(teams[1], teams[3], teams[3], 19, 21),
            new(teams[0], teams[3], null, 22, 22)
        };

        RankedTeams = new ObservableCollection<TeamRanking>(
            rankingService.GenerateRankings(matches));
    }

    public ObservableCollection<TeamRanking> RankedTeams { get; }
}
