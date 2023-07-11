using System.ComponentModel.DataAnnotations;
namespace TestApp.Models
{
    public class FamilyStatus
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
