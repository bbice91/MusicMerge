using System.ComponentModel.DataAnnotations;

namespace MusicMerge
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string SpotifyGuid { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Token { get; set; }

        public List<GeneratedImage> Images { get; set; }
    }
}
