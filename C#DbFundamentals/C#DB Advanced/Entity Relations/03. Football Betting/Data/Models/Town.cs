namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Towns")]
    public class Town
    {
        public Town()
        {
            Teams = new List<Team>();
        }

        [Key]
        public int TownId { get; set; }

        public int CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }

        public string Name { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}