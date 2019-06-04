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
        private readonly ITrackService trackService;
        private readonly IAlbumService albumService;
        public TracksController(ITrackService trackService,IAlbumService albumService)
        {
            this.trackService=trackService;
            this.albumService = albumService;
        }
        [Authorized]
        public ActionResult Details(string albumId, string trackId)
        {
            var track = trackService.GetTrack(Guid.Parse(trackId));

                if (track == null)
                {
                    return this.Redirect($"/Albums/Details?id={albumId}");
                }

                return this.View(track);
        }
        [Authorized]
        public ActionResult Create()
            {
               
                var albumId = (string)Request.QueryData["albumId"][0];
                
                return this.View(new TrackDetailsViewModel{AlbumId = albumId});
            }

            
            [HttpPost(action:"Create")]
            [Authorized]
            public ActionResult CreateConfirm(string name, string link, decimal price)
            {

                var albumId = Guid.Parse((string)Request.QueryData["albumId"][0]);

               
                    var albumFromDb = albumService.GetAlbum(albumId);

                    if (albumFromDb == null)
                    {
                        return this.Redirect("/Albums/All");
                    }

                    var trackForDb = new TrackCreateViewModel
                    {
                        Name = name,
                        Link = link,
                        Price = price
                    };
                    albumService.AddTrackToAlbum(albumId, trackForDb);
                

                return this.Redirect($"/Albums/Details?id={albumId}");
            }
        }

    }
