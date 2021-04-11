using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4Softbinator.DTO
{
    public class StudentStat
    {
        public string Name { get; set; }
        public IEnumerable<string> Subjects { get; set; }
        public string FavouriteSubject => Subjects.Skip(1).FirstOrDefault();

        public override string ToString()
        {
            return $"{Name}: FAV: {FavouriteSubject} | ALL: {string.Join(", ", Subjects)} ";
        }
    }
}
