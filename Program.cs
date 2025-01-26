using System;
using System.Collections.Generic;

namespace HomeWork
{
    internal class Program
    {
        private class ListTask
        {
            private readonly List<string> _listOfStrings;

            public ListTask()
            {
                _listOfStrings = new List<string> { "Первый элемент", "Второй элемент", "Третий элемент" };
            }

            public void TaskLoop()
            {
                Console.WriteLine("Содержимое списка:");
                DisplayList();

                Console.WriteLine("Введите новую строку для добавления в список (введите '–exit' для выхода):");
                while (true)
                {
                    string newItem = Console.ReadLine();
                    if (newItem.Equals("–exit", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    _listOfStrings.Add(newItem);
                    DisplayList();

                    Console.WriteLine("Введите строку для добавления в середину списка:");
                    string middleItem = Console.ReadLine();
                    if (middleItem.Equals("–exit", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    int middleIndex = _listOfStrings.Count / 2;
                    _listOfStrings.Insert(middleIndex, middleItem);
                    DisplayList();
                }
            }

            private void DisplayList()
            {
                Console.WriteLine("Текущий список:");
                foreach (var item in _listOfStrings)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private class DictionaryTask
        {
            private readonly Dictionary<string, float> _students;

            public DictionaryTask()
            {
                _students = new Dictionary<string, float>();
            }

            public void TaskLoop()
            {
                while (true)
                {
                    Console.WriteLine("Введите имя студента и его оценку (например, Иван 4). Для выхода введите '–exit'.");
                    string input = Console.ReadLine();
                    if (input.Equals("–exit", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }

                    var parts = input.Split(' ');
                    if (parts.Length != 2 || !float.TryParse(parts[1], out float grade) || grade < 2 || grade > 5)
                    {
                        Console.WriteLine("Некорректный ввод. Убедитесь, что вы ввели имя и оценку от 2 до 5.");
                        continue;
                    }

                    _students[parts[0]] = grade; // Добавляем или обновляем оценку студента

                    Console.WriteLine("Введите имя студента для получения его оценки:");
                    string studentName = Console.ReadLine();
                    if (_students.TryGetValue(studentName, out float studentGrade))
                    {
                        Console.WriteLine($"Оценка студента {studentName}: {studentGrade}");
                    }
                    else
                    {
                        Console.WriteLine($"Студента с именем {studentName} не существует.");
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Выберите задание (1 - Список, 2 - Словарь):");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListTask listTask = new ListTask();
                    listTask.TaskLoop();
                    break;

                case "2":
                    DictionaryTask dictionaryTask = new DictionaryTask();
                    dictionaryTask.TaskLoop();
                    break;

                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите 1 или 2.");
                    break;
            }
        }
    }
}
