namespace Lab4Softbinator.Entities
{
    public class StudentSubject
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public StudentSubject()
        {

        }
        public StudentSubject(Student student, Subject subject)
        {
            Student = student;
            Subject = subject;
        }

    }
}
