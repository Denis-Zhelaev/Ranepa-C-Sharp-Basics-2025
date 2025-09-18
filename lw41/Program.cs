using System;
using System.Collections.Generic;
using System.Linq;

namespace lw41
{
    abstract class Person
    {
        public string Name { get; }
        public int Age { get; }

        protected Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public abstract string getInfo();
    }

    class Student : Person
    {
        public int Grade { get; }
        public string TeacherName { get; }

        public Student(string name, int age, int grade, string teacherName = "") : base(name, age)
        {
            Grade = grade;
            TeacherName = teacherName;
        }

        public override string getInfo()
        {
            string info = "Имя: " + Name + ", Возраст: " + Age + ", Курс: " + Grade;
            if (!string.IsNullOrEmpty(TeacherName))
            {
                info += ", Преподаватель: " + TeacherName;
            }
            return info;
        }
    }

    class Teacher : Person
    {
        public string Subject { get; }

        public Teacher(string name, int age, string subject) : base(name, age)
        {
            Subject = subject;
        }

        public override string getInfo()
        {
            return "Имя: " + Name + ", Возраст: " + Age + ", Предмет: " + Subject;
        }
    }

    class Program
    {
        static List<Student> students = new List<Student>();
        static List<Teacher> teachers = new List<Teacher>();

        static void Main(string[] args)
        {
            students.Add(new Student("Иван Иванов", 20, 2, "Анна Сергеевна"));
            students.Add(new Student("Петр Петров", 21, 3, "Иван Петрович"));
            students.Add(new Student("Мария Сидорова", 19, 1, "Анна Сергеевна"));
            students.Add(new Student("Анна Козлова", 17, 1, ""));
            students.Add(new Student("Сергей Смирнов", 22, 4, "Иван Петрович"));

            teachers.Add(new Teacher("Анна Сергеевна", 35, "Математика"));
            teachers.Add(new Teacher("Иван Петрович", 40, "Физика"));
            teachers.Add(new Teacher("Светлана Михайловна", 38, "Математика"));

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n=== Меню управления ===");
                Console.WriteLine("1. Добавить студента");
                Console.WriteLine("2. Добавить преподавателя");
                Console.WriteLine("3. Показать всех студентов");
                Console.WriteLine("4. Показать всех преподавателей");
                Console.WriteLine("5. Фильтрация студентов старше 18 лет");
                Console.WriteLine("6. Группировка студентов по курсу");
                Console.WriteLine("7. Поиск преподавателей по предмету");
                Console.WriteLine("8. Статистика по предметам");
                Console.WriteLine("9. Объединение студентов и преподавателей");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        addStudent();
                        break;
                    case "2":
                        addTeacher();
                        break;
                    case "3":
                        showAllStudents();
                        break;
                    case "4":
                        showAllTeachers();
                        break;
                    case "5":
                        filterStudentsByAge();
                        break;
                    case "6":
                        groupStudentsByGrade();
                        break;
                    case "7":
                        findTeachersBySubject();
                        break;
                    case "8":
                        showSubjectStatistics();
                        break;
                    case "9":
                        showStudentTeacherRelations();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
            }
        }

        static void addStudent()
        {
            Console.Write("Введите имя студента: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Имя не может быть пустым!");
                return;
            }

            Console.Write("Введите возраст студента: ");
            if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
            {
                Console.WriteLine("Некорректный возраст! Установлено значение 18.");
                age = 18;
            }

            Console.Write("Введите курс студента (1-4): ");
            if (!int.TryParse(Console.ReadLine(), out int grade) || grade < 1 || grade > 4)
            {
                Console.WriteLine("Некорректный курс! Установлено значение 1.");
                grade = 1;
            }

            Console.Write("Введите имя преподавателя (не обязательно): ");
            string teacherName = Console.ReadLine();

            students.Add(new Student(name, age, grade, teacherName));
            Console.WriteLine("Студент добавлен!");
        }

        static void addTeacher()
        {
            Console.Write("Введите имя преподавателя: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Имя не может быть пустым!");
                return;
            }

            Console.Write("Введите возраст преподавателя: ");
            if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
            {
                Console.WriteLine("Некорректный возраст! Установлено значение 30.");
                age = 30;
            }

            Console.Write("Введите предмет преподавателя: ");
            string subject = Console.ReadLine();
            if (string.IsNullOrEmpty(subject))
            {
                Console.WriteLine("Предмет не может быть пустым! Установлено значение 'Общий'.");
                subject = "Общий";
            }

            teachers.Add(new Teacher(name, age, subject));
            Console.WriteLine("Преподаватель добавлен!");
        }

        static void showAllStudents()
        {
            Console.WriteLine("Список всех студентов:");
            foreach (var student in students)
            {
                Console.WriteLine(student.getInfo());
            }
        }

        static void showAllTeachers()
        {
            Console.WriteLine("Список всех преподавателей:");
            foreach (var teacher in teachers)
            {
                Console.WriteLine(teacher.getInfo());
            }
        }

        static void filterStudentsByAge()
        {
            var adults = students.Where(s => s.Age > 18).ToList();
            Console.WriteLine("Студенты старше 18 лет:");
            foreach (var student in adults)
            {
                Console.WriteLine(student.Name + " (" + student.Age + " лет)");
            }
        }

        static void groupStudentsByGrade()
        {
            var groupedStudents = students.GroupBy(s => s.Grade)
                                         .OrderBy(g => g.Key);
            Console.WriteLine("Группировка студентов по курсу:");
            foreach (var group in groupedStudents)
            {
                Console.WriteLine("Курс " + group.Key + ":");
                foreach (var student in group)
                {
                    Console.WriteLine("  " + student.Name + " (" + student.Age + " лет)");
                }
            }
        }

        static void findTeachersBySubject()
        {
            Console.Write("Введите предмет для поиска: ");
            string subject = Console.ReadLine();

            var subjectTeachers = teachers.Where(t => t.Subject.Equals(subject, StringComparison.OrdinalIgnoreCase)).ToList();

            if (subjectTeachers.Any())
            {
                Console.WriteLine("Преподаватели по предмету '" + subject + "':");
                foreach (var teacher in subjectTeachers)
                {
                    Console.WriteLine(teacher.getInfo());
                }
            }
            else
            {
                Console.WriteLine("Преподаватели по предмету '" + subject + "' не найдены.");
            }
        }

        static void showSubjectStatistics()
        {
            var subjectStats = teachers
                .GroupBy(t => t.Subject)
                .Select(g => new { Subject = g.Key, Count = g.Count() })
                .OrderBy(s => s.Subject);

            Console.WriteLine("Статистика по предметам:");
            foreach (var stat in subjectStats)
            {
                Console.WriteLine("Предмет: " + stat.Subject + ", Количество преподавателей: " + stat.Count);
            }
        }

        static void showStudentTeacherRelations()
        {
            var relations = from student in students
                            join teacher in teachers on student.TeacherName equals teacher.Name into teacherGroup
                            from t in teacherGroup.DefaultIfEmpty()
                            select new
                            {
                                StudentName = student.Name,
                                TeacherName = t != null ? t.Name : "Не назначен",
                                Subject = t != null ? t.Subject : "Не назначен"
                            };

            Console.WriteLine("Связи студентов и преподавателей:");
            foreach (var relation in relations)
            {
                Console.WriteLine("Студент: " + relation.StudentName +
                                  ", Преподаватель: " + relation.TeacherName +
                                  ", Предмет: " + relation.Subject);
            }
        }
    }
}