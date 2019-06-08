using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using App.Data;
using App.Models;
using App.ViewModels.AlbumViewModels;
using App.ViewModels.TrackViewModels;
using Microsoft.EntityFrameworkCore;
using SIS.MvcFramework.Mapping;

namespace App.Services
{
    public class AlbumService : IAlbumService
    {
        public ICollection<AlbumAllViewModel> GetAll()
        {
            
            using (var context = new AppDbContext())
            {
                var viewModels =
                    context.Albums.To<AlbumAllViewModel>().ToList();
                return viewModels;
            }
        }

        public Album CreateAlbum(AlbumCreateViewModel albumModel)
        {
            using (var context = new AppDbContext())
            {
                var album = new Album
                {
                    Cover = WebUtility.UrlDecode(albumModel.Cover),
                    Name = WebUtility.UrlDecode(albumModel.Name),
                    Price = 0.0m
                };
                context.Albums.Add(album);
                context.SaveChanges();
                return album;
            }

            
        }
    

    public AlbumDetailsViewModel GetAlbum(Guid id)
        {
            using (var context = new AppDbContext())
            {
                var album = context.Albums.Include(x => x.Tracks)
                    .SingleOrDefault(x => x.Id == id).To<AlbumDetailsViewModel>();
                return album;
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
                    Link = WebUtility.UrlDecode(trackForDb.Link),
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