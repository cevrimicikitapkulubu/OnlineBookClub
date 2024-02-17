namespace OnlineBookClub.WEB.Models.DB.Event
{
    public class Location
    {
        public int Id { get; set; }
        public bool IsOnline { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        //public DbGeography Geography { get; set; }  maybe used this pack --> using System.Data.Spatial; 
    }
}
