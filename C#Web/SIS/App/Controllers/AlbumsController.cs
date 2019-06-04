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
        public AlbumsController()
        {
            albumService=new AlbumService();
        }
        [HttpGet]
        [Authorized]
        public ActionResult All()
        {
        
            using (var context = new AppDbContext())
            {
                ICollection<Album> albums = context.Albums.ToList();
             
               
                    
                    return View(albums.ToList());
                


            }

        }
    

    [HttpGet]
    [Authorized]
        public ActionResult Details()
        {
           
            var id = Guid.Parse((string)Request.QueryData["id"][0]);
            var album = albumService.GetAlbum(id);
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
        public ActionResult CreateConfirm()
        {
            var albumModel= new AlbumCreateViewModel
           {
               Cover = (string)Request.FormData["cover"][0],
               Name = (string)Request.FormData["name"][0],

           };
            var album = albumService.CreateAlbum(albumModel);

           return Redirect($"/Albums/Details?id={album.Id}");
        }

        

    }
}