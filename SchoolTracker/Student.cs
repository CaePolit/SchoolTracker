using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolTracker
{
    class Student
    {
        public static int numberOfStudents;

        [JsonProperty]
        private int _id { get; set;  }

        [JsonProperty]
        private string _name { get; set; }

        [JsonProperty]
        private string _lastname { get; set; }

        [JsonProperty]
        private DateOnly _birthday { get; set; }

        [JsonProperty]
        private List<Grade> _grades { get; set; }

        public Student (string name, string lastname, DateOnly birthday)
        {
            _id = GenerateStudentId(numberOfStudents);
            numberOfStudents++;
            _name = name;
            _lastname = lastname;
            _birthday = birthday; 
            _grades = new List<Grade> ();
            
        }

        // voici les methodes accesseurs
        // attention aux noms
        public string GetStudentName() { return _name; }
        public string GetStudentLastname() { return _lastname; }
        public DateOnly GetBirthday() { return _birthday; }
        public int GetStudentId() { return _id; }

        public List<Grade> GetStudentGrades() { return _grades; }

        public int GenerateStudentId(int numberOfStudents) //fonction génératrice de Id, elle peut etre incluse dans la class "StudentActions"
        {
            return numberOfStudents + 1;
        }


        public bool AddGrade(List<Course> courses, string course , double note, string comment )
        {

            int studentId = GetStudentId();
            Course courseToCheck = courses.FirstOrDefault(p => p.GetCourseName() == course);
            if (courseToCheck == null)
            {
                Console.WriteLine("Le cours à rentrer dans le notes de l'elève n'existe pas");
                return false;
            }
            int courseId = courseToCheck.GetCourseId();
            Grade gradeToAdd = new Grade(studentId, courseId, note, comment);
            _grades.Add(gradeToAdd);
            
            return true;
        }

        

        public string CalculateStudentMean()
        {
            if (_grades.Count != 0 ) 
            {
                double adition = 0;
                foreach (Grade grade in _grades)
                {
                    double note = grade.GetGradeNote();
                    adition += note;
                }
                string promedio = CustomRoundWithSuffix(adition / _grades.Count);
                return promedio;
            } 
            else { return "tu n'as pas de note"; }
                                                
        }

        public static string CustomRoundWithSuffix(double number)
        {
            int wholePart = (int)number;
            double fractionalPart = number - wholePart;

            double roundedValue;
            if (fractionalPart < 0.3)
            {
                roundedValue = wholePart;
            }
            else if (fractionalPart < 0.8)
            {
                roundedValue = wholePart + 0.5;
            }
            else
            {
                roundedValue = wholePart + 1;
            }

            return $"{roundedValue}/20";
        }
    }

}
