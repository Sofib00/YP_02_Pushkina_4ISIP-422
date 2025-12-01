using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    internal class Program
    {
        public class SportCustomer
        {
            public string FIO;
            public int Age;
            public string Product;
            public string Size;
            public float Price;
            public string PaymentMethod;

            public SportCustomer(string fio, int age, string product, string size, float price, string paymentMethod)
            {
                FIO = fio;
                Age = age;
                Product = product;
                Size = size;
                Price = price;
                PaymentMethod = paymentMethod;
            }

            public void PrintInfo()
            {
                Console.WriteLine($"ФИО: {FIO}");
                Console.WriteLine($"Возраст: {Age}");
                Console.WriteLine($"Товар: {Product}, Размер: {Size}");
                Console.WriteLine($"Цена: {Price}, Оплата: {PaymentMethod}\n");
            }
        }

        static void Main(string[] args)
        {
            List<SportCustomer> customers = new List<SportCustomer>();

            customers.Add(new SportCustomer("Иванов Иван", 25, "Кроссовки", "42", 5000, "Карта"));
            customers.Add(new SportCustomer("Петров Петр", 30, "Футболка", "M", 1500, "Наличные"));

            string a = "";
            while (a != "0")
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Добавить покупателя");
                Console.WriteLine("2 - Поиск по возрасту");
                Console.WriteLine("3 - Сортировка по цене покупки");
                Console.WriteLine("4 - Вывод всех покупателей");
                Console.WriteLine("0 - Выход");
                a = Console.ReadLine();

                switch (a)
                {
                    case "1": // Добавление клиента
                        Console.Write("ФИО: ");
                        string fio = Console.ReadLine();
                        Console.Write("Возраст: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("Товар: ");
                        string product = Console.ReadLine();
                        Console.Write("Размер: ");
                        string size = Console.ReadLine();
                        Console.Write("Цена: ");
                        float price = float.Parse(Console.ReadLine());
                        Console.Write("Способ оплаты (Наличные/Карта): ");
                        string payment = Console.ReadLine();

                        customers.Add(new SportCustomer(fio, age, product, size, price, payment));
                        Console.WriteLine("Покупатель добавлен!\n");
                        break;

                    case "2": // Поиск по возрасту
                        Console.Write("Введите возраст: ");
                        int searchAge = int.Parse(Console.ReadLine());
                        var found = customers.Where(c => c.Age == searchAge).ToList();
                        if (found.Count > 0)
                        {
                            Console.WriteLine($"Найдено {found.Count} покупателей:\n");
                            foreach (var c in found)
                                c.PrintInfo();
                        }
                        else
                            Console.WriteLine("Покупатели с таким возрастом не найдены.\n");
                        break;

                    case "3": // Сортировка по цене
                        var sorted = customers.OrderBy(c => c.Price).ToList();
                        Console.WriteLine("Список покупателей, отсортированный по цене:\n");
                        foreach (var c in sorted)
                            c.PrintInfo();
                        break;

                    case "4": // Вывод всех покупателей
                        Console.WriteLine("Все покупатели:\n");
                        foreach (var c in customers)
                            c.PrintInfo();
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