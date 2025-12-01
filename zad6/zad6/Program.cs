using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad6
{
    internal class Program
    {
        public class TaxiCar
        {
            public string Brand;
            public string Model;
            public int Year;
            public int Mileage;
            public string Status;
            public string Driver;

            public TaxiCar(string brand, string model, int year, int mileage, string driver)
            {
                Brand = brand;
                Model = model;
                Year = year;
                Mileage = mileage;
                Driver = driver;
                Status = "В работе";
            }

            public void PrintInfo()
            {
                Console.WriteLine($"Марка: {Brand}, Модель: {Model}, Год: {Year}");
                Console.WriteLine($"Пробег: {Mileage} км, Состояние: {Status}");
                Console.WriteLine($"Водитель: {Driver}\n");
            }

            public void SetStatus(string status)
            {
                Status = status;
                Console.WriteLine($"Состояние машины обновлено на: {Status}\n");
            }

            public void UpdateMileage(int km)
            {
                Mileage += km;
                Console.WriteLine($"Пробег обновлен. Текущий пробег: {Mileage} км\n");
            }
        }
        static void Main(string[] args)
        {
            List<TaxiCar> fleet = new List<TaxiCar>();

            fleet.Add(new TaxiCar("Toyota", "Camry", 2018, 50000, "Иванов И.И."));
            fleet.Add(new TaxiCar("Lada", "Granta", 2020, 30000, "Петров П.П."));

            string a = "";
            while (a != "0")
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Добавить автомобиль");
                Console.WriteLine("2 - Обновить состояние автомобиля");
                Console.WriteLine("3 - Обновить пробег");
                Console.WriteLine("4 - Поиск по водителю");
                Console.WriteLine("5 - Просмотр всех автомобилей");
                Console.WriteLine("0 - Выход");
                a = Console.ReadLine();

                switch (a)
                {
                    case "1":
                        Console.Write("Марка: ");
                        string brand = Console.ReadLine();
                        Console.Write("Модель: ");
                        string model = Console.ReadLine();
                        Console.Write("Год выпуска: ");
                        int year = int.Parse(Console.ReadLine());
                        Console.Write("Пробег: ");
                        int mileage = int.Parse(Console.ReadLine());
                        Console.Write("Водитель: ");
                        string driver = Console.ReadLine();
                        fleet.Add(new TaxiCar(brand, model, year, mileage, driver));
                        break;

                    case "2":
                        Console.Write("Введите имя водителя машины: ");
                        string driverName = Console.ReadLine();
                        var carStatus = fleet.FirstOrDefault(c => c.Driver.Equals(driverName, StringComparison.OrdinalIgnoreCase));
                        if (carStatus != null)
                        {
                            Console.Write("Введите новое состояние (В работе/На ремонте): ");
                            string status = Console.ReadLine();
                            carStatus.SetStatus(status);
                        }
                        else
                            Console.WriteLine("Автомобиль с таким водителем не найден.\n");
                        break;

                    case "3":
                        Console.Write("Введите имя водителя машины: ");
                        string drv = Console.ReadLine();
                        var carMileage = fleet.FirstOrDefault(c => c.Driver.Equals(drv, StringComparison.OrdinalIgnoreCase));
                        if (carMileage != null)
                        {
                            Console.Write("Введите километраж для добавления: ");
                            int km = int.Parse(Console.ReadLine());
                            carMileage.UpdateMileage(km);
                        }
                        else
                            Console.WriteLine("Автомобиль с таким водителем не найден.\n");
                        break;

                    case "4":
                        Console.Write("Введите имя водителя для поиска: ");
                        string searchDriver = Console.ReadLine();
                        var found = fleet.FirstOrDefault(c => c.Driver.Equals(searchDriver, StringComparison.OrdinalIgnoreCase));
                        if (found != null)
                            found.PrintInfo();
                        else
                            Console.WriteLine("Автомобиль с таким водителем не найден.\n");
                        break;

                    case "5":
                        Console.WriteLine("\nВсе автомобили:\n");
                        foreach (var c in fleet) c.PrintInfo();
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
