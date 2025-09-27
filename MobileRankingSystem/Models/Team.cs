using System.Collections.Generic;
using System.Linq;

namespace MobileRankingSystem.Models;

public class Team
{
    public Team(string name, IEnumerable<Player> players)
    {
        Name = name;
        Players = players.ToList();
    }

    public string Name { get; }

    public IReadOnlyList<Player> Players { get; }

    public int TotalSkill => Players.Sum(p => p.SkillRating);
}
