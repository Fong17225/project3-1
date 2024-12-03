using System.ComponentModel.DataAnnotations;

namespace Project3.Models
{
    public class CourseContent
    {
        [Key]
        public int ContentId { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Relationships
        public Course Course { get; set; }
    }
}