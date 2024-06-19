using Newtonsoft.Json;
using STUDTEACHAPI.Models;
using System.Collections.Generic;
using System.IO;

namespace STUDTEACHAPI.Services
{
    public class DataService
    {
        private readonly string studentsFile = "students.json";
        private readonly string teachersFile = "teachers.json";

        public List<Studenttype> LoadStudents()
        {
            if (File.Exists(studentsFile))
            {
                var jsonData = File.ReadAllText(studentsFile);
                return JsonConvert.DeserializeObject<List<Studenttype>>(jsonData) ?? new List<Studenttype>();
            }
            return new List<Studenttype>();
        }

        public void SaveStudents(List<Studenttype> students)
        {
            var jsonData = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(studentsFile, jsonData);
        }

        public List<Teacher> LoadTeachers()
        {
            if (File.Exists(teachersFile))
            {
                var jsonData = File.ReadAllText(teachersFile);
                return JsonConvert.DeserializeObject<List<Teacher>>(jsonData) ?? new List<Teacher>();
            }
            return new List<Teacher>();
        }

        public void SaveTeachers(List<Teacher> teachers)
        {
            var jsonData = JsonConvert.SerializeObject(teachers, Formatting.Indented);
            File.WriteAllText(teachersFile, jsonData);
        }
    }
}
