using Microsoft.EntityFrameworkCore;


namespace Chinooksite
{
    public class Chinook : DbContext
    {
        public DbSet<Album> Albums {get; set; } 

        public DbSet<Track> Tracks {get; set; } 

        public DbSet<Artist> Artists {get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            string CurrentDir = System.Environment.CurrentDirectory;
            string ParentDir = System.IO.Directory.GetParent(CurrentDir).FullName;
            string path = System.IO.Path.Combine(ParentDir, "chinook.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }
    }
}