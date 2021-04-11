using System.ComponentModel.DataAnnotations;

namespace Lab4Softbinator
{
    public class Subject
    {

        public Subject()
        {
        }
        public Subject(string v)
        {
            Name = v;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

    }
}
