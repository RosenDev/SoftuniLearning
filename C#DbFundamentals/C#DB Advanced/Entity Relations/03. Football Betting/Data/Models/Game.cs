namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Games")]
    public class Game
    {
        public Game()
        {
            Bets = new List<Bet>();
            PlayerStatistics = new List<PlayerStatistic>();
        }

        [Key]
        public int GameId { get; set; }

        public double AwayTeamBetRate { get; set; }

        public int AwayTeamGoals { get; set; }

        public int AwayTeamId { get; set; }
        [ForeignKey(nameof(AwayTeamId))]
        public Team AwayTeam { get; set; }

        public double DrawBetRate { get; set; }

        public double HomeTeamBetRate { get; set; }

        public int HomeTeamGoals { get; set; }

        public int HomeTeamId { get; set; }
        [ForeignKey(nameof(HomeTeamId))]
        public Team HomeTeam { get; set; }

        public string Result => $"{HomeTeamGoals}:{AwayTeamGoals}";

        public DateTime DateTime { get; set; }

        public ICollection<Bet> Bets { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}