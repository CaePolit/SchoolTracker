using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTracker
{
    class Course
    {
        public static int numberOfCourses;
        private int _id { get; set; }
        private string _name { get; set; }
        //public List<Course> _courses { get; set; }

        public Course(string name)
        {
            _id = GenerateCourseId(numberOfCourses);
            numberOfCourses++;
            _name = name;
        }

        public int GetCourseId() { return _id; }
        public string GetCourseName() { return _name; }


        public int GenerateCourseId(int numberOfCourses)
        {
            return numberOfCourses + 1;

            //char[] nameDecomposed = _name.ToCharArray();
            //int id = 0;
            //foreach (char c in nameDecomposed) { id = id + Convert.ToInt32(c); }
            //return id;
        }

        

    }
}
