using System;
using SIS.WebServer;
using App.Services;
using App.ViewModels.TrackViewModels;
using SIS.WebServer.Attributes;
using SIS.WebServer.Results;

namespace App.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITrackService trackService;
        private readonly IAlbumService albumService;
        public TracksController(ITrackService trackService,IAlbumService albumService)
        {
            this.trackService=trackService;
            this.albumService = albumService;
        }
        [Authorized]
        public IActionResult Details(string albumId, string trackId)
        {
            var track = trackService.GetTrack(Guid.Parse(trackId));

                if (track == null)
                {
                    return this.Redirect($"/Albums/Details?id={albumId}");
                }

                return this.View(track);
        }
        [Authorized]
        public IActionResult Create()
            {
               
                var albumId = (string)Request.QueryData["albumId"][0];
                
                return this.View(new TrackDetailsViewModel{AlbumId = albumId});
            }

            
            [HttpPost(action:"Create")]
            [Authorized]
            public IActionResult CreateConfirm(TrackCreateViewModel trackForDb)
            {

                var albumId = Guid.Parse((string)Request.QueryData["albumId"][0]);

            if (!ModelState.IsValid)
            {
                return View();
            }
            var albumFromDb = albumService.GetAlbum(albumId);

                    if (albumFromDb == null)
                    {
                        return this.Redirect("/Albums/All");
                    }

                    
                    albumService.AddTrackToAlbum(albumId, trackForDb);
                

                return this.Redirect($"/Albums/Details?id={albumId}");
            }
        }

    }
