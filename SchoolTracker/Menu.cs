using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTracker
{
    internal class Menu
    {
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
}

