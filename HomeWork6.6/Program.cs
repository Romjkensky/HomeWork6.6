using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Путь к файлу
            string path = "HomeWork.txt";

            // Создание файла, если он не существует
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            // Вывод меню пользователю
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Вывести данные на экран");
            Console.WriteLine("2 - Добавить новую запись в конец файла");

            // Чтение выбора пользователя
            string choice = Console.ReadLine();

            switch (choice)
            {
                // Вывод данных на экран
                case "1":
                    List<string> employeeData = ReadToFile(path);
                    PrintDataToScreen(employeeData);
                    break;

                // Добавление новой записи в конец файла
                case "2":
                    Console.Write("Введите ID: ");
                    string id = Console.ReadLine();

                    Console.Write("Введите Ф. И. О.: ");
                    string name = Console.ReadLine();

                    Console.Write("Введите возраст: ");
                    string age = Console.ReadLine();

                    Console.Write("Введите рост: ");
                    string height = Console.ReadLine();

                    Console.Write("Введите дату рождения: ");
                    string birthDate = Console.ReadLine();

                    Console.Write("Введите место рождения: ");
                    string birthPlace = Console.ReadLine();

                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    string employeeDataString = $"{id}, {timestamp}, {name}, {age}, {height}, {birthDate}, {birthPlace}";

                    WriteToFile(path, employeeDataString);

                    Console.WriteLine("Запись успешно добавлена в файл.");

                    break;

                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }

            Console.ReadLine();
        }

        static List<string> ReadToFile(string path)
        {
            List<string> lines = new List<string>();

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    lines.Add(line);
                }
            }

            return lines;
        }

        static void WriteToFile(string path, string data)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(data);
            }
        }

        static void PrintDataToScreen(List<string> employeeData)
        {
            foreach (string line in employeeData)
            {
                Console.WriteLine(line);
            }
        }
    }
}
