using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolTracker
{
    class StudentAction 
    {
        // voici les options initialisées des menus elèves et cours
        

        private List<Student> _students { get; set; }
        private List<Course> _courses { get; set; }
        public StudentAction(List<Student> students, List<Course> courses) 
        {
            _students = students;
            _courses = courses;
        }

        public List<Student> GetStudentsList() { return _students; }
        public List<Course> GetCoursesList() { return _courses; }
        public int GetNumberOfStudents()
            { return _students.Count; }
        public int GetNumberOfCourses()
            { return _courses.Count; }
        public void ListStudents() //penser peutetre à diviser les display de la recopilation de donnes
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Liste d'elèves");
            Console.WriteLine("");
            foreach (Student student in GetStudentsList())
            {
                Console.WriteLine($"- Name:{student.GetStudentName()} Lastname:{student.GetStudentLastname()} Birthday:{student.GetBirthday()}");
            }
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.ReadKey();
        }

        public void CreateNewStudent()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Rentrer le prenom du elève: ");
            string name = Console.ReadLine();
            //Console.WriteLine(entry1);
            Console.WriteLine("Rentrer le nom du elève: ");
            string lastname = Console.ReadLine();
            Console.WriteLine("Rentrer la date de naissance du elève: ");
            string entry3 = Console.ReadLine();
            DateOnly dateValue;
            bool isValidDate = DateOnly.TryParseExact(entry3, "dd/MM/yyyy",CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue);
            while (!(isValidDate))
            {
                Console.WriteLine("Format de date invalide.");
                Console.WriteLine("Rentrer la date de naissance du elève: ");
                entry3 = Console.ReadLine();
                isValidDate = DateOnly.TryParseExact(entry3, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue);
            }
            // verification si l'elève existe
            Student StudentNameToAdd = GetStudentsList().FirstOrDefault(p => p.GetStudentName() == name);
            Student StudentLastnameToAdd = GetStudentsList().FirstOrDefault(q => q.GetStudentLastname() == lastname);
            Student StudentBirthdayToAdd = GetStudentsList().FirstOrDefault(s => s.GetBirthday() == dateValue);
            if ((StudentNameToAdd != null && StudentLastnameToAdd != null) && StudentBirthdayToAdd != null) //((StudentNameToAdd != null && StudentLastnameToAdd != null) && StudentBirthdayToAdd != null)
            {
                Console.WriteLine("");
                Console.WriteLine("Attention! un elève avec le même nom, prenom et  date de naissance fait partie de la liste");
                Console.WriteLine("");
                name = $"{name}*";
                lastname = $"{lastname}*";
            }
            var newStudent = new Student(name, lastname, dateValue);
            Console.WriteLine("Voici l'Id unique. Veillez le noter et garder precieusement:");
            Console.WriteLine(newStudent.GetStudentId());

            _students.Add(newStudent);
            DataManager.Save(_students, _courses, GetNumberOfStudents(), GetNumberOfCourses());

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.ReadKey();

        }

        public void ConsultStudent()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Rentrer le numero d'identification unique du elève: ");
            int id;
            while (true)
            {
                //verification d'entier
                string entryId = Console.ReadLine();
                bool resultat = int.TryParse(entryId, out id);
                if (!(resultat))
                {
                    Console.WriteLine("format invalide. Veillez rentrer un numero entier.");
                }
                else break;
                
            }
            // verification si le id existe dans la liste d'elèves
            bool isStudent = VerifiedStudent(id);
            if (!(isStudent))
            {
                Console.WriteLine("Le numero que vous venez de rentre ne figurez pas dans la liste d'elèves.");
            }
            else
            {
                Student StudentToShow = GetStudentsList().FirstOrDefault(p => p.GetStudentId() == id);
                Console.WriteLine("");
                Console.WriteLine("Information sur l'elève: ");
                Console.WriteLine("");
                Console.WriteLine("Nom:" +StudentToShow.GetStudentLastname());
                Console.WriteLine("");
                Console.WriteLine("Prénom:" + StudentToShow.GetStudentName());
                Console.WriteLine("");
                Console.WriteLine("Date de naissance:" + StudentToShow.GetBirthday());
                Console.WriteLine("");
                Console.WriteLine("Résultats scolaires:");
                Console.WriteLine("");
                foreach (Grade grade in StudentToShow.GetStudentGrades())
                {
                    int coursId = grade.GetGradeCourseId();
                    //Course courseToShow = courses.FirstOrDefault(p => p.GetCourseId() == coursId);
                    Console.WriteLine("Cours : " + grade.GetGradeCourse(GetCoursesList(), coursId)); // 'abord on cherche à trouver le Id du cours lié à la note, et puis on chercher le cours dans la liste de cours qui a le Id
                    Console.WriteLine("__Note: "+ grade.GetGradeNote()+"/20");
                    Console.WriteLine("__Appréciation : "+grade.GetGradeComment());
                    Console.WriteLine("");
                }
                Console.WriteLine("");
                Console.WriteLine("Moyenne: "+StudentToShow.CalculateStudentMean());
                Console.WriteLine("");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.ReadKey();

            }
        }

        public bool VerifiedStudent(int id) { return GetStudentsList().Exists(p => p.GetStudentId() == id); }

        public void AddGradeAndComment()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Ajouter une note et une appréciation pour un cours sur un élève existant");
            Console.WriteLine("");
            Console.WriteLine("Rentrer l'identifiant du elève: ");
            string studentIdEntry = Console.ReadLine();
            //icic pense à implementer les fontions de try imput
            Student studentTosearch = GetStudentsList().FirstOrDefault(p => p.GetStudentId() == Convert.ToInt32(studentIdEntry));
            Console.WriteLine("");
            Console.WriteLine("Rentrer le cours: ");
            string coursEntry = Console.ReadLine();
            //icic pense à implementer les fontions de try imput
            Console.WriteLine("Rentrer la note: ");
            string noteEntry = Console.ReadLine();
            //verifier que noteEntry est bel est bien un double avec la methode double.TryParse()
            double note = Convert.ToDouble(noteEntry);
            Console.WriteLine("");
            Console.WriteLine("Rentrer une appréciation (Facultatif): ");
            string comment = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Recapitulatif");
            Console.WriteLine("Elève: "+studentTosearch.GetStudentLastname()+" "+studentTosearch.GetStudentName);
            Console.WriteLine("Cours: "+coursEntry);
            Console.WriteLine("Note: "+ noteEntry+"/20");
            Console.WriteLine("Appréciation: "+comment);

            Console.WriteLine("vous confirmer le registre? (Y/N): \n"); //chercher à utiliszer un format key(Y==answer)?? du type key(true)
            var answer =Console.ReadKey();
            if (answer.Key == ConsoleKey.Y)
            {
                studentTosearch.AddGrade(GetCoursesList(), coursEntry, note, comment);
                DataManager.Save(_students, _courses,GetNumberOfStudents(), GetNumberOfCourses());
            }
            else if (answer.Key == ConsoleKey.N)
            {
                Console.WriteLine("Registre non souvegardé. ");

            }
            else 
            {
                Console.WriteLine("gros naze ");
            }

            Console.WriteLine("----------------------------------------------------------------------");
            Console.ReadKey();
                        
        }

    }
}
