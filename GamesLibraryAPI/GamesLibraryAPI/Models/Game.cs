using System.ComponentModel.DataAnnotations;

namespace GamesLibraryAPI.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Category { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
    }
}
