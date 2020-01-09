namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Countries")]
    public class Country
    {
        public Country()
        {
            Towns = new List<Town>();
        }

        [Key]
        public int CountryId { get; set; }

        public string Name { get; set; }

        public List<Town> Towns { get; set; }
    }
}