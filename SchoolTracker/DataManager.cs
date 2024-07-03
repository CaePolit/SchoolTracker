using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTracker
{
    static class DataManager
    {
        
        const string filePath = @"C:\Users\Carlos\Desktop\WCS\projet_console\SchoolTracker\data_file.json";
        
        public static List<Student> LoadStudents()
        {
            var data = ReadJsonFile(filePath);
            return data.Students ?? new List<Student>();
        }

        public static List<Course> LoadCourses()
        {
            var data = ReadJsonFile(filePath);
            return data.Courses ?? new List<Course>();
        }

        public static int LoadStudentsNumber()
        {
            var data = ReadJsonFile(filePath);
            int numberOfStudents;
            try
            {
                 numberOfStudents = data.IdCompteurStudent;
            }
            catch { numberOfStudents = 0; }
            return numberOfStudents;
        }
        public static int LoadCoursesNumber()
        {
            var data = ReadJsonFile(filePath);
            int numberOfCourses;
            try
            {
                numberOfCourses = data.IdCompteurCourse;
            }
            catch { numberOfCourses = 0; }
            return numberOfCourses;
        }

        public static void Save(List<Student> students,List<Course> courses,int numberOfStudents,int numberOfCourses)
        {
            var data =  new DataContainer();
            data.IdCompteurStudent += numberOfStudents;
            data.IdCompteurCourse += numberOfCourses;

            data.Courses = courses;
            data.Students = students;
            WriteJsonFile(data);
        }


        private static void WriteJsonFile(DataContainer data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        private static DataContainer ReadJsonFile(string filePath)
        {
            if (!File.Exists(filePath))
                return new DataContainer();

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<DataContainer>(json) ?? new DataContainer();
        }

        private class DataContainer
        {
            public int IdCompteurStudent { get; set; }
            public int IdCompteurCourse { get; set; }

            public List<Student> Students { get; set; }
            public List<Course> Courses { get; set; }
        }

    }
}
