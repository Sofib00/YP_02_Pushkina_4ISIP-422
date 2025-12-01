using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad5
{
    internal class Program
    {
        public class ShelterAnimal
        {
            public string Name;
            public string Type;
            public int Age;
            public bool Vaccinated;
            public DateTime ArrivalDate;
            public string Status;

            public ShelterAnimal(string name, string type, int age, bool vaccinated, DateTime arrivalDate)
            {
                Name = name;
                Type = type;
                Age = age;
                Vaccinated = vaccinated;
                ArrivalDate = arrivalDate;
                Status = "в приюте";
            }

            public void PrintInfo()
            {
                Console.WriteLine($"Кличка: {Name}");
                Console.WriteLine($"Вид: {Type}, Возраст: {Age} лет");
                Console.WriteLine($"Прививки: {(Vaccinated ? "Да" : "Нет")}");
                Console.WriteLine($"Дата поступления: {ArrivalDate.ToShortDateString()}");
                Console.WriteLine($"Статус: {Status}\n");
            }

            public void Adopt()
            {
                Status = "забрали домой";
                Console.WriteLine($"{Name} был(а) забран(а) домой.\n");
            }
        }
        static void Main(string[] args)
        {
            List<ShelterAnimal> shelter = new List<ShelterAnimal>();

            shelter.Add(new ShelterAnimal("Барсик", "Кот", 2, true, DateTime.Now.AddDays(-10)));
            shelter.Add(new ShelterAnimal("Рекс", "Собака", 4, false, DateTime.Now.AddDays(-5)));

            string choice = "";
            while (choice != "0")
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Добавить новое животное");
                Console.WriteLine("2 - Фильтрация животных без прививок");
                Console.WriteLine("3 - Поиск по кличке");
                Console.WriteLine("4 - Изменить статус на 'забрали домой'");
                Console.WriteLine("5 - Просмотр всех животных");
                Console.WriteLine("0 - Выход");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Кличка: ");
                        string name = Console.ReadLine();
                        Console.Write("Вид: ");
                        string type = Console.ReadLine();
                        Console.Write("Возраст: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("Прививки (да/нет): ");
                        bool vaccinated = Console.ReadLine().ToLower() == "да";
                        shelter.Add(new ShelterAnimal(name, type, age, vaccinated, DateTime.Now));
                        Console.WriteLine("Животное добавлено!\n");
                        break;

                    case "2":
                        var noVacc = shelter.Where(a => !a.Vaccinated).ToList();
                        Console.WriteLine($"\nЖивотные без прививок ({noVacc.Count}):\n");
                        foreach (var a in noVacc) a.PrintInfo();
                        break;

                    case "3":
                        Console.Write("Введите кличку для поиска: ");
                        string searchName = Console.ReadLine();
                        var found = shelter.FirstOrDefault(a => a.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
                        if (found != null)
                            found.PrintInfo();
                        else
                            Console.WriteLine("Животное не найдено.\n");
                        break;

                    case "4":
                        Console.Write("Введите кличку животного для усыновления: ");
                        string adoptName = Console.ReadLine();
                        var animal = shelter.FirstOrDefault(a => a.Name.Equals(adoptName, StringComparison.OrdinalIgnoreCase));
                        if (animal != null)
                            animal.Adopt();
                        else
                            Console.WriteLine("Животное не найдено.\n");
                        break;

                    case "5":
                        Console.WriteLine("\nВсе животные:\n");
                        foreach (var a in shelter) a.PrintInfo();
                        break;

                    case "0":
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
