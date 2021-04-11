using Lab4Softbinator;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class University
{
    public University(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    public ICollection<Student> Students { get; set; }

}
