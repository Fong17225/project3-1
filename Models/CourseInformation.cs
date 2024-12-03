using System.ComponentModel.DataAnnotations;

namespace Project3.Models
{
    public class CourseInformation
    {
        [Key]
        public int CourseInformationId { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public string Duration { get; set; }  // Example: "28 November 4 weeks"
        public string StudyLevel { get; set; }  // Example: "Beginner", "Intermediate"
        public string TopicsIncluded { get; set; }  // Stored as '\n' separated
        public string Description { get; set; }  // Stored as '\n' separated
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Relationships
        public Course Course { get; set; }
    }
}