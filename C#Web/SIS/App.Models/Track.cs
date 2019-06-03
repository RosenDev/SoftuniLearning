using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    public class Track
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public decimal Price { get; set; }
        public Guid AlbumId { get; set; }
        [ForeignKey(nameof(AlbumId))]
        public Album Album { get; set; }


    }
}