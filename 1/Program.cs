using System;
using Newtonsoft.Json;
using System.IO;

namespace UniversityProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Загрузка данных из JSON-файла
            var jsonData = File.ReadAllText("data.json");
            var universityData = JsonConvert.DeserializeObject<UniversityData>(jsonData);

            // Пример добавления новой оценки
            universityData.AddGrade(1, 102, 4);

            // Пример вывода оценок для студента
            universityData.GetGradesForStudent(1);

            // Сохранение обновленных данных в JSON-файл
            var updatedJsonData = JsonConvert.SerializeObject(universityData, Formatting.Indented);
            File.WriteAllText("data.json", updatedJsonData);
        }
    }
}
