using System.Collections.Generic;
using App.Models;
using App.ViewModels.TrackViewModels;

namespace App.ViewModels.AlbumViewModels
{
    public class AlbumDetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }
        
        public string Cover { get; set; }

        public decimal Price { get; set; }
        public List<TrackDetailsViewModel> Tracks { get; set; }=new List<TrackDetailsViewModel>();

    }
}