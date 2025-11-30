using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YP_Zadacha1
{
    internal class Program
    {
        public class TouristCustomer
        {
            public string FIO;
            public string Phone;
            public string Destination;
            public int Days;
            public float Price;
            public float Discount;

            public TouristCustomer(string fio, string phone, string destination, int days, float price, float discount)
            {
                FIO = fio;
                Phone = phone;
                Destination = destination;
                Days = days;
                Price = price;
                Discount = discount;
            }

            public float GetPrice()
            {
                float total = Days * Price;
                return total * (1 - Discount / 100);
            }
            public void Vivod()
            {
                Console.WriteLine($"ФИО: {FIO}");
                Console.WriteLine($"Телефон: {Phone}");
                Console.WriteLine($"Пункт назначения: {Destination}");
                Console.WriteLine($"Длительность поездки: {Days} дней");
                Console.WriteLine($"Цена за день: {Price}");
                Console.WriteLine($"Скидка: {Discount}%");
                Console.WriteLine($"Итоговая стоимость тура: {GetPrice()}\n");
            }
        }
        static void Main(string[] args)
        {
            List<TouristCustomer> customers = new List<TouristCustomer>();

            customers.Add(new TouristCustomer("Иванов Иван", "+79891234567", "Париж", 5, 1000, 10));
            customers.Add(new TouristCustomer("Семенова Мария", "+79897654321", "Токио", 7, 1200, 5));
            string choice = "";
            while (choice != "0")
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Добавить нового клиента");
                Console.WriteLine("2 - Вывести информацию о клиентах");
                Console.WriteLine("3 - Найти клиента по телефону");
                Console.WriteLine("4 - Вычислить стоимость всех туров");
                Console.WriteLine("0 - Выход");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("ФИО: ");
                        string fio = Console.ReadLine();
                        Console.Write("Телефон: ");
                        string phone = Console.ReadLine();
                        Console.Write("Пункт назначения: ");
                        string dest = Console.ReadLine();
                        Console.Write("Количество дней: ");
                        int days = int.Parse(Console.ReadLine());
                        Console.Write("Цена за день: ");
                        float price = float.Parse(Console.ReadLine());
                        Console.Write("Скидка (%): ");
                        float discount = float.Parse(Console.ReadLine());
                        customers.Add(new TouristCustomer(fio, phone, dest, days, price, discount));
                        break;

                    case "2":
                        foreach (var c in customers)
                            c.Vivod();
                        break;

                    case "3":
                        Console.Write("Введите телефон для поиска: ");
                        string searchPhone = Console.ReadLine();
                        var customer = customers.FirstOrDefault(c => c.Phone == searchPhone);
                        if (customer != null)
                            customer.Vivod();
                        else
                            Console.WriteLine("Клиент не найден!\n");
                        break;

                    case "4":
                        float total = customers.Sum(c => c.GetPrice());
                        Console.WriteLine($"Общая стоимость всех туров: {total}\n");
                        break;

                    case "0":
                        Console.WriteLine("Выход");
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
