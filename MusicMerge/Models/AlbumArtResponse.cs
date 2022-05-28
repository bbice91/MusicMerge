using System.ComponentModel.DataAnnotations;

namespace MusicMerge
{

    public class Images
    {
    }
    public class AlbumArtResponse
    {
        public Guid Id { get; set; }
        public Images i { get; set; }
        public string LargeImage { get; set; }

    }
}
