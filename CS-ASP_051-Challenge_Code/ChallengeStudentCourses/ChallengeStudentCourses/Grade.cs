using System.Collections.Generic;


namespace ChallengeStudentCourses
{
    public class Grade
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public uint Score { get; set; }
        public List<Student> Students { get; set; }

        public Grade()
        {
            this.CourseId = 0000;
            this. StudentId = 00000;
            this.Score = 999;

        }
    }
}