using Microsoft.EntityFrameworkCore;


namespace UWS.Shared
{
    public class Chinook : DbContext
    {
        public DbSet<Album> Albums {get; set; }  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "chinook.db");
            string CurrentDir = System.Environment.CurrentDirectory;
            string ParentDir = System.IO.Directory.GetParent(CurrentDir).FullName;
            string path = System.IO.Path.Combine(ParentDir, "chinook.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }
    }
}