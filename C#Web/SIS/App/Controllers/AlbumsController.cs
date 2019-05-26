using System.Collections;
using System.Collections.Generic;
using System.Linq;
using App.Data;
using App.Models;
using SIS.HTTP.Extensions;
using SIS.HTTP.Request.Interfaces;
using SIS.HTTP.Responce.Interfaces;

namespace App.Controllers
{
    public class AlbumsController:BaseController
    {
        public IHttpResponse All(IHttpRequest request)
        {
            if (!IsLoggedIn(request))
            {
                return Redirect("/Users/Login");
            }
            using (var context= new AppDbContext())
            {
                ICollection<Album> albums = context.Albums.ToList();
                if (albums.Count==0)
                {
                    ViewData["Albums"] = "There are currently no albums";
                }
                else
                {
                    ViewData["Albums"] = string.Join("<br/>",context.Albums
                        .Select(album => album.ToHtmlAll())
                        .ToList());
                }
                
                return View();
            }

        }

        public IHttpResponse Details(IHttpRequest req)
        {
            if (!IsLoggedIn(req))
            {
               // return Redirect("/Users/Login");
            }
            var id = (string)req.QueryData["id"][0];
            using (var context=new AppDbContext())
            {
                var album = context.Albums.Find(id);
                ViewData["Album"] = album.ToHtmlDetails();
                return View();
            }
            
        }

        public IHttpResponse Create(IHttpRequest req)
        {
            if (!IsLoggedIn(req))
            {
                return Redirect("/Users/Login");
            }
            return null;

        }

        public IHttpResponse CreateConfirm(IHttpRequest req)
        {
            if (!IsLoggedIn(req))
            {
                return Redirect("/Users/Login");
            }

            return null;
        }
    }
}