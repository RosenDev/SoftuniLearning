using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using App.Data;
using App.Models;
using App.ViewModels;
using App.ViewModels.AlbumViewModels;
using App.ViewModels.TrackViewModels;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public class AlbumService : IAlbumService
    {
        public ICollection<AlbumAllViewModel> GetAll()
        {
            var viewModels = new List<AlbumAllViewModel>();
            using (var context = new AppDbContext())
            {
                context.Albums.ToList()
                    .ForEach(x =>
                    {
                        viewModels.Add(new AlbumAllViewModel
                        {
                            Id = x.Id.ToString(),
                            Name = x.Name
                        });
                    });
                return viewModels;
            }
        }

        public AlbumCreateViewModel CreateAlbum(AlbumCreateViewModel albumModel)
        {
            using (var context = new AppDbContext())
            {
                var album = new Album
                {
                    Cover = albumModel.Cover,
                    Name = albumModel.Name,
                    Price = 0.0m
                };
                context.Albums.Add(album);
                context.SaveChanges();
                return new AlbumCreateViewModel {Id = album.Id.ToString()};
            }

            
        }
    

    public AlbumDetailsViewModel GetAlbum(Guid id)
        {
            using (var context = new AppDbContext())
            {
                var album = context.Albums.Include(x => x.Tracks)
                    .SingleOrDefault(x => x.Id == id);
                return new AlbumDetailsViewModel
               {
                   Id = album.Id.ToString(),
                   Cover = album.Cover,
                   Name = album.Name,
                   Price = album.Tracks.Sum(x=>x.Price),
                   Tracks = album.Tracks.Select(x=>new TrackAllViewModel
                   {
                       Id = x.Id.ToString(),
                       Name=x.Name

                   }).ToList()
               };
            }
        }
        public bool AddTrackToAlbum(Guid albumId, TrackCreateViewModel trackForDb)
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
                var track = new  Track
                {
                    AlbumId = albumId,
                    Link = trackForDb.Link,
                    Name = trackForDb.Name,
                    Price = trackForDb.Price
                };
                albumFromDb.Tracks.Add(track);
                albumFromDb.Price = albumFromDb.Tracks
                                         .Select(x => x.Price)
                                         .Sum() * 87 / 100;

                ctx.Update(albumFromDb);
                ctx.SaveChanges();
                return true;
            }

           
        }
    }
}