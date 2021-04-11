using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab4Softbinator.DTO
{
    public class Stat
    {
        public string UniversityName { get; set; }
        public IEnumerable<StudentStat> Students { get; set; }

        public override string ToString()
        {

            return $"{UniversityName}: {string.Join('\n', Students.Select(s => s.ToString()))}";
            // return $"{UniversityName}: {Students.Select(s => s.ToString()).Aggregate((current, next) => current + "\n" + next)}";
        }
    }
}
