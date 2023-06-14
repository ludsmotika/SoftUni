using Library.Models.Category;
using System.ComponentModel.DataAnnotations;
using static Library.Common.EntityValidationsConstants.Book;

namespace Library.Models.Book
{
    public class AddBookViewModel
    {

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string Url { get; set; } = null!;

        [Required]
        public string Rating { get; set; } = null!;

        [Range(1,int.MaxValue)]
        public int CategoryId{ get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new HashSet<CategoryViewModel>();
    }
}
