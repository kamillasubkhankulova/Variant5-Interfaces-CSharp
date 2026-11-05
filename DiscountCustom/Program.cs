using System;
using System.Collections.Generic;

namespace DiscountCustom
{
    /// <summary>
    /// Точка входа в приложение. Демонстрирует работу пользовательского интерфейса IDiscountable.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Демонстрация пользовательского интерфейса: IDiscountable ===\n");

            // Создание полиморфной коллекции товаров
            List<IDiscountable> products = new List<IDiscountable>
            {
                new FoodProduct("Молоко", 120m, new DateTime(2025, 12, 15)),
                new FoodProduct("Хлеб", 45m, new DateTime(2025, 11, 10)),
                new FoodProduct("Сыр", 350m, new DateTime(2025, 12, 01)),
                new ElectronicsProduct("Наушники", 8000m, "Sony"),
                new ElectronicsProduct("Смартфон", 55000m, "Samsung"),
                new ElectronicsProduct("Флешка", 900m, "Kingston")
            };

            // === Полиморфная обработка коллекции ===
            Console.WriteLine("--- Демонстрация полиморфной обработки коллекции List<IDiscountable> ---");
            Console.WriteLine("Единообразный вывод информации и расчет цен для всех товаров:\n");

            decimal totalBase = 0m;
            decimal totalDiscounted = 0m;

            foreach (IDiscountable product in products)
            {
                Console.WriteLine(product.GetDiscountInfo());
                Console.WriteLine($"  Итоговая цена: {product.CalculateDiscountedPrice():C}");
                Console.WriteLine();

                totalBase += product.BasePrice;
                totalDiscounted += product.CalculateDiscountedPrice();
            }

            Console.WriteLine("--- Сводный отчет по коллекции ---");
            Console.WriteLine($"Общая базовая стоимость:    {totalBase:C}");
            Console.WriteLine($"Общая стоимость со скидкой: {totalDiscounted:C}");
            Console.WriteLine($"Экономия:                   {totalBase - totalDiscounted:C}");
            Console.WriteLine();

            // === Демонстрация различий в реализации ===
            Console.WriteLine("--- Демонстрация различий в реализации скидок ---");
            FoodProduct food = new FoodProduct("Йогурт", 80m, DateTime.Now.AddDays(7));
            ElectronicsProduct cheapGadget = new ElectronicsProduct("Кабель USB", 500m, "Baseus");
            ElectronicsProduct expensiveGadget = new ElectronicsProduct("Ноутбук", 75000m, "Apple");

            Console.WriteLine($"Продукт питания (фиксированная скидка 10%):");
            Console.WriteLine($"  {food.GetDiscountInfo()} → {food.CalculateDiscountedPrice():C}");

            Console.WriteLine($"\nДешевый гаджет (скидка 5%, цена до 20 000):");
            Console.WriteLine($"  {cheapGadget.GetDiscountInfo()} → {cheapGadget.CalculateDiscountedPrice():C}");

            Console.WriteLine($"\nДорогой гаджет (скидка 15%, цена свыше 50 000):");
            Console.WriteLine($"  {expensiveGadget.GetDiscountInfo()} → {expensiveGadget.CalculateDiscountedPrice():C}");
            Console.WriteLine();

            // === Проверка входных данных ===
            Console.WriteLine("--- Проверка входных данных ---");
            try
            {
                FoodProduct invalidFood = new FoodProduct("", -50m, DateTime.Now);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ожидаемое исключение при некорректных данных FoodProduct: {ex.Message}");
            }

            try
            {
                ElectronicsProduct invalidElectronics = new ElectronicsProduct("", -1000m, "");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ожидаемое исключение при некорректных данных ElectronicsProduct: {ex.Message}");
            }

            Console.WriteLine("\n=== Демонстрация завершена ===");
        }
    }
}
