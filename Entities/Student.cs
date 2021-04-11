using System.ComponentModel.DataAnnotations;

namespace Lab4Softbinator
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int UniversityId { get; set; }
        public virtual University University { get; set; }

        public Student(University university, string name)
        {
            Name = name;
            University = university;
        }
        public Student()
        {

        }
    }
}
