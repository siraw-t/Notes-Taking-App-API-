using System.ComponentModel.DataAnnotations;

namespace Notes.Api.DTOs
{
    public class NoteForCreationDto
    {
        [Required]
        [MaxLength(100)]
        public required string Title { get; set; }
        [Required]
        public required string Content { get; set; }
    }

    public class NoteForUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public required string Title { get; set; }
        [Required]
        public required string Content { get; set; }
    }
    
    public class NoteDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}