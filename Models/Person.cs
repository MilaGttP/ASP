using System.ComponentModel;

namespace ASP.Models
{
    public enum Gender
    {
        Чоловік,
        Жінка
    }
    public class Person
    {
        [DisplayName("Ім'я")]
        public string Name { get; set; }

        [DisplayName("Прізвище")]
        public string Surname { get; set; }

        [DisplayName("По батькові")]
        public string MiddleName { get; set; }

        [DisplayName("Стать")]
        public Gender Gender { get; set; }

        [DisplayName("Місто")]
        public string City { get; set; }

        [DisplayName("Хобі")]
        public string[] Hobbies { get; set; }

        [DisplayName("День народження")]
        public DateOnly Birthday { get; set; }

        public Person()
        {
            Name = "";
            Surname = "";
            MiddleName = "";
            Gender = Gender.Чоловік;
            City = "";
            Hobbies = new string[0];
            Birthday = new DateOnly();
        }
    }
}
