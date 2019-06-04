using System;
using System.Collections.Generic;
using System.Linq;
using App.Data;
using SIS.WebServer;
using App.Extensions;
using App.Models;
using App.Services;
using App.ViewModels.AlbumViewModels;
using App.ViewModels.TrackViewModels;
using SIS.WebServer.Attributes;
using SIS.WebServer.Results;

namespace App.Controllers
{
    public class TracksController : BaseController
    {
        private readonly IAlbumService albumService;
        public TracksController()
        {
            albumService = new AlbumService();
        }
        [Authorized]
        public ActionResult Details()
        {
          

           var albumId = (string)Request.QueryData["albumId"][0];
            var trackId = Guid.Parse((string)Request.QueryData["trackId"][0]);

            using (var context = new AppDbContext())
            {
                Track trackFromDb = context.Tracks.SingleOrDefault(track => track.Id == trackId);

                if (trackFromDb == null)
                {
                    return this.Redirect($"/Albums/Details?id={albumId}");
                }

                this.ViewData["AlbumId"] = albumId;
                this.ViewData["Track"] = trackFromDb.ToHtmlDetails(albumId);
                return this.View();
            }
        }
        [Authorized]
        public ActionResult Create()
            {
               
                var albumId = (string)Request.QueryData["albumId"][0];
                
                return this.View(new TrackDetailsViewModel{AlbumId = albumId});
            }

            
            [HttpPost(action:"Create")]
            [Authorized]
            public ActionResult CreateConfirm()
            {

                var albumId = Guid.Parse((string)Request.QueryData["albumId"][0]);

               
                    var albumFromDb = albumService.GetAlbum(albumId);

                    if (albumFromDb == null)
                    {
                        return this.Redirect("/Albums/All");
                    }

                    string name = (string) Request.FormData["name"][0];
                    string link = (string) Request.FormData["link"][0];
                    string price = (string) Request.FormData["price"][0];
            //todo
                    Track trackForDb = new Track
                    {
                        Name = name,
                        Link = link,
                        Price = decimal.Parse(price)
                    };
                    albumService.AddTrackToAlbum(albumId, trackForDb);
                

                return this.Redirect($"/Albums/Details?id={albumId}");
            }
        }

    }
