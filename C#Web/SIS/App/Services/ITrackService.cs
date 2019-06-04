using System;
using App.ViewModels.TrackViewModels;

namespace App.Services
{
    public interface ITrackService
    {
        TrackDetailsViewModel GetTrack(Guid id);

    }
}