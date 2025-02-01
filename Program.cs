using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберите задачу (1, 2, 3) или введите 'exit' для выхода:");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }

            if (int.TryParse(input, out int taskNumber))
            {
                switch (taskNumber)
                {
                    case 1:
                        new Task1().TaskLoop();
                        break;
                    case 2:
                        new Task2().TaskLoop();
                        break;
                    case 3:
                        new Task3().TaskLoop();
                        break;
                    default:
                        Console.WriteLine("Некорректный номер задачи.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }
        }
    }

    // Задание 1: Работа со списком строк
    private class Task1
    {
        public void TaskLoop()
        {
            List<string> stringList = new List<string> { "Apple", "Banana", "Cherry" };

            while (true)
            {
                Console.WriteLine("Текущий список:");
                foreach (var item in stringList)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Введите новую строку (или '--exit' для выхода):");
                string input = Console.ReadLine();

                if (input.ToLower() == "--exit")
                {
                    break;
                }

                stringList.Add(input);

                Console.WriteLine("Введите ещё одну строку для добавления в середину списка:");
                input = Console.ReadLine();
                stringList.Insert(stringList.Count / 2, input);
            }
        }
    }

    // Задание 2: Словарь студентов и их оценок
    private class Task2
    {
        public void TaskLoop()
        {
            Dictionary<string, int> studentGrades = new Dictionary<string, int>();

            while (true)
            {
                Console.WriteLine("Введите имя студента (или '--exit' для выхода):");
                string name = Console.ReadLine();

                if (name.ToLower() == "--exit")
                {
                    break;
                }

                Console.WriteLine("Введите оценку студента (от 2 до 5):");
                if (int.TryParse(Console.ReadLine(), out int grade) && grade >= 2 && grade <= 5)
                {
                    studentGrades[name] = grade;
                }
                else
                {
                    Console.WriteLine("Некорректная оценка. Оценка должна быть от 2 до 5.");
                }

                Console.WriteLine("Введите имя студента для поиска его оценки:");
                name = Console.ReadLine();
                if (studentGrades.ContainsKey(name))
                {
                    Console.WriteLine($"Оценка студента {name}: {studentGrades[name]}");
                }
                else
                {
                    Console.WriteLine($"Студент с именем {name} не найден.");
                }
            }
        }
    }

    // Задание 3: Двусвязный список
    private class Task3
    {
        private class Node
        {
            public string Data { get; set; }
            public Node Previous { get; set; }
            public Node Next { get; set; }

            public Node(string data)
            {
                Data = data;
                Previous = null;
                Next = null;
            }
        }

        private Node head;
        private Node tail;

        public void TaskLoop()
        {
            Console.WriteLine("Введите от 3 до 6 элементов для двусвязного списка:");
            for (int i = 0; i < 6; i++)
            {
                Console.Write($"Элемент {i + 1}: ");
                string input = Console.ReadLine();
                AddNode(input);

                if (i >= 2 && i < 5)
                {
                    Console.WriteLine("Продолжить ввод? (y/n)");
                    if (Console.ReadLine().ToLower() != "y")
                    {
                        break;
                    }
                }
            }

            Console.WriteLine("Список в прямом порядке:");
            PrintListForward();

            Console.WriteLine("Список в обратном порядке:");
            PrintListBackward();
        }

        private void AddNode(string data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
        }

        private void PrintListForward()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        private void PrintListBackward()
        {
            Node current = tail;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Previous;
            }
        }
    }
}