using Lab4Softbinator.Context;
using Lab4Softbinator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4Softbinator.Seeders
{
    public class InitialSeeder
    {
        private readonly DBContext db;


        public void Seed()
        {
            if (!db.Universities.Any())
            {
                var uni1 = new University("Harvard");
                var uni2 = new University("Stanford");
                var uni3 = new University("Cornell");
                db.Universities.Add(uni1);
                db.Universities.Add(uni2);
                db.Universities.Add(uni3);
                db.SaveChanges();
            }
            if (!db.Subjects.Any())
            {
                var sub1 = new Subject("Computer Science");
                var sub2 = new Subject("Literature");
                var sub3 = new Subject("Mathematics");
                db.Subjects.Add(sub1);
                db.Subjects.Add(sub2);
                db.Subjects.Add(sub3);
                db.SaveChanges();
            }


            if (!db.Students.Any())
            {
                var u1 = db.Universities.Where(u => u.Name == "Harvard").First();
                var stu1 = new Student(u1, "Radu");
                var stu2 = new Student(u1, "John");
                var stu3 = new Student(u1, "Jane");
                db.Students.Add(stu1);
                db.Students.Add(stu2);
                db.Students.Add(stu3);
                var u2 = db.Universities.Where(u => u.Name == "Cornell").First();
                var stu4 = new Student(u2, "George");
                var stu5 = new Student(u2, "Jarvis");
                db.Students.Add(stu4);
                db.Students.Add(stu5);
                db.SaveChanges();
            }

            if (!db.StudentSubjectAssociation.Any())
            {

                var s1 = db.Students.Where(s => s.Name == "Radu").First();
                var s2 = db.Students.Where(s => s.Name == "John").First();
                var s3 = db.Students.Where(s => s.Name == "Jane").First();
                var sub1 = db.Subjects.Where(s => s.Name == "Computer Science").First();
                var sub2 = db.Subjects.Where(s => s.Name == "Mathematics").First();
                db.StudentSubjectAssociation.Add(new StudentSubject(s3, sub1));
                db.StudentSubjectAssociation.Add(new StudentSubject(s1, sub1));
                db.StudentSubjectAssociation.Add(new StudentSubject(s1, sub2));
                db.StudentSubjectAssociation.Add(new StudentSubject(s2, sub1));
                db.SaveChanges();

            }
        }



        public InitialSeeder(DBContext db)
        {
            this.db = db;
        }



    }
}
