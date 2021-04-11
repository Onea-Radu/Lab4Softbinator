using Lab4Softbinator.Context;
using Lab4Softbinator.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lab4Softbinator.Services
{
    public static class Service
    {
        private static DBContext db;

        public static void Initialize(DBContext d)
        {

            db = d;
        }


        public static void Add(string uname)
        {
            db.Universities.Add(new University(uname));
            db.SaveChanges();
        }

        public static void Edit(string uname)
        {
            db.Universities.OrderBy(u => u.Id).LastOrDefault().Name = uname;
            db.SaveChanges();
        }

        public static void Show()
        {
            foreach (var s in db.Universities.Select(u => u.Name))
            {
                Console.WriteLine(s);
            }
        }
        public static void Delete()
        {
            db.Universities.Remove(db.Universities.OrderBy(u => u.Id).LastOrDefault());
            db.SaveChanges();
        }

        public static void ShowSubjects()
        {
            var subcount = db.StudentSubjectAssociation.GroupBy(s => s.Subject.Name).Select(
                asoc => new
                {
                    SubjectName = asoc.Key,
                    Count = asoc.Count()
                }
                );

            foreach (var i in subcount)
            {
                Console.WriteLine(i.SubjectName + " : " + i.Count);
            }


        }

        public static void GetMin()
        {
            /* se executa strict pe db           var g = (await db.StudentSubjectAssociation
                             .GroupBy(s => new { s.Student.Id, s.Student.Name })
                             .Select(s => new StudentDTO { Count = s.Count(), Name = s.Key.Name }).ToListAsync())
                             .Aggregate((min, next) => min.Count < next.Count ? min : next);
            */
            //din pacate nu merge fara tolist
            var h = db.Students.ToList().GroupJoin(db.StudentSubjectAssociation,
                 student => student.Id,
                 asoc => asoc.StudentId,
                 (student, asoc) => new StudentDTO { Name = student.Name, Subjects = asoc.Select(s => s.Subject), Count = asoc.Count() }
                 ).Aggregate((min, next) => min.Count < next.Count ? min : next);

            Console.WriteLine(h.Name + " " + h.Count);


        }

        public static void ShowIfNone()
        {

            var g = db.StudentSubjectAssociation.Select(a => a.Subject);
            Console.WriteLine(db.Subjects.Except(g).Any());

        }

        public static void ShowStat()
        {

            /*  var g = db.StudentSubjectAssociation.Include("Subject").Include("Student").Include("Student.University").ToList().GroupBy(asoc => asoc.Student.University.Name)
                  .Select(group => new Stat
                  {
                      UniversityName = group.Key,
                      Students = group.GroupBy(s => s.Student).Select(
                      asoc => new StudentStat { Name = asoc.Key.Name, Subjects = asoc.Select(s => s.Subject.Name) }
                      )
                  });*/


            var g = db.Universities.Include("Students").ToList()
                .Select(u => new Stat
                {
                    UniversityName = u.Name
                    ,
                    Students = u.Students
                                .GroupJoin(db.StudentSubjectAssociation.Include("Subject"), student => student.Id, asoc => asoc.StudentId
                                   , (student, asoc) => new StudentStat { Name = student.Name, Subjects = asoc.Select(sub => sub.Subject.Name) }
                    )
                });

            foreach (var i in g)
                Console.WriteLine(i);

        }
    }
}
