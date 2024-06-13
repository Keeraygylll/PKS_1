using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversityProject
{
    public class Student
    {
        public int StudentCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
    }

    public class Subject
    {
        public int SubjectCode { get; set; }
        public string Name { get; set; }
        public int LectureHours { get; set; }
        public int PracticeHours { get; set; }
    }

    public class StudyPlan
    {
        public int StudentCode { get; set; }
        public int SubjectCode { get; set; }
        public int Grade { get; set; }
    }

    // Класс для работы с данными оценок и предметов
    public class UniversityData
    {
        public List<Student> Students { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<StudyPlan> StudyPlans { get; set; }

        public UniversityData()
        {
            Students = new List<Student>();
            Subjects = new List<Subject>();
            StudyPlans = new List<StudyPlan>();
        }

        public void AddGrade(int studentCode, int subjectCode, int grade)
        {
            StudyPlans.Add(new StudyPlan { StudentCode = studentCode, SubjectCode = subjectCode, Grade = grade });
        }

        public void GetGradesForStudent(int studentCode)
        {
            var grades = StudyPlans
                .Where(sp => sp.StudentCode == studentCode)
                .Join(Subjects, sp => sp.SubjectCode, sub => sub.SubjectCode, (sp, sub) => new { Subject = sub.Name, Grade = sp.Grade });

            int totalGrades = grades.Count();
            int excellentGrades = grades.Count(g => g.Grade >= 4);
            int goodGrades = grades.Count(g => g.Grade == 3);
            int satisfactoryGrades = grades.Count(g => g.Grade <= 2);

            Console.WriteLine($"Total grades: {totalGrades}");
            Console.WriteLine($"Excellent: {(double)excellentGrades / totalGrades:P}");
            Console.WriteLine($"Good: {(double)goodGrades / totalGrades:P}");
            Console.WriteLine($"Satisfactory: {(double)satisfactoryGrades / totalGrades:P}");

            foreach (var grade in grades)
            {
                Console.WriteLine($"Subject: {grade.Subject}, Grade: {grade.Grade}");
            }
        }
    }
}
