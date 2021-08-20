using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace EX_3
{
  
        class WorkFile
        {
            private static void GenerateData(string fileName, int count)
            {
                string[] manNameBase = { "Пётр", "Иван", "Николай", "Сергей", "Евгений", "Максим",
                            "Александр", "Алексей", "Константин", "Павел", "Андрей", "Юра", "Олег", "Гена",
                            "Аркадий", "Арсентий", "Антон", "Дмитрий", "Владимир"};
                string[] womanNamebase = { "Екатерина", "Людмила", "Надежда", "Карина", "Валентина",
                            "Мария", "Марина", "Александра", "Наталья", "Вера", "Лидия", "Любовь",
                            "Ольга", "Юлия", "Эльвира", "Ева", "Алена", "Алина"};
                string[] surnameBase = { "Глазаболев", "Четаксложнов", "Многоедов", "Ошибатов", "Несидетов",
                            "Многосидев", "Пешодрапов", "Надоедов", "Рукожопов", "Шарпов", "Програмов",
                            "Ноутов", "Консолев", "Клавов", "Мышков", "Криворуков", "Правоглазов",
                            "Нестоятов", "Дисплеев", "Подушков", "Связев" };
                string[] city = { "Чебоксары", "Москва", "Санкт-Петербург", "Казань", "Нижний Новгород", "Самара", "Тамбов",
                            "Иваново", "Мухасранск", "Кодиево", "Кадзимово" };
                string[] university = { "ЧГУ", "МГУ", "СПГУ", "ГГУ", "ЛГУ", "ИГУ", "НАТО", "НГИИ", "МГИМО", "МУХА", "КОД" };
                string[] faculty = { "Исскуств", "Инновационных технологий", "Здравых смыслов", "Многоликих", "Умных людей",
                            "Не оцень умных людей", "Просто по фану", "Каток в кс", "Геймеров", "Программеров", "Кодеров" };
                string[] department = { "Качества", "Проверки", "Инспекции", "Закупки", "Аналитики", "Бухгалтерии", "Самореализации",
                            "Деградирования", "WASD", "Пальценажимания", "Клонирования", "Домосидения" };

                StreamWriter sr = new StreamWriter(fileName, false);
                Random rnd = new Random();

                for (int i = 0; i < count; i++)
                {
                    int option = rnd.Next(0, 2);
                    string firstName = option == 0
                        ? manNameBase[rnd.Next(0, manNameBase.Length)]
                        : womanNamebase[rnd.Next(0, womanNamebase.Length)];

                    string lastName = option == 0
                        ? surnameBase[rnd.Next(0, surnameBase.Length)]
                        : surnameBase[rnd.Next(0, surnameBase.Length)] + "а";

                    string line = $"{firstName};" +
                                    $"{lastName};" +
                                    $"{university[rnd.Next(university.Length)]};" +
                                    $"{faculty[rnd.Next(faculty.Length)]};" +
                                    $"{department[rnd.Next(department.Length)]};" +
                                    $"{rnd.Next(17, 27)};" +
                                    $"{rnd.Next(1, 7)};" +
                                    $"{rnd.Next(1111, 9999)};" +
                                    $"{city[rnd.Next(city.Length)]};";

                    sr.WriteLine(line);
                }
                sr.Close();
            }
            public static List<Student> Data(string fileName)
            {
                GenerateData(fileName, 10);

                List<Student> list = new List<Student>();
                StreamReader sr = new StreamReader(fileName);

                while (!sr.EndOfStream)
                {
                    try
                    {
                        string[] s = sr.ReadLine().Split(';');
                        list.Add(new Student(s[0], s[1], s[2], s[3], s[4],
                                int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Ошибка! ESC - для выхода");

                        if (Console.ReadKey().Key == ConsoleKey.Escape) break;
                    }
                }
                sr.Close();

                return list;
            }
            public static void ShowStudents(List<Student> list)
            {
                foreach (var item in list)
                {
                    Console.WriteLine($"студент: {item.firstName} {item.lastName}\n" +
                                    $"Университет: {item.university}\n" +
                                    $"Факультет: {item.faculty}\n" +
                                    $"Отдел: {item.department}\n" +
                                    $"Город: {item.city}\n" +
                                    $"Курс: {item.course}\n" +
                                    $"Возраст: {item.age}\n");
                }
            }
            public static void StartDemo(List<Student> list)
            {
                ShowStudents(list);
                int studentInCourse = 0;

                
                foreach (var item in list)
                    if (item.course >= 5) studentInCourse++;

                Console.WriteLine($"Количество студентов 5 и 6 курсов: {studentInCourse}");

            
                var dictionary = new Dictionary<int, int>();

                for (int i = 1; i <= 6; i++)
                    dictionary.Add(i, 0);

                foreach (var item in list)
                    if (item.age >= 18 && item.age <= 20) dictionary[item.course]++;

                Console.WriteLine($"Количество стдуентов на курсах от 18 до 20 лет:\n" +
                                $"| Курс | Кол-во |");
                foreach (var item in dictionary)
                    Console.WriteLine($"|{item.Key,6}|{item.Value,8}|");

               
                Console.WriteLine("\nОтсортированный список по возрасту:");
                var newlist = list.OrderBy(st => st.age).ToList();
                ShowStudents(newlist);

                Console.WriteLine("\nОтсортированный список по курсу и возрасту:");
                ShowStudents(list.OrderBy(st => st.course).ThenBy(st => st.age).ToList());
            }
        }
    }
