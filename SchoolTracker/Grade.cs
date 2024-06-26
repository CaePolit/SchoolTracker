using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolTracker
{
    class Grade
    {
        private int _studentId {  get; }
        private int _courseId { get; }
        private double _note { get; set; }
        private string _comment { get; set; }

        public Grade(int studentId, int courseId, double note, string comment = "")
        {
            //_course = course;
            _studentId = studentId;
            _courseId = courseId;
            _note = note;
            _comment = comment;
            //_student = GetStudentName();
        }

        public double GetGradeNote() { return _note; }
        public string GetGradeComment() { return _comment; }

        public int GetGradeCourseId() { return _courseId; }
        public int GetCurrentStudentId() { return _studentId; }


        public string GetGradeCourse(List<Course> courses, int courseId) 
        {
            Course courseToShow = courses.FirstOrDefault(p => p.GetCourseId() == courseId);
            return courseToShow.GetCourseName();
        }

        //public void CreateGrade()
    }



    
}
