using System.ComponentModel.DataAnnotations;
namespace TestApp.Models
{
    public class Educations
    {
        [Key]
        public int Id { get; set; }
        public string EducationName { get; set; } 
    }
}
