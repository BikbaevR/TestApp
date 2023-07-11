using System.ComponentModel.DataAnnotations;

namespace TestApp.Models
{
    public class Cities
    {
        [Key]
        public int Id { get; set; }
        public string NameCity { get; set; }
    }
}
