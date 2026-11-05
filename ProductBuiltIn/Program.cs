using System;
using System.Collections.Generic;

namespace ProductBuiltIn
{
    /// <summary>
    /// Точка входа в приложение. Демонстрирует работу встроенных интерфейсов класса Product.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Демонстрация встроенных интерфейсов: Product ===\n");

            // Создание списка товаров
            List<Product> products = new List<Product>
            {
                new Product("Монитор", 15000m, "27 дюймов, IPS"),
                new Product("Клавиатура", 3000m, "Механическая, RGB"),
                new Product("Мышь", 2500m, "Беспроводная, 16000 DPI"),
                new Product("Наушники", 8000m, "Беспроводные, с шумоподавлением"),
                new Product("Веб-камера", 4500m, "Full HD, 60 FPS")
            };

            // === IComparable<Product>: сортировка по цене ===
            Console.WriteLine("--- Демонстрация IComparable<Product> (сортировка по цене) ---");
            products.Sort();
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            // === IComparer<Product>: сортировка по имени ===
            Console.WriteLine("--- Демонстрация IComparer<Product> (сортировка по наименованию) ---");
            products.Sort(new ProductNameComparer());
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            // === ICloneable: глубокое клонирование ===
            Console.WriteLine("--- Демонстрация ICloneable (глубокое клонирование) ---");
            Product original = new Product("Смартфон", 50000m, "Флагман, 256 ГБ");
            Product clone = (Product)original.Clone();
            Console.WriteLine($"Оригинал: {original}");
            Console.WriteLine($"Клон:     {clone}");
            Console.WriteLine($"Ссылки равны: {ReferenceEquals(original, clone)} (должно быть False)");
            Console.WriteLine();

            // === IEquatable<Product>: сравнение на равенство ===
            Console.WriteLine("--- Демонстрация IEquatable<Product> (сравнение на равенство) ---");
            Product productA = new Product("Ноутбук", 70000m, "16 ГБ ОЗУ");
            Product productB = new Product("Ноутбук", 70000m, "Другое описание");
            Product productC = new Product("Планшет", 40000m, "10 дюймов");
            Console.WriteLine($"productA.Equals(productB) (имя и цена совпадают): {productA.Equals(productB)} (должно быть True)");
            Console.WriteLine($"productA.Equals(productC): {productA.Equals(productC)} (должно быть False)");
            Console.WriteLine();

            // === IDisposable: освобождение ресурсов ===
            Console.WriteLine("--- Демонстрация IDisposable (освобождение сканера) ---");
            using (Product disposableProduct = new Product("Тестовый товар", 1000m, "Для проверки Dispose"))
            {
                Console.WriteLine($"Создан товар: {disposableProduct.Name}");
                Console.WriteLine($"IsDisposed перед выходом из using: {disposableProduct.IsDisposed}");
            }
            Console.WriteLine("После блока using ресурсы освобождены.");
            Console.WriteLine();

            // === Проверка входных данных ===
            Console.WriteLine("--- Проверка входных данных ---");
            try
            {
                Product invalid = new Product("", -100m, "test");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ожидаемое исключение при некорректных данных: {ex.Message}");
            }

            Console.WriteLine("\n=== Демонстрация завершена ===");
        }
    }
}
