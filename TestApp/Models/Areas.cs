using System.ComponentModel.DataAnnotations;

namespace TestApp.Models
{
    public class Areas
    {
        [Key]
        public int Id { get; set; }
        public string AreaName { get; set; }
    }
}
