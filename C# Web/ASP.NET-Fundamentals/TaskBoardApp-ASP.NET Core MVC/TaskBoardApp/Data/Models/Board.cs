using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using static TaskBoardApp.Data.DataConstants.Board;

namespace TaskBoardApp.Data.Models
{
    public class Board
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(BoardMaxName)]
        public string Name { get; set; } = null!;

        public IEnumerable<Task> Tasks { get; set; } = new HashSet<Task>();
    }
}
