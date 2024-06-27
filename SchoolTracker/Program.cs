using SchoolTracker;
using System;
using System.Xml.Linq;


class Program
{

    public static void Main(string[] args)
    {
        // voici les options initialisées des menus elèves et cours
        Dictionary<string, int> optionsStudent = new Dictionary<string, int>
        {
            { "lister les elèves", 1 },
            { "créer un nouveau elève", 2 },
            { "consulter un elève existants", 3 },
            { "ajouter une note et une appréciation pour un cours sur un élève existant", 4 },
            { "revenir au menu principal", 5 }
        };

        Dictionary<string, int> optionsCourses = new Dictionary<string, int>
        {
            { "lister les cours existants", 1 },
            { "ajouter un nouveau cours au programme", 2 },
            { "supprimer un cours par son identifiant", 3 },
            { "revenir au menu principal", 4 },
        };


        //ici en dehors de la boucle on doit avoir acces au ficher JSON
        //pour charger nos donnes

        //ici on crée la liste d'elèves et de cours, plus tard on remplacera cette parrti pour une fonction
        //qui lise le dit fichier .JSON

        List<Course> cours = new List<Course>();
        Course cours1 = new Course("Math");
        Course cours2 = new Course("Histoire");
        List<Student> eleves = new List<Student>();
        int numberOfStudents = 0;
        Student student1 = new Student("Juan", "Pachanga", "01/02/1995");
        Student student2 = new Student("Pedro", "Navaja", "10/06/1998");

        //on remplie les listes en téléchargent les données, d'abord on mettra 2 elèves et 2 cours à la main
        cours.Add(cours1);
        cours.Add(cours2);
        eleves.Add(student1);
        eleves.Add(student2);
        while (true) // boucle infini du programe main
        {
            // le menu principal doit etre à l'interieur d'une bouble infini, et les
            // submenus à leur tour. Les boucles des sub menus doivent etre à l'interieur
            // de la boucle du menu mère.
            while (true)
            {
                //ici on va commencer à creer notre menu principal
                DisplayPrincipalMenu();
                var answerPrincipal = Console.ReadKey();
                //string entry1 = Console.ReadLine().ToLower();
                if (!(answerPrincipal.Key == ConsoleKey.E || answerPrincipal.Key == ConsoleKey.C))
                {
                    DisplayPrincipalMenuError();
                    //Console.ReadLine();
                    //entry1 = Console.ReadLine().ToLower();
                }
                while (answerPrincipal.Key == ConsoleKey.E) //pense à implementer un if
                {
                    DisplayStudentMenu();
                    StudentAction studentAction = new StudentAction(eleves, cours);

                    var answerStudent = Console.ReadKey();
                    // ici on appel les classes et execute les actions
                    // creer un stich case avec le numeros du menu elèves

                    switch (answerStudent.Key)
                    {
                        case ConsoleKey.L:
                            studentAction.ListStudents();
                            break;
                        case ConsoleKey.N:
                            studentAction.CreateNewStudent();
                            break;
                        case ConsoleKey.C:
                            studentAction.ConsultStudent();
                            break;
                        case ConsoleKey.A:
                            studentAction.AddGradeAndComment();
                            break;
                        case ConsoleKey.R:
                            break;
                        default:
                            DisplayStudentMenuError();
                            //Console.ReadLine();
                            break;
                    }
                    if (answerStudent.Key == ConsoleKey.R) break;
                    //Console.ReadLine();
                    //answerPrincipal = ConsoleKey.R;
                }
                while (answerPrincipal.Key == ConsoleKey.C)
                {
                    DisplayCoursesMenu();
                    CourseAction courseAction = new CourseAction(eleves, cours);
                    var answerCourse = Console.ReadKey();
                    //string entry2 = Console.ReadLine().ToLower();
                    // ici on appel les classes et execute les actions
                    // créer un sitch case avec les Key values du menu cours 
                    switch (answerCourse.Key)
                    {
                        case ConsoleKey.L:
                            courseAction.ListCourses();
                            break;
                        case ConsoleKey.A:
                            courseAction.AskAddCourse();
                            break;
                        case ConsoleKey.S:
                            courseAction.AskRemoveCourse();
                            break;
                        case ConsoleKey.R:
                            break;
                        default:
                            DisplayCoursesMenuError();
                            //Console.ReadLine();
                            break;
                    }
                    if (answerCourse.Key == ConsoleKey.R) break;

                }
                
            }
        
        }
    }
            
    public static void DisplayPrincipalMenu()
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Menu principal");
        Console.WriteLine("");
        Console.WriteLine("Choisissez:");
        Console.WriteLine("");
        Console.WriteLine("- Elèves");
        Console.WriteLine("");
        Console.WriteLine("- Cours");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("E/C?");
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("");
    }

    public static void DisplayPrincipalMenuError()
    {
        Console.Clear();
        while (true)
        {
            //
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Error de saisie! Veillez rentrer comme commenade de ligne, soit E, soit C");
            Console.WriteLine("");
            Console.WriteLine("Tapez Enter pour continuer");
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------------------");
            var answer = Console.ReadKey();
            if (answer.Key == ConsoleKey.Enter) { break; }
            Console.WriteLine("");
        }
    }

    public static void DisplayStudentMenu()
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("");
        Console.WriteLine("Menu Elèves");
        Console.WriteLine("");
        Console.WriteLine("Choisissez une action:");
        Console.WriteLine("");
        Console.WriteLine("1) Lister les elèves");
        Console.WriteLine("2) Créer un nouveau elève");
        Console.WriteLine("3) Consulter un elève existant");
        Console.WriteLine("4) Ajouter une note et une appréciation pour un cours sur un élève existant");
        Console.WriteLine("5) Revenir au menu principal");
        Console.WriteLine("");
        Console.WriteLine(" 'L', 'N', 'C', 'A' ou 'R'?");
        Console.WriteLine("");
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("");
    }

    public static void DisplayStudentMenuError()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Error de saisie! Veillez rentrer l'une des 5 actions listées");
            Console.WriteLine("");
            Console.WriteLine("Tapez Enter pour continuer");
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------------------");
            var answer = Console.ReadKey();
            if (answer.Key == ConsoleKey.Enter) { break; }
            Console.WriteLine("");
        }
    }  

    public static void DisplayCoursesMenu()
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("");
        Console.WriteLine("Menu Cours");
        Console.WriteLine("");
        Console.WriteLine("Choisissez une action:");
        Console.WriteLine("");
        Console.WriteLine("1) Lister les cours existants");
        Console.WriteLine("2) Ajouter un nouveau cours au programme");
        Console.WriteLine("3) Supprimer un cours par son identifiant");
        Console.WriteLine("4) Revenir au menu principal");
        Console.WriteLine("");
        Console.WriteLine(" 'L', 'A', 'S' ou 'R'?");
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("");
    }

    public static void DisplayCoursesMenuError()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Error de saisie! Veillez rentrer l'une des 4 actions listées");
            Console.WriteLine("");
            Console.WriteLine("Tapez Enter pour continuer");
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------------------");
            var answer = Console.ReadKey();
            if (answer.Key == ConsoleKey.Enter) { break; }
            Console.WriteLine("");
        }
        
    }

}