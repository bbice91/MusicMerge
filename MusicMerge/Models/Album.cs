using System.ComponentModel.DataAnnotations;

namespace MusicMerge
{
    public class Album
    {
        [Key]
        public int Id { get; set; }
        public string FirstAlbumInput { get; set; }
        public string SecondAlbumInput { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }   
        public DateTime UpdatedDate { get; set; }
        public int CreatedById { get; set; }

    }
}
