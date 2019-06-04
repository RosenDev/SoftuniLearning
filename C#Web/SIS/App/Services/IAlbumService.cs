using System;
using App.Models;
using App.ViewModels;
using App.ViewModels.AlbumViewModels;

namespace App.Services
{
    public interface IAlbumService
    {
        AlbumCreateViewModel CreateAlbum(AlbumCreateViewModel album);
        AlbumDetailsViewModel GetAlbum(Guid id);
        bool AddTrackToAlbum(Guid albumId, Track trackForDb);
    }
}