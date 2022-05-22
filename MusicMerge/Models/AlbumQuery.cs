using System.ComponentModel.DataAnnotations;
using MetaBrainz.MusicBrainz;

namespace MusicMerge
{
    public class Artist
    {
        public int Id { get; set; }
        public int Gid { get; set; }
        public string Name { get; set; }

        public string Sort_Name { get; set; }

    }
}
