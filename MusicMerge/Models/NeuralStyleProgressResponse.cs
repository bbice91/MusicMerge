using System.ComponentModel.DataAnnotations;

namespace MusicMerge
{
    public class NeuralStyleProgressResponse
    {
        public string? result {  get; set; }
        public string status { get; set; }
        public int progress { get; set; }
        public string? url { get; set; }

    }
}
