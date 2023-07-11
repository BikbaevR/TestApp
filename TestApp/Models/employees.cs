using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Models
{
    public class employees
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //Id
        public DateTime RecordCreationDate { get; set; } = DateTime.Now; //Дата создания записи
        public string FirstName { get; set; } //Имя
        public string LastName { get; set; } //Фамилия
        public string Surname { get; set; } //Отчество
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; } //Дата рождения
        [ForeignKey("Countries")]
        public int? CountryID { get; set; } //ID Страны рождения//////
        public Countries Countries { get; set; }///
        [ForeignKey("Cities")]
        public int? CityOfBirthID { get; set; } //ID Города рождения////////
        public Cities Cities { get; set; }///
        [ForeignKey("Areas")]
        public int? AreaID { get; set;} //ID Района///////
        public Areas Areas { get; set; }///
        [ForeignKey("Quarters")]
        public int? QuarterID { get; set; } //ID Квартала////////
        public Quarters Quarters { get; set; }///
        public string HouseNumber { get; set; } //Номер дома
        public string ApartmentNumber { get; set; } //Номер квартиры
        public string HomePhoneNumber { get; set; } //Номер домашнего телефона
        public string PersonalNumber { get; set;} //Номер сотового телефона
        [ForeignKey("FamilyStatus")]
        public int? FamilyStatusID { get; set; } //ID Статуса семьи///////
        public FamilyStatus FamilyStatus { get; set;}///
        [ForeignKey("Militarys")]
        public int? MilitaryID { get; set; } //ID Военного билет//////
        public Militarys Militarys { get; set; }///
        public string MilitaryIdPhoto { get; set; } //Фото военногог билета
        public string PassportSeries { get; set; } //Серия паспорта
        public string PassportPhoto { get; set; } //Фото паспорта
        public int TaxIdentificationNumber { get; set; } //ИНН
        public long IFPS { get; set; } //ИНПС
        public string Photo { get; set; } //Фото 3х4
        public string PassportIssuedBy { get; set; } //Паспорт выдан...
        [Column(TypeName = "date")]
        public DateTime PassportIssueDate { get; set; } //Дата выдачи паспорта
        [ForeignKey("Educations")]
        public int? EducationID { get; set; } //ID Образования///////
        public Educations Educations { get; set; }///
    }
}
