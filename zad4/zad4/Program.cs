using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad4
{
    internal class Program
    {
        public class BuildingItem
        {
            public string Name;
            public string Category;
            public float Price;
            public int Quantity;
            public int MinQuantity;

            public BuildingItem(string name, string category, float price, int quantity, int minQuantity)
            {
                Name = name;
                Category = category;
                Price = price;
                Quantity = quantity;
                MinQuantity = minQuantity;
            }

            public void PrintInfo()
            {
                Console.WriteLine($"Название: {Name}");
                Console.WriteLine($"Категория: {Category}");
                Console.WriteLine($"Цена за единицу: {Price}");
                Console.WriteLine($"Количество на складе: {Quantity}");
                Console.WriteLine($"Минимальный остаток: {MinQuantity}\n");
            }

            public void Buy(int amount)
            {
                if (amount > Quantity)
                {
                    Console.WriteLine($"Недостаточно товара на складе. Доступно: {Quantity}\n");
                    return;
                }

                Quantity -= amount;
                Console.WriteLine($"Покупка успешна. Остаток: {Quantity}");

                if (Quantity < MinQuantity)
                {
                    Console.WriteLine("Внимание! Количество товара ниже минимального остатка.\n");
                }
            }
        }

        static void Main(string[] args)
        {
            List<BuildingItem> items = new List<BuildingItem>();

            items.Add(new BuildingItem("Молоток", "Инструмент", 500, 10, 3));
            items.Add(new BuildingItem("Краска", "Отделка", 1200, 5, 2));
            items.Add(new BuildingItem("Смеситель", "Сантехника", 3500, 2, 1));

            string a = "";
            while (a != "0")
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1 - Добавить товар");
                Console.WriteLine("2 - Удалить товар");
                Console.WriteLine("3 - Купить товар");
                Console.WriteLine("4 - Просмотр всех товаров");
                Console.WriteLine("5 - Поиск товара по названию");
                Console.WriteLine("0 - Выход");
                a = Console.ReadLine();

                switch (a)
                {
                    case "1": // Добавление товара
                        Console.Write("Название: ");
                        string name = Console.ReadLine();
                        Console.Write("Категория: ");
                        string category = Console.ReadLine();
                        Console.Write("Цена за единицу: ");
                        float price = float.Parse(Console.ReadLine());
                        Console.Write("Количество на складе: ");
                        int quantity = int.Parse(Console.ReadLine());
                        Console.Write("Минимальный остаток: ");
                        int minQty = int.Parse(Console.ReadLine());

                        items.Add(new BuildingItem(name, category, price, quantity, minQty));
                        Console.WriteLine("Товар добавлен!\n");
                        break;

                    case "2": // Удаление товара
                        Console.Write("Введите название товара для удаления: ");
                        string delName = Console.ReadLine();
                        var itemToDelete = items.FirstOrDefault(i => i.Name.Equals(delName, StringComparison.OrdinalIgnoreCase));
                        if (itemToDelete != null)
                        {
                            items.Remove(itemToDelete);
                            Console.WriteLine("Товар удалён.\n");
                        }
                        else
                            Console.WriteLine("Товар не найден.\n");
                        break;

                    case "3": // Купить товар
                        Console.Write("Название товара: ");
                        string buyName = Console.ReadLine();
                        var itemToBuy = items.FirstOrDefault(i => i.Name.Equals(buyName, StringComparison.OrdinalIgnoreCase));
                        if (itemToBuy != null)
                        {
                            Console.Write("Количество для покупки: ");
                            int buyQty = int.Parse(Console.ReadLine());
                            itemToBuy.Buy(buyQty);
                        }
                        else
                            Console.WriteLine("Товар не найден.\n");
                        break;

                    case "4": // Просмотр всех товаров
                        Console.WriteLine("\nВсе товары:\n");
                        foreach (var i in items)
                            i.PrintInfo();
                        break;

                    case "5": // Поиск по названию
                        Console.Write("Введите название товара для поиска: ");
                        string searchName = Console.ReadLine();
                        var found = items.Where(i => i.Name.IndexOf(searchName, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                        if (found.Count > 0)
                        {
                            Console.WriteLine($"\nНайдено {found.Count} товара(ов):\n");
                            foreach (var i in found)
                                i.PrintInfo();
                        }
                        else
                            Console.WriteLine("Товары не найдены.\n");
                        break;

                    case "0":
                        Console.WriteLine("Выход из программы.");
                        break;

                    default:
                        Console.WriteLine("Некорректный выбор.\n");
                        break;
                }
            }
        }
    }
}
