using System.Data;
using System.Security;
using App.Models;

namespace SIS.HTTP.Extensions
{
    public static class EntityExtensions
    {
        public static string ToHtmlAll(this Album album)
        {
            return $"<a href='/Albums/Details?id={album.Id}'>{album.Name}</a>";
        }

        public static string ToHtmlDetails(this Album album)
        {
            return $@"<img src='{album.Cover}' alt='no image :('/><br/>
             <h2>Name: {album.Name}</h2><br/>
              <h2>Price: {album.Price}</h2><br/><br/>
               <h2>Tracks</h2>
                <hr style='height: 2px' /> <a href='/Tracks/Create'>Create Track</a>
                <hr style='height: 2px' /> <ul>";
        }
    }
}