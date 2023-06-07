using System.ComponentModel.DataAnnotations;
using static Forum.App.Data.DataConstants.Post;

namespace Forum.App.Models.Post
{
    public class PostViewModel
    {

        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;
    }
}
