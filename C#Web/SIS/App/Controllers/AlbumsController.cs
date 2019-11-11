using System;
using System.Linq;
using App.Services;
using App.ViewModels.AlbumViewModels;
using SIS.WebServer;
using SIS.WebServer.Attributes;
using SIS.WebServer.Results;

namespace App.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumService albumService;
        public AlbumsController(IAlbumService albumService)
        {
            this.albumService = albumService;
        }
        [HttpGet]
        [Authorized]
        public IActionResult All()
        {
            var all = albumService.GetAll();
                return View(all.ToList());
        }
    

    [HttpGet]
    [Authorized]
        public IActionResult Details(string id)
        {
            var albumId = Guid.Parse(id);
            var album = albumService.GetAlbum(albumId);
            return View(album);

        }
        [HttpGet]
        [Authorized]
        public IActionResult Create()
        {
            return View();

        }
        [Authorized]
        [HttpPost(action:"Create")]
        public IActionResult CreateConfirm(AlbumCreateViewModel albumModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var album = albumService.CreateAlbum(albumModel);

           return Redirect($"/Albums/Details?id={album.Id}");
        }

        

    }
}