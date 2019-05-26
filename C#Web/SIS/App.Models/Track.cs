using System;

namespace App.Models
{
    public class Track
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public decimal Price { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }


    }
}