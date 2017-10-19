using System;
using System.Collections.Generic;

namespace ChallengeStudentCourses
{
    public partial class Default : System.Web.UI.Page
    {
        private int CourseId;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void assignment1Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a List of Courses (add three example Courses ...
             * make up the details).  Each Course should have at least two
             * Students enrolled in them.  Use Object and Collection
             * Initializers.  Then, iterate through each Course and print
             * out the Course's details and the Students that are enrolled in
             * each Course.
             */
           // studen tlist is not populating
            List<Course> courses = new List<Course>() 
            {
                new Course() {CourseId=5001, Name = "Introduction to Photography", Students = new List<Student>() {
                    new Student() { StudentId= 12345, Name = "Amy Black" },//(,  "Undeclared",2017)
                    //new Student() {StudentId = 12345, Name = "Amy Black"},
                new Student() { StudentId=54321,Name = "Frank White" } } },//, "Philosphy",2021 
                new Course() {CourseId = 7010, Name = "Python for beginners", Students= new List<Student>() {
                new Student(){ StudentId=33354, Name = "Jose Sanchez" }, //, "Chemistry", 2020
                new Student(){ StudentId=32145,Name = "Pat Smith" } } },//,"Computer Science", 2020
                new Course() { CourseId=7011, Name =  "C#/.NET for beginners", Students= new List<Student>() {
                new Student(){ StudentId=40421,Name =  "Kai Murakami" },//, "Economics", 2021
                new Student() { StudentId=32145, Name ="Pat Smith" } } }//,"Computer Science", 2020
            };

            foreach (var Course in courses)
            {
                resultLabel.Text += 
                String.Format("Course ID: {0}&emsp;Name: {1}<br/>", Course.CourseId, Course.Name);
                foreach (var Student in Course.Students)
                {
                    resultLabel.Text += String.Format("Students:&emsp; ID: {0}&emsp;Name: {1}<br/>", Student.StudentId, Student.Name);
                }
               
            }
        }
        
        protected void assignment2Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a Dictionary of Students (add three example Students
             * ... make up the details).  Use the StudentId as the 
             * key.  Each student must be enrolled in two Courses.  Use
             * Object and Collection Initializers.  Then, iterate through
             * each student and print out to the web page each Student's
             * info and the Courses the Student is enrolled in.
             */
            // Bob's soln is to make a list here of courses, so just call course 1, course2 in below list
          
           Dictionary<int, Student> students = new Dictionary<int, Student>() 
           {
               { 12345, new Student { Name = "Amy Black", Major = "Undeclared", Year = 2017, Courses = new List<Course> {
               new Course {CourseId=5001, Name = "Introduction to Photography" },
                new Course {CourseId=7011, Name =  "C#/.NET for beginners"} } }},
               { 54321, new Student {  Name =  "Frank White", Major = "Philosphy", Year = 2021, Courses = new List<Course> {
               new Course{CourseId=5001, Name = "Introduction to Photography" },
               new Course {CourseId=7010, Name = "Python for beginners"} } } },
               { 32145, new Student {  Name =  "Pat Smith", Major = "Computer Science", Year = 2020, Courses = new List<Course> {
               new Course {CourseId=7010, Name = "Python for beginners" },
               new Course {CourseId=7011, Name =  "C#/.NET for beginners"} } } }

           };


           foreach (var Student in students)
           {
               resultLabel.Text += String.Format("<br/>{0} &emsp; {1} &emsp; {2} &emsp; {3}<br/>", 
                   Student.Key, Student.Value.Name, Student.Value.Major, Student.Value.Year);
               foreach (var course in Student.Value.Courses)
               {
                   resultLabel.Text += String.Format(" &emsp;Courses: {0} &emsp; {1}<br/>", course.CourseId, course.Name);
               }
           }
           
        }

        protected void assignment3Button_Click(object sender, EventArgs e)
        {
            /*
             * We need to keep track of each Student's grade (0 to 100) in a 
             * particular Course.  This means at a minimum, you'll need to add 
             * another class, and depending on your implementation, you will 
             * probably need to modify the existing classes to accommodate this 
             * new requirement.  Give each Student a grade in each Course they        
             * are enrolled in (make up the data).  Then, for each student, 
             * print out each Course they are enrolled in and their grade.
             */
            Student Students = new Student { StudentId = 32145, Name = "Pat Smith", Major = "Computer Science", Year = 2020 }; 
           // student.StudentId = 32145, student.Name = "Pat Smith";
            //List<Student> students = new List<Student>(); //just doing the one
            Students.Grades = new List<Grade>()
            {
                new Grade { Score = 90,  CourseId = 7010 } ,
                new Grade { Score = 95, CourseId = 7011 }
            };
            
            //foreach (var student in Students)
            //{ }
            resultLabel.Text += String.Format("<br/>Student: {0} &emsp; {1}<br/>", Students.StudentId, Students.Name);
            

            foreach (var grade in Students.Grades)
            {
                resultLabel.Text += String.Format("Class grades: {0}: {1}<br/>", grade.CourseId, grade.Score );    
            }


        }
    }
}