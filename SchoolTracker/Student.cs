using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolTracker
{
    class Student
    {
        public static int numberOfStudents;
        private int _id { get; set;  }
        private string _name { get; set; }
        private string _lastname { get; set; }
        private DateOnly _birthday { get; set; }

        private List<Grade> _grades { get; set; }

        //private List<double> _notes { get; set; }
        //private List<string> _comments { get; set; }


        public Student (string name, string lastname, string birthday)
        {
            _id = GenerateStudentId(numberOfStudents);
            numberOfStudents++;
            _name = name;
            _lastname = lastname;
            _birthday = DateOnly.ParseExact(birthday, "dd/MM/yyyy"); //DateOnly.ParseExact(birthDate, "dd/MM/yyyy");
            _grades = new List<Grade> ();
            
        }

        // voici les methodes acceseurs
        public string GetStudentName() { return _name; }
        public string GetStudentLastname() { return _lastname; }
        public DateOnly GetBirthday() { return _birthday; }
        public int GetStudentId() { return _id; }

        public List<Grade> GetStudentGrades() { return _grades; }

        public int GenerateStudentId(int numberOfStudents) //fonction génératrice de Id, elle peut etre incluse dans la class "StudentActions"
        {
            return numberOfStudents + 1;
        }

        //public bool VerifiedStudent(List<Student> students, int id) { return students.Exists(p => p._id == id); }

        public bool AddGrade(List<Course> courses, string course , double note, string comment )
        {
            // utilise la meme filo d'ensous pour faire, sauf que il y a pas besoin de s'saurer s'il existe une note parei. 
            // par contre iol faut repere dabord l'ekeve et le cours. rappelle toi que la liste de grades, avec la class grade, est
            // à l'interieur de la class student

            int studentId = GetStudentId();
            Course courseToCheck = courses.FirstOrDefault(p => p.GetCourseName() == course);
            if (courseToCheck == null)
            {
                //DisplayAddGradeError();
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
            double adition = 0;
            foreach (Grade grade in _grades)
            {
                double note = grade.GetGradeNote();
                adition += note;
            }
             string promedio = CustomRoundWithSuffix(adition / _grades.Count);
            
            return promedio;
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


    // construire une fonction DisplayStudent qui prenne la valeur de ConsultStudent comme argument et retourne toutes les 
    // infos concernant l'elève sauf l'id. Cette foction/methode peut apartenir à la classe "StudentActions"



    // Student StudentToAdd = students.FirstOrDefault(p => p._name == name);


    

   
}
