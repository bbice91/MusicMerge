namespace MusicMerge
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string FirstAlbumInput { get; set; }
        public string SecondAlbumInput { get; set; }
        public string Description {  get; set; }  
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedById { get; set; }

    }
}
