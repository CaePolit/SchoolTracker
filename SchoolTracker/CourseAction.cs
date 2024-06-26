using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTracker
{
    class CourseAction
    {
        Dictionary<string, int> optionsCourses = new Dictionary<string, int>
        {
            { "lister les cours existants", 1 },
            { "ajouter un nouveau cours au programme", 2 },
            { "supprimer un cours par son identifiant", 3 },
            { "revenir au menu principal", 4 },
        };
        private List<Student> _students { get; set; }
        private List<Course> _courses { get; set; }
        public CourseAction(List<Course> courses)
        {
            //_students = students;
            _courses = courses;
        }
        public List<Course> GetCoursesList() { return _courses; }

        public void ListCourses() // penser peutetre à diviser les display de la recopilation de donnes
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Liste de cours");
            Console.WriteLine("");
            foreach (Course course in GetCoursesList())
            {
                Console.WriteLine($"- {course}");
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
                return true;
            }
            else { return false; }

        }

        public void AskRemoveCourse()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Supprimer un cours par son identifiant");
            Console.WriteLine("");
            Console.WriteLine("Id du Cours: ");
            Console.WriteLine("");
            string idCourse = Console.ReadLine();
            Course courseToShow = GetCoursesList().FirstOrDefault(p => p.GetCourseId() == Convert.ToInt32(idCourse));
            if (RemoveCourse(Convert.ToInt32(idCourse)))
            {
                Console.WriteLine(courseToShow.GetCourseName() + " a été supprimé de la liste de cours.");
            }
            else { Console.WriteLine(courseToShow.GetCourseName() + " n'existe pas dans la liste de cours."); }
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.ReadKey();
        }
        //
    }
}
