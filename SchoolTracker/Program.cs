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
        string folderPath = @"C:\Users\Carlos\Desktop\WCS\projet_console\SchoolTracker";
        string fileName = "data_file.json";
        string fullPath = Path.Combine(folderPath, fileName);
        //DataManager dataManager = new DataManager(fullPath);
        //ici on crée la liste d'elèves et de cours, plus tard on remplacera cette parrti pour une fonction
        //qui lise le dit fichier .JSON
        List<Student> eleves = DataManager.LoadStudents();
        List<Course> cours = DataManager.LoadCourses();

        
                
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
                
                if (!(answerPrincipal.Key == ConsoleKey.NumPad1 || answerPrincipal.Key == ConsoleKey.NumPad2))
                {
                    DisplayPrincipalMenuError();
                    
                }
                while (answerPrincipal.Key == ConsoleKey.NumPad1) 
                {
                    DisplayStudentMenu();
                    StudentAction studentAction = new StudentAction(eleves, cours);

                    var answerStudent = Console.ReadKey();
                    // ici on appel les classes et execute les actions
                    // creer un stich case avec le numeros du menu elèves

                    switch (answerStudent.Key)
                    {
                        case ConsoleKey.NumPad1:
                            studentAction.ListStudents();
                            break;
                        case ConsoleKey.NumPad2:
                            studentAction.CreateNewStudent();
                            break;
                        case ConsoleKey.NumPad3:
                            studentAction.ConsultStudent();
                            break;
                        case ConsoleKey.NumPad4:
                            studentAction.AddGradeAndComment();
                            break;
                        case ConsoleKey.NumPad5:
                            break;
                        default:
                            DisplayStudentMenuError();
                            
                            break;
                    }
                    if (answerStudent.Key == ConsoleKey.NumPad5) break;
                    
                }
                while (answerPrincipal.Key == ConsoleKey.NumPad2)
                {
                    DisplayCoursesMenu();
                    CourseAction courseAction = new CourseAction(eleves, cours);
                    var answerCourse = Console.ReadKey();
                    //string entry2 = Console.ReadLine().ToLower();
                    // ici on appel les classes et execute les actions
                    // créer un sitch case avec les Key values du menu cours 
                    switch (answerCourse.Key)
                    {
                        case ConsoleKey.NumPad1:
                            courseAction.ListCourses();
                            break;
                        case ConsoleKey.NumPad2:
                            courseAction.AskAddCourse();
                            break;
                        case ConsoleKey.NumPad3:
                            courseAction.AskRemoveCourse();
                            break;
                        case ConsoleKey.NumPad4:
                            break;
                        default:
                            DisplayCoursesMenuError();
                            //Console.ReadLine();
                            break;
                    }
                    if (answerCourse.Key == ConsoleKey.NumPad4) break;

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
        Console.WriteLine("1) Elèves");
        Console.WriteLine("");
        Console.WriteLine("2) Cours");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("1 ou 2?");
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
            Console.WriteLine("Error de saisie! Veillez rentrer comme commenade de ligne, soit 1, soit 2");
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
        Console.WriteLine(" tapez soit '1', '2', '3', '4' ou '5'");
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
            Console.WriteLine("Error de saisie! Veillez rentrer soit '1', '2', '3', '4' ou '5'");
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
        Console.WriteLine(" tapez soit '1', '2', '3' ou '4'");
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
            Console.WriteLine("Error de saisie! Veillez rentrer tapez soit '1', '2', '3' ou '4'");
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