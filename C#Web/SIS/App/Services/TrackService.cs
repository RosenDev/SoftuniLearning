using System;
using System.Linq;
using App.Data;
using App.ViewModels.TrackViewModels;
using SIS.MvcFramework.Mapping;

namespace App.Services
{
    public class TrackService:ITrackService
    {
        public TrackDetailsViewModel GetTrack(Guid id)
        {
            using (var context= new AppDbContext())
            {
                var track = context.Tracks
                    .SingleOrDefault(x => x.Id == id)
                    .To<TrackDetailsViewModel>();
                return track;

            }
        }

    }
}