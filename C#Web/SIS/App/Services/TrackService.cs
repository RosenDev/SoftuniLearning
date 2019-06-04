using System;
using System.Linq;
using App.Data;
using App.ViewModels.TrackViewModels;

namespace App.Services
{
    public class TrackService:ITrackService
    {
        public TrackDetailsViewModel GetTrack(Guid id)
        {
            using (var context= new AppDbContext())
            {
                var track = context.Tracks.SingleOrDefault(x => x.Id == id);
                return new TrackDetailsViewModel
                {
                    Id = track.Id.ToString(),
                    AlbumId = track.AlbumId.ToString(),
                    Link = track.Link,
                    Name = track.Name,
                    Price = track.Price
                };
            }
        }

    }
}