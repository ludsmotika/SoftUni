using System.ComponentModel.DataAnnotations;
using static Forum.App.Data.DataConstants.Post;

namespace Forum.App.Models.Post
{
    public class PostFormModel
    {
        [Required]
        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ContentMaxLenght, MinimumLength = ContentMinLenght)]
        public string Content { get; set; } = null!;
    }
}
