using System.Collections.Generic;


namespace ChallengeStudentCourses
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Major { get; set; }
        public int Year { get; set; }
        public List<Course> Courses { get; set; }
        public List<Grade> Grades { get; set; }// think this through more

        public Student() { }

        public Student(int StudentId, string Name)
        {
            this.StudentId = 00000;
            this.Name = "Undefined";
        }

        public Student(int StudentId, string Name, string Major, int Year)
        {
            this.StudentId = 00000;
            this.Name = "Undefined";
            this.Major = "Undefined";
            this.Year = 9999;
        }

                   
    }
}