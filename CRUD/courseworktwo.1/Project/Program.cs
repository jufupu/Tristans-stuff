using System;
using Chinooksite;
using System.Collections.Generic;
using System.Linq;


namespace Chinooksite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Albums app");

           Chinook db = new Chinook();
            IQueryable<Album> albums = db.Albums;

            foreach(Album a in albums) {
                Console.WriteLine("{0}. {1} {2}", a.AlbumId, a.Title, a.ArtistId);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
    }
}
