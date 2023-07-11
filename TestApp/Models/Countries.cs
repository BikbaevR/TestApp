using System.ComponentModel.DataAnnotations;
namespace TestApp.Models
{
    public class Countries
    {
        [Key]
        public int Id { get; set; }
        public string CountryName { get; set; }
    }
}
