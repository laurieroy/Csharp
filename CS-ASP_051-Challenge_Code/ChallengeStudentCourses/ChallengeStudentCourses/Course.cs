using System.Collections.Generic;


namespace ChallengeStudentCourses
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public int Grade { get; set; }

        public Course() { }

        public Course(int CourseId, string Name)
        {
            this.CourseId = 0000;
            this.Name = "Undefined";
        }
        public List<Student> studentList = new List<Student>();

        public Course(int CourseId, string Name, int Grade, List<Student> studentList) 
        {
            this.CourseId = 0000;
            this.Name = "Undefined";  
            this.Grade = 999;
            //this.studentList = ;
        }
        
    }
}