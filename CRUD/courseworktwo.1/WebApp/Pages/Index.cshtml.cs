using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Chinooksite;
using System.Linq;

namespace WebApp.Pages
{
    public class AlbumsModel : PageModel 
    {
        public string Heading1 { get; set; }

        public IEnumerable<string> Albums { get; set; }

        public IEnumerable<string> Tracks { get; set; }

        public void OnGet() {
            Heading1 = "Chinook Music Company";
            Chinook db = new Chinook();
            //Albums = db.Albums.Select( a => a.AlbumId.ToString() + ". " + a.Title + " " + a.Artist.ArtistId);
            //Tracks = db.Tracks.Select( b => b.TrackId.ToString() + "." + b.Name + " " + b.Composer);
        }
    }
}