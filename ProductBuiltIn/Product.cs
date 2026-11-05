using System;

namespace ProductBuiltIn
{
    /// <summary>
    /// Представляет товар с наименованием, ценой и описанием.
    /// Реализует интерфейсы IComparable&lt;Product&gt;, ICloneable, IDisposable, IEquatable&lt;Product&gt;.
    /// </summary>
    public class Product : IComparable<Product>, ICloneable, IDisposable, IEquatable<Product>
    {
        private string _name;
        private decimal _price;
        private string _description;
        private bool _disposed;

        /// <summary>
        /// Получает или задает наименование товара.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Наименование товара не может быть пустым или содержать только пробелы.", nameof(value));
                _name = value;
            }
        }

        /// <summary>
        /// Получает или задает цену товара.
        /// </summary>
        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Цена товара не может быть отрицательной.");
                _price = value;
            }
        }

        /// <summary>
        /// Получает или задает описание товара.
        /// </summary>
        public string Description
        {
            get => _description;
            set => _description = value ?? string.Empty;
        }

        /// <summary>
        /// Получает значение, указывающее, освобождены ли ресурсы товара.
        /// </summary>
        public bool IsDisposed => _disposed;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Product"/>.
        /// </summary>
        /// <param name="name">Наименование товара.</param>
        /// <param name="price">Цена товара.</param>
        /// <param name="description">Описание товара.</param>
        public Product(string name, decimal price, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Наименование товара не может быть пустым.", nameof(name));
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Цена не может быть отрицательной.");

            _name = name;
            _price = price;
            _description = description ?? string.Empty;
            _disposed = false;
        }

        /// <summary>
        /// Сравнивает текущий товар с другим товаром по цене.
        /// </summary>
        /// <param name="other">Товар для сравнения.</param>
        /// <returns>
        /// Значение меньше нуля, если текущий товар дешевле;
        /// ноль, если цены равны;
        /// значение больше нуля, если текущий товар дороже.
        /// </returns>
        public int CompareTo(Product? other)
        {
            if (other is null) return 1;
            return _price.CompareTo(other._price);
        }

        /// <summary>
        /// Создает глубокую копию текущего товара.
        /// </summary>
        /// <returns>Новый объект <see cref="Product"/>, являющийся копией текущего.</returns>
        public object Clone()
        {
            return new Product(_name, _price, _description);
        }

        /// <summary>
        /// Освобождает ресурсы, связанные с товаром (имитация отключения сканера).
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                // Имитация освобождения ресурса «сканер»
                Console.WriteLine($"[Product] Сканер товара \"{_name}\" отключен.");
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Определяет, равен ли текущий товар указанному объекту.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>true, если объекты равны; в противном случае — false.</returns>
        public override bool Equals(object? obj)
        {
            return Equals(obj as Product);
        }

        /// <summary>
        /// Определяет, равен ли текущий товар указанному товару.
        /// </summary>
        /// <param name="other">Товар для сравнения.</param>
        /// <returns>true, если товары равны; в противном случае — false.</returns>
        public bool Equals(Product? other)
        {
            if (other is null) return false;
            return _name == other._name && _price == other._price;
        }

        /// <summary>
        /// Возвращает хэш-код для текущего товара.
        /// </summary>
        /// <returns>Хэш-код.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(_name, _price);
        }

        /// <summary>
        /// Возвращает строковое представление товара.
        /// </summary>
        /// <returns>Строка с наименованием и ценой товара.</returns>
        public override string ToString()
        {
            return $"{nameof(Product)}: {_name}, Цена: {_price:C}, Описание: {_description}";
        }
    }
}
