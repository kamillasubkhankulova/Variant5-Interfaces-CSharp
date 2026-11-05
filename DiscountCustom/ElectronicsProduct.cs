using System;

namespace DiscountCustom
{
    /// <summary>
    /// Представляет электротовар с градуированной системой скидок.
    /// </summary>
    public class ElectronicsProduct : IDiscountable
    {
        private decimal _basePrice;
        private string _productName;
        private string _brand;

        /// <summary>
        /// Получает или задает базовую цену электротовара.
        /// </summary>
        public decimal BasePrice
        {
            get => _basePrice;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Базовая цена не может быть отрицательной.");
                _basePrice = value;
            }
        }

        /// <summary>
        /// Получает или задает наименование электротовара.
        /// </summary>
        public string ProductName
        {
            get => _productName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Наименование не может быть пустым.", nameof(value));
                _productName = value;
            }
        }

        /// <summary>
        /// Получает или задает бренд электротовара.
        /// </summary>
        public string Brand
        {
            get => _brand;
            set => _brand = value ?? string.Empty;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ElectronicsProduct"/>.
        /// </summary>
        /// <param name="productName">Наименование товара.</param>
        /// <param name="basePrice">Базовая цена.</param>
        /// <param name="brand">Бренд производителя.</param>
        public ElectronicsProduct(string productName, decimal basePrice, string brand)
        {
            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException("Наименование не может быть пустым.", nameof(productName));
            if (basePrice < 0)
                throw new ArgumentOutOfRangeException(nameof(basePrice), "Базовая цена не может быть отрицательной.");

            _productName = productName;
            _basePrice = basePrice;
            _brand = brand ?? string.Empty;
        }

        /// <summary>
        /// Определяет размер скидки в зависимости от базовой цены.
        /// До 20 000 — 5%, от 20 000 до 50 000 — 10%, свыше 50 000 — 15%.
        /// </summary>
        /// <returns>Размер скидки в долях от единицы.</returns>
        private decimal GetDiscountRate()
        {
            return _basePrice switch
            {
                > 50000m => 0.15m,
                > 20000m => 0.10m,
                _ => 0.05m
            };
        }

        /// <summary>
        /// Рассчитывает итоговую цену электротовара с учетом градуированной скидки.
        /// </summary>
        /// <returns>Цена после применения скидки.</returns>
        public decimal CalculateDiscountedPrice()
        {
            decimal rate = GetDiscountRate();
            return _basePrice * (1 - rate);
        }

        /// <summary>
        /// Возвращает информацию о примененной скидке.
        /// </summary>
        /// <returns>Строка с описанием скидки.</returns>
        public string GetDiscountInfo()
        {
            decimal rate = GetDiscountRate();
            return $"Электротовар \"{_productName}\" ({_brand}): скидка {rate:P0} (базовая цена {_basePrice:C})";
        }

        /// <summary>
        /// Возвращает строковое представление электротовара.
        /// </summary>
        /// <returns>Строка с информацией о товаре.</returns>
        public override string ToString()
        {
            return $"{nameof(ElectronicsProduct)}: {_productName} [{_brand}], Базовая цена: {_basePrice:C}, Со скидкой: {CalculateDiscountedPrice():C}";
        }
    }
}
