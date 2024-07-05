﻿using SchoolTracker;
using Serilog;
using System;
using System.Xml.Linq;


class Program
{

    public static void Main(string[] args)
    {
        
        string logDirectory = "logs";
        // Vérifier si le répertoire de logs existe
        if (!Directory.Exists(logDirectory))
        {
            try
            {
                // Essayer de créer le répertoire de logs
                Directory.CreateDirectory(logDirectory);
                Console.WriteLine("Log directory created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to create log directory: {ex.Message}");
                return; // Quitter l'application si nous ne pouvons pas créer le répertoire
            }
        }

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File(Path.Combine(logDirectory, "log.txt"), rollingInterval: RollingInterval.Day) 
            .CreateLogger();

        //ici en dehors de la boucle on doit avoir acces au ficher JSON
        //pour charger nos donnes
        //string folderPath = @"C:\Users\Carlos\Desktop\WCS\projet_console\SchoolTracker";
        //string fileName = "data_file.json";
        //string fullPath = Path.Combine(folderPath, fileName);

        Log.Information("Application console démarre");
        //ici on crée la liste d'elèves et de cours, plus tard on remplacera cette parrti pour une fonction
        //qui lise le dit fichier .JSON
        List<Student> eleves = DataManager.LoadStudents();
        List<Course> cours = DataManager.LoadCourses();
        Log.Information("Téléchargement des données depuis le fichier .jason");


        while (true) // boucle infini du programe main
        {
            // le menu principal doit etre à l'interieur d'une bouble infini, et les
            // submenus à leur tour. Les boucles des sub menus doivent etre à l'interieur
            // de la boucle du menu mère.
            while (true)
            {
                //ici on va commencer à creer notre menu principal
                Menu.DisplayPrincipalMenu();
                Log.Information("Display menu principal");
                var answerPrincipal = Console.ReadKey();
                Log.Information("Key pressed: {Key}", answerPrincipal.Key);

                if (!(answerPrincipal.Key == ConsoleKey.NumPad1 || answerPrincipal.Key == ConsoleKey.NumPad2))
                {
                    Menu.DisplayPrincipalMenuError();
                    Log.Error("message d'error de frappe");
                }
                while (answerPrincipal.Key == ConsoleKey.NumPad1) 
                {
                    Menu.DisplayStudentMenu();
                    Log.Information("Display menu elèves");
                    StudentAction studentAction = new StudentAction(eleves, cours);

                    var answerStudent = Console.ReadKey();
                    Log.Information("Key pressed: {Key}", answerStudent.Key);
                    // ici on appel les classes et execute les actions
                    // creer un stich case avec le numeros du menu elèves

                    switch (answerStudent.Key)
                    {
                        case ConsoleKey.NumPad1:
                            Log.Information("Display liste d'elèves");
                            studentAction.ListStudents();
                            break;
                        case ConsoleKey.NumPad2:
                            Log.Information("Display créer un nouveau elève");
                            studentAction.CreateNewStudent();
                            break;
                        case ConsoleKey.NumPad3:
                            Log.Information("Display consulter un elève");
                            studentAction.ConsultStudent();
                            break;
                        case ConsoleKey.NumPad4:
                            Log.Information("Display ajouter une note + appréciation");
                            studentAction.AddGradeAndComment();
                            break;
                        case ConsoleKey.NumPad5:
                            Log.Information("Retour au menu principal");
                            break;
                        default:
                            Menu.DisplayStudentMenuError();
                            Log.Error("error de frappe");
                            break;
                    }
                    if (answerStudent.Key == ConsoleKey.NumPad5) break;
                    Log.CloseAndFlush();
                }
                while (answerPrincipal.Key == ConsoleKey.NumPad2)
                {
                    Menu.DisplayCoursesMenu();
                    Log.Information("Display menu cours");
                    CourseAction courseAction = new CourseAction(eleves, cours);
                    var answerCourse = Console.ReadKey();
                    Log.Information("Key pressed: {Key}", answerCourse.Key);
                    //string entry2 = Console.ReadLine().ToLower();
                    // ici on appel les classes et execute les actions
                    // créer un sitch case avec les Key values du menu cours 
                    switch (answerCourse.Key)
                    {
                        case ConsoleKey.NumPad1:
                            Log.Information("Display liste d'elèves");
                            courseAction.ListCourses();
                            break;
                        case ConsoleKey.NumPad2:
                            Log.Information("Display ajouter un cours");
                            courseAction.AskAddCourse();
                            break;
                        case ConsoleKey.NumPad3:
                            Log.Information("Display supprimer un cours");
                            courseAction.AskRemoveCourse();
                            break;
                        case ConsoleKey.NumPad4:
                            Log.Information("Retour au menu principal");
                            break;
                        default:
                            Menu.DisplayCoursesMenuError();
                            Log.Error("error de frappe");
                            break;
                    }
                    if (answerCourse.Key == ConsoleKey.NumPad4) break;
                    Log.CloseAndFlush();
                }
                
            }
            
        }
        
    }   
    
}