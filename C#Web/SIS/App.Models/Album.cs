using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cover { get; set; }
        public decimal Price { get; set; }
        public List<Track> Tracks { get; set; }

        public Album()
        {
            Tracks=new List<Track>();
        }
      }
}