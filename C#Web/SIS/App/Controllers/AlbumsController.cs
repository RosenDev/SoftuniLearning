using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using App.Data;
using App.Extensions;
using App.Models;
using App.Services;
using App.ViewModels;
using App.ViewModels.AlbumViewModels;
using SIS.WebServer;
using SIS.WebServer.Attributes;
using SIS.WebServer.Results;

namespace App.Controllers
{
    public class AlbumsController : BaseController
    {
        private readonly IAlbumService albumService;
        public AlbumsController(IAlbumService albumService)
        {
            this.albumService = albumService;
        }
        [HttpGet]
        [Authorized]
        public ActionResult All()
        {
            var all = albumService.GetAll();
                return View(all.ToList());
        }
    

    [HttpGet]
    [Authorized]
        public ActionResult Details(string id)
        {
            var albumId = Guid.Parse(id);
            var album = albumService.GetAlbum(albumId);
            return View(album);

        }
        [HttpGet]
        [Authorized]
        public ActionResult Create()
        {
            return View();

        }
        [Authorized]
        [HttpPost(action:"Create")]
        public ActionResult CreateConfirm(string cover, string name)
        {
            var albumModel= new AlbumCreateViewModel
           {
               Cover = cover,
               Name = name

           };
            var album = albumService.CreateAlbum(albumModel);

           return Redirect($"/Albums/Details?id={album.Id}");
        }

        

    }
}