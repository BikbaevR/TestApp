using System.ComponentModel.DataAnnotations;
namespace TestApp.Models
{
    public class Quarters
    {
        [Key]
        public int Id { get; set; }
        public string QuarterName { get; set; }
    }
}
