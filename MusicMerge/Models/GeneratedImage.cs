using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicMerge
{
    public class GeneratedImage
    {
        [Key]
        public int Id { get; set; }

        public string GeneratedImagePath { get; set; }

        public int UserId { get; set; }
    }
}