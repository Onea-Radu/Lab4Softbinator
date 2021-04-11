using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4Softbinator.DTO
{
    public class StudentDTO
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }


    }
}
