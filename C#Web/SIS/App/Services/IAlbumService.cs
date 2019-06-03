using App.ViewModels;

namespace App.Services
{
    public interface IAlbumService
    {
        AlbumViewModel CreateAlbum(AlbumViewModel album);
        AlbumViewModel GetAlbum(AlbumViewModel album);
    }
}