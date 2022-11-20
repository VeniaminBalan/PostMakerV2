using System.ComponentModel.DataAnnotations;

namespace PostMakerV2.Models
{
    public class CreatePostViewModel
    {
        
        public string Author { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
