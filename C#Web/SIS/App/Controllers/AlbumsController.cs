using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using App.Data;
using App.Extensions;
using App.Models;
using SIS.WebServer;
using SIS.WebServer.Attributes;
using SIS.WebServer.Results;

namespace App.Controllers
{
    public class AlbumsController : BaseController
    {
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
            using (var context=new AppDbContext())
            {
                var album = context.Albums.Find(id);
                return View(album);
            }
            
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
            var album= new Album
           {
               Cover = (string)Request.FormData["cover"][0],
               Name = (string)Request.FormData["name"][0],
               Price =100M
            
           };
           using (var context= new AppDbContext())
           {
               context.Albums.Add(album);
               context.SaveChanges();
           }

           return Redirect($"/Albums/Details?id={album.Id}");
        }

        

    }
}