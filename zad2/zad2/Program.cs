using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static YP_Zadacha2.Program;

namespace YP_Zadacha2
{

    internal class Program
    {
        public class JewelryCustomer
        {
            public string FIO;
            public string Phone;
            public string Type_Jewelry;
            public string Material;
            public float Price;
            public float Sale;
            public JewelryCustomer(string fio, string phone, string type_jewelry, string material, float price, float sale)
            {
                FIO = fio;
                Phone = phone;
                Type_Jewelry = type_jewelry;
                Material = material;
                Price = price;
                Sale = sale;

            }
            public float GetPrice()
            {
                return Price * (1 - Sale / 100);
            }
            public void Vivod()
            {
                Console.WriteLine($"ФИО: {FIO}, Телефон: {Phone}\nТип украшения: {Type_Jewelry}, Материал: {Material}, Цена: {Price}, Скидка: {Sale}%\nИтоговая стоимость: {GetPrice()}\n");
            }
            public static JewelryCustomer Poisk(string Phone, List<JewelryCustomer> jewelry)
            {
                return jewelry.FirstOrDefault(c => c.Phone == Phone);

            }
            public static float Stoimost(List<JewelryCustomer> jewelry)
            {
                return jewelry.Sum(c => c.GetPrice());
            }

        }
        public static void Disp()
        {
            Console.WriteLine("Выберете номер действия:\n" +
                "a - добавление нового покупателя\n" +
                "b - вывод информации о покупателях\n" +
                "c - поиск по номеру телефона\n" +
                "d - вычисление общей прибыли магазина\n" +
                "0 - выход");

        }

        static void Main(string[] args)
        {
            string a = "   ";
            List<JewelryCustomer> jewelry = new List<JewelryCustomer>();

            jewelry.Add(new JewelryCustomer("Семенов Семен Семёнович", "+79895839494", "цепь", "золото", 5000, 0));
            jewelry.Add(new JewelryCustomer("Иванов Иван Иванович", "+79458773494", "кольцо", "серебро", 4000, 0));

            while (a != "0")
            {
                Disp();
                a = Console.ReadLine();
                switch (a)
                {
                    case "a": //добавление нового покупателя
                        Console.Write("Введите ФИО:");
                        string f = Console.ReadLine();
                        Console.Write("Введите номер:");
                        string n = Console.ReadLine();
                        Console.Write("Введите тип изделия:");
                        string t = Console.ReadLine();
                        Console.Write("Введите материал:");
                        string m = Console.ReadLine();
                        Console.Write("Введите цену:");
                        float cena = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите скидку:");
                        float s = Convert.ToInt32(Console.ReadLine());
                        jewelry.Add(new JewelryCustomer(f, n, t, m, cena, s));
                        break;
                    case "b": //вывод информации о покупателях
                        foreach (JewelryCustomer j in jewelry) j.Vivod();
                        break;
                    case "c"://поиск по номеру телефона
                        Console.Write("Введите номер телефона: ");
                        string phone = Console.ReadLine();
                        var customer = JewelryCustomer.Poisk(phone, jewelry);
                        if (customer != null)
                            customer.Vivod();
                        else
                            Console.WriteLine("Покупатель не найден");
                        break;
                    case "d"://вычисление общей прибыли магазина
                        Console.WriteLine("Общая прибыль: " + JewelryCustomer.Stoimost(jewelry));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}