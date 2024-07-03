using Newtonsoft.Json;
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

        [JsonProperty]
        private int _id { get; set; }
        [JsonProperty]
        private string _name { get; set; }

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

        }

        

    }
}
