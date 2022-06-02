using System.ComponentModel.DataAnnotations;

namespace MusicMerge
{
    public class Album
    {
        [Key]
        public int Id { get; set; }
        public string AlbumInput { get; set; }
        public string StyleInput { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }   
        public DateTime UpdatedDate { get; set; }
        public int CreatedById { get; set; }

    }
}
