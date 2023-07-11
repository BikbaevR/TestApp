using System.ComponentModel.DataAnnotations;
namespace TestApp.Models
{
    public class Militarys
    {
        [Key]
        public int Id { get; set; }
        public string MilitaryName { get; set; }
    }
}
