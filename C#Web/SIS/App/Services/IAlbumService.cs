using System;
using System.Collections.Generic;
using App.Models;
using App.ViewModels;
using App.ViewModels.AlbumViewModels;
using App.ViewModels.TrackViewModels;

namespace App.Services
{
    public interface IAlbumService
    {
        Album CreateAlbum(AlbumCreateViewModel album);

        AlbumDetailsViewModel GetAlbum(Guid id);

        bool AddTrackToAlbum(Guid albumId, TrackCreateViewModel trackForDb);

        ICollection<AlbumAllViewModel> GetAll();
    }
}