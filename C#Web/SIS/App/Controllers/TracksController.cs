using System;
using System.Collections.Generic;
using System.Linq;
using App.Data;
using SIS.WebServer;
using App.Extensions;
using App.Models;
using SIS.WebServer.Attributes;
using SIS.WebServer.Results;

namespace App.Controllers
{
    public class TracksController : BaseController
    {



        public ActionResult Details()
        {
            if (!this.IsLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

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

        public ActionResult Create()
            {
                if (!this.IsLoggedIn())
                {
                    return this.Redirect("/Users/Login");
                }
                var albumId = (string)Request.QueryData["albumId"][0];

            this.ViewData["AlbumId"] = albumId;
                return this.View();
            }

            
            [HttpPost(action:"Create")]

            public ActionResult CreateConfirm()
            {
                if (!this.IsLoggedIn())
                {
                    return this.Redirect("/Users/Login");
                }

                var albumId = Guid.Parse((string)Request.QueryData["albumId"][0]);

                using (var context = new AppDbContext())
                {
                    Album albumFromDb = context.Albums.SingleOrDefault(album => album.Id == albumId);

                    if (albumFromDb == null)
                    {
                        return this.Redirect("/Albums/All");
                    }

                    string name = (string) Request.FormData["name"][0];
                    string link = (string) Request.FormData["link"][0];
                    string price = (string) Request.FormData["price"][0];

                    Track trackForDb = new Track
                    {
                        Name = name,
                        Link = link,
                        Price = decimal.Parse(price)
                    };

                    albumFromDb.Tracks.Add(trackForDb);
                    albumFromDb.Price = (albumFromDb.Tracks
                                             .Select(track => track.Price)
                                             .Sum() * 87) / 100;
                    context.Update(albumFromDb);
                    context.SaveChanges();
                }

                return this.Redirect($"/Albums/Details?id={albumId}");
            }
        }

    }
