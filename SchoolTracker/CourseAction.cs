using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolTracker
{
    class CourseAction
    {
        
        private List<Student> _students { get; set; }
        private List<Course> _courses { get; set; }
        public CourseAction(List<Student> students, List<Course> courses)
        {
            _students = students;
            _courses = courses;
        }
        public List<Course> GetCoursesList() { return _courses; }
        public List<Student> GetStudentsList() { return _students; }

        public void ListCourses() // penser peutetre à diviser les display de la recopilation de donnes
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Liste de cours");
            Console.WriteLine("");
            foreach (Course course in GetCoursesList())
            {
                Console.WriteLine($"- {course.GetCourseName()}");
            }
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.ReadKey();
        }

        public bool AddCourse(string name) // cette fontion retourne un bool afin de l'utiliser dans les metodes d'affichage
        {
            //il faut chercher si le cours existe avant de faire un doublon
            Course courseToAdd = GetCoursesList().FirstOrDefault(p => p.GetCourseName() == name);
            if (courseToAdd == null)
            {
                _courses.Add(new Course(name));
                return true;
            }
            else { return false; } //Console.WriteLine("Le cours " + name + " existe déjà");

        }

        public void AskAddCourse()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Ajouter un nouveau cours au programme ");
            Console.WriteLine("");
            Console.WriteLine("Nom du Cours: ");
            Console.WriteLine("");
            string nameCourse = Console.ReadLine();
            if (AddCourse(nameCourse))
            {
                Console.WriteLine(nameCourse + " a bien été ajouté à la liste de cours.");
            }
            else { Console.WriteLine(nameCourse + " existe déjà dans la liste de cours."); }
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.ReadKey();
        }


        public bool RemoveCourse(int idCourse) // cette fontion retourne un bool afin de l'utiliser dans les metodes d'affichage
        {
            //il faut prevenir l'utilisateur si on veut eliminer un cours qui n'existe pas
            Course courseToDelete = GetCoursesList().FirstOrDefault(p => p.GetCourseId() == idCourse);
            if (courseToDelete != null)
            {
                _courses.Remove(courseToDelete);
                foreach (Student student in GetStudentsList())
                {
                    //int len = student.GetStudentGrades().Count();
                    bool stillGrades = true;
                    while (stillGrades)
                    {
                        Grade gradeToRemove = student.GetStudentGrades().FirstOrDefault(p => p.GetGradeCourseId() == idCourse);
                        student.GetStudentGrades().Remove(gradeToRemove);
                        if (gradeToRemove == null) { stillGrades = false; }
                    }

                    // la taille de student.GetStudentGrades() change, donc elle peut pas etre parcouru dans le foreach
                    // eliminier le code d'en bas
                    //foreach (Grade grade in student.GetStudentGrades()) 
                    //{
                    //    if (grade.GetGradeCourseId() == idCourse)
                    //    {
                    //        student.GetStudentGrades().Remove(grade);
                    //    }
                }
                return true;
            }
            else { return false; }
        }              
           

        public void AskRemoveCourse()
        {
            Console.Clear();
            bool action = false;
            while (!(action))
            {
                //
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("Supprimer un cours par son identifiant");
                Console.WriteLine("");
                Console.WriteLine("Id du Cours: ");
                Console.WriteLine("");
                string idCourse = Console.ReadLine();
                int courseId = Convert.ToInt32(idCourse);
                Course courseToShow = GetCoursesList().FirstOrDefault(p => p.GetCourseId() == courseId);
                if (courseToShow == null) 
                {
                    Console.WriteLine(" Il n'existe pas dans la liste de cours un possedant ce Id.");
                }
                else
                {
                    Console.WriteLine($"vous êtes sur d'éliminer '{courseToShow.GetCourseName()}'? (Y/N): \n"); //chercher à utiliszer un format key(Y==answer)?? du type key(true)
                    var answer = Console.ReadKey();
                    if (answer.Key == ConsoleKey.Y)
                    {
                        //ici on procede à eliminer le cours
                        action = RemoveCourse(courseId);
                        Console.WriteLine($"\n{courseToShow.GetCourseName()} a été supprimé de la liste de cours.");
                    }
                    else if (answer.Key == ConsoleKey.N)
                    {
                        Console.WriteLine("Registre non souvegardé. ");
                        action = true;
                        // ici demander si on veut continur avec la suppresion des cours
                    }
                }

                Console.WriteLine("");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.ReadKey();
            }
        }
        
    }

}
