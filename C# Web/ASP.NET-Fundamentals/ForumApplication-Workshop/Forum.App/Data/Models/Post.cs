using System.ComponentModel.DataAnnotations;
using static Forum.App.Data.DataConstants.Post;

namespace Forum.App.Data.Models
{
    public class Post
    {
        public Post()
        {
            Id=Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(TitleMinLenght)]
        [MaxLength(TitleMaxLenght)]
        public string Title { get; set; } = null!;


        [Required]
        [MinLength(ContentMinLenght)]
        [MaxLength(ContentMaxLenght)]
        public string Content { get; set; } = null!;
    }
}
