using System;

namespace App.ViewModels.TrackViewModels
{
    public class TrackDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public decimal Price { get; set; }
        public string AlbumId { get; set; }
    }
}