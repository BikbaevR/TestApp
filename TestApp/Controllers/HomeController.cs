using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        public ContextDB db { get; set; }

        public HomeController(ContextDB context)
        {
            db = context;
        }

        public IActionResult Index(string? search)
        {
            if(search != null) {
                var result = db.employees.Where(a => 
                a.FirstName.Contains(search) || 
                a.LastName.Contains(search) ||
                a.Surname.Contains(search) ||
                a.DateOfBirth.ToString().Contains(search) ||
                a.Countries.CountryName.Contains(search) ||
                a.Cities.NameCity.Contains(search) ||
                a.Areas.AreaName.Contains(search) ||
                a.Quarters.QuarterName.Contains(search) ||
                a.HouseNumber.Contains(search) ||
                a.ApartmentNumber.Contains(search) ||
                a.HomePhoneNumber.Contains(search) ||
                a.PersonalNumber.Contains(search) ||
                a.FamilyStatus.Status.Contains(search) ||
                a.Militarys.MilitaryName.Contains(search) ||
                a.PassportSeries.Contains(search) ||
                a.TaxIdentificationNumber.ToString().Contains(search) ||
                a.IFPS.ToString().Contains(search) ||
                a.PassportIssuedBy.Contains(search) ||
                a.PassportIssueDate.ToString().Contains(search) ||
                a.Educations.EducationName.Contains(search))
                .Include(a => a.Countries)
                .Include(b => b.Areas)
                .Include(c => c.Cities)
                .Include(d => d.Educations)
                .Include(e => e.FamilyStatus)
                .Include(f => f.Militarys)
                .Include(j => j.Quarters)
                .ToArray();

                if (result.Length <= 0)
                {
                    string upper = search.ToUpper();

                    result = db.employees.Where(a =>
                    a.FirstName.Contains(upper) ||
                    a.LastName.Contains(upper) ||
                    a.Surname.Contains(upper) ||
                    a.DateOfBirth.ToString().Contains(upper) ||
                    a.Countries.CountryName.Contains(upper) ||
                    a.Cities.NameCity.Contains(upper) ||
                    a.Areas.AreaName.Contains(upper) ||
                    a.Quarters.QuarterName.Contains(upper) ||
                    a.HouseNumber.Contains(upper) ||
                    a.ApartmentNumber.Contains(upper) ||
                    a.HomePhoneNumber.Contains(upper) ||
                    a.PersonalNumber.Contains(upper) ||
                    a.FamilyStatus.Status.Contains(upper) ||
                    a.Militarys.MilitaryName.Contains(upper) ||
                    a.PassportSeries.Contains(upper) ||
                    a.TaxIdentificationNumber.ToString().Contains(upper) ||
                    a.IFPS.ToString().Contains(upper) ||
                    a.PassportIssuedBy.Contains(upper) ||
                    a.PassportIssueDate.ToString().Contains(upper) ||
                    a.Educations.EducationName.Contains(upper))
                    .Include(a => a.Countries)
                    .Include(b => b.Areas)
                    .Include(c => c.Cities)
                    .Include(d => d.Educations)
                    .Include(e => e.FamilyStatus)
                    .Include(f => f.Militarys)
                    .Include(j => j.Quarters)
                    .ToArray();

                    if (result.Length <= 0)
                    {
                        string lower = search.ToLower();

                        result = db.employees.Where(a =>
                        a.FirstName.Contains(lower) ||
                        a.LastName.Contains(lower) ||
                        a.Surname.Contains(lower) ||
                        a.DateOfBirth.ToString().Contains(lower) ||
                        a.Countries.CountryName.Contains(lower) ||
                        a.Cities.NameCity.Contains(lower) ||
                        a.Areas.AreaName.Contains(lower) ||
                        a.Quarters.QuarterName.Contains(lower) ||
                        a.HouseNumber.Contains(lower) ||
                        a.ApartmentNumber.Contains(lower) ||
                        a.HomePhoneNumber.Contains(lower) ||
                        a.PersonalNumber.Contains(lower) ||
                        a.FamilyStatus.Status.Contains(lower) ||
                        a.Militarys.MilitaryName.Contains(lower) ||
                        a.PassportSeries.Contains(lower) ||
                        a.TaxIdentificationNumber.ToString().Contains(lower) ||
                        a.IFPS.ToString().Contains(lower) ||
                        a.PassportIssuedBy.Contains(lower) ||
                        a.PassportIssueDate.ToString().Contains(lower) ||
                        a.Educations.EducationName.Contains(lower))
                        .Include(a => a.Countries)
                        .Include(b => b.Areas)
                        .Include(c => c.Cities)
                        .Include(d => d.Educations)
                        .Include(e => e.FamilyStatus)
                        .Include(f => f.Militarys)
                        .Include(j => j.Quarters)
                        .ToArray();
                    }
                }
                return View(result);
            }
            else 
            { 
            employees[] employees = db.employees
                .Include(a => a.Countries)
                .Include(b => b.Areas)
                .Include(c => c.Cities)
                .Include(d => d.Educations)
                .Include(e => e.FamilyStatus)
                .Include(f => f.Militarys)
                .Include(j => j.Quarters
                )
                .ToArray();
            return View(employees);

            }
        }

        [HttpGet]
        public IActionResult AddData()
        {

            Areas[] areas = db.Areas.ToArray();

            if (areas.Length <= 0)
            {
                db.Areas.Add(new Models.Areas
                {
                    AreaName = "Алмазарский район",
                });
                db.Areas.Add(new Models.Areas
                {
                    AreaName = "Бектемирский район",
                });
                db.Areas.Add(new Models.Areas
                {
                    AreaName = "Мирабадский район",
                });
                db.Areas.Add(new Models.Areas
                {
                    AreaName = "Мирзо-Улугбекский район",
                });
                db.Areas.Add(new Models.Areas
                {
                    AreaName = "Сергелийский район",
                });
                db.Areas.Add(new Models.Areas
                {
                    AreaName = "Чиланзарский район",
                });
                db.Areas.Add(new Models.Areas
                {
                    AreaName = "Шайхантаурский район",
                });
                db.Areas.Add(new Models.Areas
                {
                    AreaName = "Юнусабадский район",
                });

                db.SaveChanges();
            }

            Cities[] cities = db.Cities.ToArray();

            if (cities.Length <= 0)
            {
                db.Cities.Add(new Models.Cities {
                    NameCity = "Ташкент"
                });

                db.SaveChanges();
            }

            Countries[] countries = db.Countries.ToArray();

            if (countries.Length <= 0)
            {
                db.Countries.Add(new Models.Countries
                {
                    CountryName = "Узбекистан"
                });

                db.SaveChanges();
            }

            FamilyStatus[] familyStatus = db.FamilyStatus.ToArray();

            if (familyStatus.Length <= 0)
            {
                db.FamilyStatus.Add(new Models.FamilyStatus
                {
                    Status = "Женат"
                });
                db.FamilyStatus.Add(new Models.FamilyStatus
                {
                    Status = "Не женат"
                });
                db.FamilyStatus.Add(new Models.FamilyStatus
                {
                    Status = "Замужем"
                });
                db.FamilyStatus.Add(new Models.FamilyStatus
                {
                    Status = "Не замужем"
                });

                db.SaveChanges();
            }

            Quarters[] quarters = db.Quarters.ToArray();

            if (quarters.Length <= 0)
            {
                db.Quarters.Add(new Models.Quarters
                {
                    QuarterName = "Каракамыш 2/4"
                });
                db.SaveChanges();
            }

            Militarys[] militarys = db.Militarys.ToArray();

            if (militarys.Length <= 0)
            {
                db.Militarys.Add(new Models.Militarys
                {
                    MilitaryName = "Годен"
                });
                db.Militarys.Add(new Models.Militarys
                {
                    MilitaryName = "Не годен"
                });
            }

            Educations[] educations = db.Educations.ToArray();

            if (educations.Length <= 0)
            {
                db.Educations.Add(new Models.Educations
                {
                    EducationName = "Среднее образование"
                });
                db.Educations.Add(new Models.Educations
                {
                    EducationName = "Средне-специальное образование"
                });
                db.Educations.Add(new Models.Educations
                {
                    EducationName = "Высшее образование"
                });
                db.Educations.Add(new Models.Educations
                {
                    EducationName = "Магистратура"
                });
            }

            employees[] employees = db.employees.ToArray();

            if (employees.Length <= 0)
            {
                db.employees.Add(new Models.employees
                {

                    FirstName = "Рафаэль",
                    LastName = "Бикбаев",
                    Surname = "Рауфович",
                    DateOfBirth = new DateTime(2001, 02, 08),
                    CountryID = 1,
                    CityOfBirthID = 1,
                    AreaID = 1,
                    QuarterID = 1,
                    HouseNumber = "50",
                    ApartmentNumber = "24",
                    HomePhoneNumber = "+998710000000",
                    PersonalNumber = "+998974297105",
                    FamilyStatusID = 2,
                    MilitaryID = 2,
                    MilitaryIdPhoto = "5.png",
                    PassportSeries = "AB123456",
                    PassportPhoto = "4.png",
                    TaxIdentificationNumber = 123456789,
                    IFPS = 123456789123456789,
                    Photo = "6.png",
                    PassportIssuedBy = "Паспортный стол",
                    PassportIssueDate = new DateTime(2017, 01, 01),
                    EducationID = 3
                });
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AreasList()
        {
            Areas[] areas = db.Areas.ToArray();

            return View(areas);
        }

        [HttpGet]
        public IActionResult AreasAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AreasAdd(string AreaName)
        {
            db.Areas.Add(new Models.Areas
            {
                AreaName = AreaName
            });
            db.SaveChanges();

            return RedirectToAction("AreasList", "Home");
        }

        [HttpGet]
        public IActionResult AreasEdit(int Id)
        {
            Areas areas = db.Areas.FirstOrDefault(p => p.Id == Id);

            Areas area = new Areas()
            {
                Id = areas.Id,
                AreaName = areas.AreaName
            };

            return View(area);
        }

        [HttpPost]
        public IActionResult AreasEdit(int Id, string AreaName)
        {
            Areas areas = db.Areas.FirstOrDefault(p => p.Id == Id);

            if (areas != null)
            {
                areas.AreaName = AreaName;
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("AreasList", "Home");
            }

            return RedirectToAction("AreasList", "Home");
        }

        [HttpGet]
        public IActionResult AreasDelete(int Id)
        {
            Areas areas = db.Areas.FirstOrDefault(p => p.Id == Id);

            if (areas != null)
            {
                db.Areas.Remove(areas);
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("AreasList", "Home");
            }

            return RedirectToAction("AreasList", "Home");
        }

        [HttpGet]
        public IActionResult CitiesList()
        {
            Cities[] cities = db.Cities.ToArray();
            return View(cities);
        }

        [HttpGet]
        public IActionResult CitiesAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CitiesAdd(string NameCity)
        {
            db.Cities.Add(new Models.Cities {
                NameCity = NameCity
            });
            db.SaveChanges();

            return RedirectToAction("CitiesList", "Home");
        }

        [HttpGet]
        public IActionResult CitiesEdit(int Id)
        {
            Cities cities = db.Cities.FirstOrDefault(p => p.Id == Id);

            Cities city = new Cities()
            {
                Id = cities.Id,
                NameCity = cities.NameCity
            };

            return View(city);
        }

        [HttpPost]
        public IActionResult CitiesEdit(int Id, string NameCity)
        {
            Cities cities = db.Cities.FirstOrDefault(p => p.Id == Id);

            if (cities != null)
            {
                cities.NameCity = NameCity;
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("CitiesList", "Home");
            }

            return RedirectToAction("CitiesList", "Home");
        }


        [HttpGet]
        public IActionResult CitiesDelete(int Id)
        {
            Cities cities = db.Cities.FirstOrDefault(p => p.Id == Id);

            if (cities != null)
            {
                db.Cities.Remove(cities);
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("CitiesList", "Home");
            }

            return RedirectToAction("CitiesList", "Home");
        }

        [HttpGet]
        public IActionResult CountriesList()
        {
            Countries[] countries = db.Countries.ToArray();

            return View(countries);
        }

        [HttpGet]
        public IActionResult CountriesAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CountriesAdd(string CountryName)
        {
            db.Countries.Add(new Models.Countries
            {
                CountryName = CountryName
            });
            db.SaveChanges();

            return RedirectToAction("CountriesList", "Home");
        }
        [HttpGet]
        public IActionResult CountriesEdit(int Id)
        {
            Countries countries = db.Countries.FirstOrDefault(p => p.Id == Id);

            Countries country = new Countries()
            {
                Id = countries.Id,
                CountryName = countries.CountryName
            };

            return View(country);
        }

        [HttpPost]
        public IActionResult CountriesEdit(int Id, string CountryName)
        {
            Countries countries = db.Countries.FirstOrDefault(p => p.Id == Id);

            if (countries != null)
            {
                countries.CountryName = CountryName;
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("CountriesList", "Home");
            }

            return RedirectToAction("CountriesList", "Home");
        }

        [HttpGet]
        public ActionResult CountriesDelete(int Id)
        {
            Countries countries = db.Countries.FirstOrDefault(p => p.Id == Id);

            if (countries != null)
            {
                db.Countries.Remove(countries);
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("CountriesList", "Home");
            }

            return RedirectToAction("CountriesList", "Home");
        }

        [HttpGet]
        public IActionResult EducationsList()
        {
            Educations[] educations = db.Educations.ToArray();

            return View(educations);
        }

        [HttpGet]
        public IActionResult EducationsAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EducationsAdd(string EducationName)
        {
            db.Educations.Add(new Models.Educations
            {
                EducationName = EducationName
            });
            db.SaveChanges();

            return RedirectToAction("EducationsList", "Home");
        }

        [HttpGet]
        public IActionResult EducationsEdit(int Id)
        {
            Educations educations = db.Educations.FirstOrDefault(p => p.Id == Id);

            Educations education = new Educations()
            {
                Id = educations.Id,
                EducationName = educations.EducationName
            };

            return View(education);
        }
        [HttpPost]
        public IActionResult EducationsEdit(int Id, string EducationName)
        {
            Educations educations = db.Educations.FirstOrDefault(p => p.Id == Id);

            if (educations != null)
            {
                educations.EducationName = EducationName;
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("EducationsList", "Home");
            }

            return RedirectToAction("EducationsList", "Home");
        }

        [HttpGet]
        public ActionResult EducationsDelete(int Id)
        {
            Educations educations = db.Educations.FirstOrDefault(p => p.Id == Id);

            if (educations != null)
            {
                db.Educations.Remove(educations);
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("EducationsList", "Home");
            }

            return RedirectToAction("EducationsList", "Home");
        }

        [HttpGet]
        public IActionResult FamilyStatusList()
        {
            FamilyStatus[] familyStatus = db.FamilyStatus.ToArray();

            return View(familyStatus);
        }

        [HttpGet]
        public IActionResult FamilyStatusAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FamilyStatusAdd(string Status)
        {
            db.FamilyStatus.Add(new Models.FamilyStatus
            {
                Status = Status
            });
            db.SaveChanges();

            return RedirectToAction("FamilyStatusList", "Home");
        }

        [HttpGet]
        public IActionResult FamilyStatusEdit(int Id)
        {
            FamilyStatus familyStatus = db.FamilyStatus.FirstOrDefault(p => p.Id == Id);

            FamilyStatus family = new FamilyStatus()
            {
                Id = familyStatus.Id,
                Status = familyStatus.Status
            };
            return View(family);
        }

        [HttpPost]
        public IActionResult FamilyStatusEdit(int Id, string Status)
        {

            FamilyStatus familyStatus = db.FamilyStatus.FirstOrDefault(p => p.Id == Id);

            if (familyStatus != null)
            {
                familyStatus.Status = Status;
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("FamilyStatusList", "Home");
            }

            return RedirectToAction("FamilyStatusList", "Home");

        }

        [HttpGet]
        public IActionResult FamilyStatusDelete(int Id)
        {
            FamilyStatus familyStatus = db.FamilyStatus.FirstOrDefault(p => p.Id == Id);

            if (familyStatus != null)
            {
                db.FamilyStatus.Remove(familyStatus);
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("FamilyStatusList", "Home");
            }

            return RedirectToAction("FamilyStatusList", "Home");
        }

        [HttpGet]
        public IActionResult MilitarysList()
        {
            Militarys[] militarys = db.Militarys.ToArray();
            return View(militarys);
        }

        [HttpGet]
        public IActionResult MilitarysAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MilitarysAdd(string MilitaryName)
        {
            db.Militarys.Add(new Models.Militarys
            {
                MilitaryName = MilitaryName
            });
            db.SaveChanges();

            return RedirectToAction("MilitarysList", "Home");
        }

        [HttpGet]
        public IActionResult MilitarysEdit(int Id)
        {
            Militarys militarys = db.Militarys.FirstOrDefault(p => p.Id == Id);

            Militarys military = new Militarys()
            {
                Id = militarys.Id,
                MilitaryName = militarys.MilitaryName
            };

            return View(military);
        }

        [HttpPost]
        public IActionResult MilitarysEdit(int Id, string MilitaryName)
        {
            Militarys militarys = db.Militarys.FirstOrDefault(p => p.Id == Id);

            if (militarys != null)
            {
                militarys.MilitaryName = MilitaryName;
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("MilitarysList", "Home");
            }

            return RedirectToAction("MilitarysList", "Home");
        }

        [HttpGet]
        public IActionResult MilitarysDelete(int Id)
        {
            Militarys militarys = db.Militarys.FirstOrDefault(p => p.Id == Id);

            if (militarys != null)
            {
                db.Militarys.Remove(militarys);
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("MilitarysList", "Home");
            }

            return RedirectToAction("MilitarysList", "Home");
        }

        [HttpGet]
        public IActionResult QuartersList()
        {
            Quarters[] quarters = db.Quarters.ToArray();
            return View(quarters);
        }

        [HttpGet]
        public IActionResult QuartersAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult QuartersAdd(string QuarterName)
        {
            db.Quarters.Add(new Models.Quarters
            {
                QuarterName = QuarterName
            });
            db.SaveChanges();

            return RedirectToAction("QuartersList", "Home");
        }

        [HttpGet]
        public IActionResult QuartersEdit(int Id)
        {
            Quarters quarters = db.Quarters.FirstOrDefault(p => p.Id == Id);

            Quarters quarter = new Quarters()
            {
                Id = quarters.Id,
                QuarterName = quarters.QuarterName
            };

            return View(quarter);
        }

        [HttpPost]
        public IActionResult QuartersEdit(int Id, string QuarterName)
        {
            Quarters quarters = db.Quarters.FirstOrDefault(p => p.Id == Id);

            if (quarters != null)
            {
                quarters.QuarterName = QuarterName;
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("QuartersList", "Home");
            }

            return RedirectToAction("QuartersList", "Home");
        }

        [HttpGet]
        public IActionResult QuartersDelete(int Id)
        {
            Quarters quarters = db.Quarters.FirstOrDefault(p => p.Id == Id);

            if (quarters != null)
            {
                db.Quarters.Remove(quarters);
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("QuartersList", "Home");
            }

            return RedirectToAction("QuartersList", "Home");
        }


        [HttpGet]
        public IActionResult EmployeesAdd()
        {
            SelectList country = new SelectList(db.Countries, "Id", "CountryName");
            ViewBag.countryItems = country;

            SelectList city = new SelectList(db.Cities, "Id", "NameCity");
            ViewBag.cityItems = city;

            SelectList area = new SelectList(db.Areas, "Id", "AreaName");
            ViewBag.areaItems = area;

            SelectList quarter = new SelectList(db.Quarters, "Id", "QuarterName");
            ViewBag.quarterItems = quarter;

            SelectList family = new SelectList(db.FamilyStatus, "Id", "Status");
            ViewBag.familyItems = family;

            SelectList miitary = new SelectList(db.Militarys, "Id", "MilitaryName");
            ViewBag.miitaryItems = miitary;

            SelectList education = new SelectList(db.Educations, "Id", "EducationName");
            ViewBag.educationItems = education;

            return View();
        }


        public string fileName_one;
        public string fileName_two;
        public string fileName_three;

        [HttpPost]
        public IActionResult EmployeesAdd(
            string FirstName,
            string LastName,
            string Surname,
            DateTime DateOfBirth,
            int CountryID,
            int CityOfBirthID,
            int AreaID,
            int QuarterID,
            string HouseNumber,
            string ApartmentNumber,
            string HomePhoneNumber,
            string PersonalNumber,
            int FamilyStatusID,
            int MilitaryID,
            IFormFile MilitaryIdPhoto,
            string PassportSeries,
            IFormFile PassportPhoto,
            int TaxIdentificationNumber,
            long IFPS,
            IFormFile Photo,
            string PassportIssuedBy,
            DateTime PassportIssueDate,
            int EducationID
            )
        {

            if (MilitaryIdPhoto != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + MilitaryIdPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                MilitaryIdPhoto.CopyTo(new FileStream(filePath, FileMode.Create));
                fileName_one = uniqueFileName;

            }

            if (PassportPhoto != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + PassportPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                PassportPhoto.CopyTo(new FileStream(filePath, FileMode.Create));
                fileName_two = uniqueFileName;

            }
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                fileName_three = uniqueFileName;
            }

            db.employees.Add(new Models.employees
            {
                FirstName = FirstName,
                LastName = LastName,
                Surname = Surname,
                DateOfBirth = DateOfBirth,
                CountryID = CountryID,
                CityOfBirthID = CityOfBirthID,
                AreaID = AreaID,
                QuarterID = QuarterID,
                HouseNumber = HouseNumber,
                ApartmentNumber = ApartmentNumber,
                HomePhoneNumber = HomePhoneNumber,
                PersonalNumber = PersonalNumber,
                FamilyStatusID = FamilyStatusID,
                MilitaryID = MilitaryID,
                MilitaryIdPhoto = fileName_one,
                PassportSeries = PassportSeries,
                PassportPhoto = fileName_two,
                TaxIdentificationNumber = TaxIdentificationNumber,
                IFPS = IFPS,
                Photo = fileName_three,
                PassportIssuedBy = PassportIssuedBy,
                PassportIssueDate = PassportIssueDate,
                EducationID = EducationID
            });
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult EmployeesEdit(int Id)
        {
            employees employee = db.employees.FirstOrDefault(p => p.Id == Id);


            SelectList country = new SelectList(db.Countries, "Id", "CountryName");
            ViewBag.countryItems = country;

            SelectList city = new SelectList(db.Cities, "Id", "NameCity");
            ViewBag.cityItems = city;

            SelectList area = new SelectList(db.Areas, "Id", "AreaName");
            ViewBag.areaItems = area;

            SelectList quarter = new SelectList(db.Quarters, "Id", "QuarterName");
            ViewBag.quarterItems = quarter;

            SelectList family = new SelectList(db.FamilyStatus, "Id", "Status");
            ViewBag.familyItems = family;

            SelectList miitary = new SelectList(db.Militarys, "Id", "MilitaryName");
            ViewBag.miitaryItems = miitary;

            SelectList education = new SelectList(db.Educations, "Id", "EducationName");
            ViewBag.educationItems = education;



            employees employe = new employees()
            {
                Id = Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Surname = employee.Surname,
                DateOfBirth = employee.DateOfBirth,
                CountryID = employee.CountryID,
                CityOfBirthID = employee.CityOfBirthID,
                AreaID = employee.AreaID,
                QuarterID = employee.QuarterID,
                HouseNumber = employee.HouseNumber,
                ApartmentNumber = employee.ApartmentNumber,
                HomePhoneNumber = employee.HomePhoneNumber,
                PersonalNumber = employee.PersonalNumber,
                FamilyStatusID = employee.FamilyStatusID,
                MilitaryID = employee.MilitaryID,
                MilitaryIdPhoto = employee.MilitaryIdPhoto,
                PassportSeries = employee.PassportSeries,
                PassportPhoto = employee.PassportPhoto,
                TaxIdentificationNumber = employee.TaxIdentificationNumber,
                IFPS = employee.IFPS,
                Photo = employee.Photo,
                PassportIssuedBy = employee.PassportIssuedBy,
                PassportIssueDate = employee.PassportIssueDate,
                EducationID = employee.EducationID
            };

            return View(employe);
        }


        public string fileName_one_more;
        public string fileName_two_more;
        public string fileName_three_more;

        [HttpPost]
        public IActionResult EmployeesEdit(
            int Id,
            string FirstName,
            string LastName,
            string Surname,
            DateTime DateOfBirth,
            int CountryID,
            int CityOfBirthID,
            int AreaID,
            int QuarterID,
            string HouseNumber,
            string ApartmentNumber,
            string HomePhoneNumber,
            string PersonalNumber,
            int FamilyStatusID,
            int MilitaryID,
            IFormFile MilitaryIdPhoto,
            string PassportSeries,
            IFormFile PassportPhoto,
            int TaxIdentificationNumber,
            long IFPS,
            IFormFile Photo,
            string PassportIssuedBy,
            DateTime PassportIssueDate,
            int EducationID,

            string img_one_old,
            string img_two_old,
            string img_three_old
            )
        {
            employees employees = db.employees.FirstOrDefault(p => p.Id == Id);

            if (MilitaryIdPhoto != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + MilitaryIdPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                MilitaryIdPhoto.CopyTo(new FileStream(filePath, FileMode.Create));
                fileName_one_more = uniqueFileName;

            }
            else
            {
                fileName_one_more = img_one_old;
            }

            if (PassportPhoto != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + PassportPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                PassportPhoto.CopyTo(new FileStream(filePath, FileMode.Create));
                fileName_two_more = uniqueFileName;

            }
            else
            {
                fileName_two_more = img_two_old;
            }

            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                fileName_three_more = uniqueFileName;
            }
            else
            {
                fileName_three_more = img_three_old;
            }


            employees.FirstName = FirstName;
            employees.LastName = LastName;
            employees.Surname = Surname;
            employees.DateOfBirth = DateOfBirth;
            employees.CountryID = CountryID;
            employees.CityOfBirthID = CityOfBirthID;
            employees.AreaID = AreaID;
            employees.QuarterID = QuarterID;
            employees.HouseNumber = HouseNumber;
            employees.ApartmentNumber = ApartmentNumber;
            employees.HomePhoneNumber = HomePhoneNumber;
            employees.PersonalNumber = PersonalNumber;
            employees.FamilyStatusID = FamilyStatusID;
            employees.MilitaryID = MilitaryID;
            employees.MilitaryIdPhoto = fileName_one_more;
            employees.PassportSeries = PassportSeries;
            employees.PassportPhoto = fileName_two_more;
            employees.TaxIdentificationNumber = TaxIdentificationNumber;
            employees.IFPS = IFPS;
            employees.Photo = fileName_three_more;
            employees.PassportIssuedBy = PassportIssuedBy;
            employees.PassportIssueDate = PassportIssueDate;
            employees.EducationID = EducationID;
            
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult EmployeesDelete(int Id)
        {
            employees employee = db.employees.FirstOrDefault(p => p.Id == Id);

            if (employee != null)
            {
                db.employees.Remove(employee);
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            employees[] employees = db.employees
                .Include(a => a.Countries)
                .Include(b => b.Areas)
                .Include(c => c.Cities)
                .Include(d => d.Educations)
                .Include(e => e.FamilyStatus)
                .Include(f => f.Militarys)
                .Include(j => j.Quarters)
                .Where(h => h.Id == Id)
                .ToArray();
            return View(employees);
        }
    }
}