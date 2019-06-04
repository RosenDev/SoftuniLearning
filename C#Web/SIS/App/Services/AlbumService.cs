using System;
using System.Linq;
using App.Data;
using App.Models;
using App.ViewModels;
using App.ViewModels.AlbumViewModels;
using App.ViewModels.TrackViewModels;

namespace App.Services
{
    public class AlbumService:IAlbumService
    {
        public AlbumCreateViewModel CreateAlbum(AlbumCreateViewModel albumModel)
        {
            using (var context = new AppDbContext())
            {
                var album= new Album
                {
                    Cover = albumModel.Cover,
                    Name = albumModel.Name,
                    Price = 0.0m
                };
                context.Albums.Add(album);
                context.SaveChanges();
                return new AlbumCreateViewModel{Id = album.Id.ToString()};
            }
;
        }

        public AlbumDetailsViewModel GetAlbum(Guid id)
        {
            using (var context = new AppDbContext())
            {
                var album = context.Albums.Find(id);
               return new AlbumDetailsViewModel
               {
                   Id = album.Id.ToString(),
                   Cover = album.Cover,
                   Name = album.Name,
                   Price = album.Tracks.Sum(x=>x.Price),
                   Tracks = album.Tracks.Select(x=>new TrackDetailsViewModel
                   {
                       Id = x.Id,
                       Name = x.Name,
                       AlbumId = x.AlbumId.ToString(),
                       Link = x.Link,
                       Price = x.Price

                   }).ToList()
               };
            }
        }
        public bool AddTrackToAlbum(Guid albumId, Track trackForDb)
        {
            

           
            using (var ctx= new AppDbContext())
            {
                var albumFromDb = ctx
                    .Albums
                    .Find(albumId);
                if (albumFromDb == null)
                {
                    return false;
                }

                albumFromDb.Tracks.Add(trackForDb);
                albumFromDb.Price = albumFromDb.Tracks
                                         .Select(track => track.Price)
                                         .Sum() * 87 / 100;

                ctx.Update(albumFromDb);
                ctx.SaveChanges();
                return true;
            }

           
        }
    }
}