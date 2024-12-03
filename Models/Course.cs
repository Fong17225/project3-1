using System.ComponentModel.DataAnnotations;

namespace Project3.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Relationships
        public Category Category { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<CourseInformation> CourseInformations { get; set; }
        public ICollection<CourseContent> CourseContents { get; set; }
        public ICollection<Class> Classes { get; set; }
    }
}