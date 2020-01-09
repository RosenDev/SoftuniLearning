﻿namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Users")]
    public class User
    {
        public User()
        {
            Bets = new List<Bet>();
        }

        [Key]
        public int UserId { get; set; }

        public decimal Balance { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }
}
