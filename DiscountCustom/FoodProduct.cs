using System;

namespace DiscountCustom
{
    /// <summary>
    /// Представляет продукт питания с правилами скидки 10%.
    /// </summary>
    public class FoodProduct : IDiscountable
    {
        private decimal _basePrice;
        private string _productName;
        private DateTime _expirationDate;

        /// <summary>
        /// Получает или задает базовую цену продукта питания.
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
        /// Получает или задает наименование продукта питания.
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
        /// Получает или задает срок годности продукта.
        /// </summary>
        public DateTime ExpirationDate
        {
            get => _expirationDate;
            set => _expirationDate = value;
        }

        /// <summary>
        /// Получает размер скидки для продуктов питания (10%).
        /// </summary>
        public decimal DiscountRate => 0.10m;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="FoodProduct"/>.
        /// </summary>
        /// <param name="productName">Наименование продукта.</param>
        /// <param name="basePrice">Базовая цена.</param>
        /// <param name="expirationDate">Срок годности.</param>
        public FoodProduct(string productName, decimal basePrice, DateTime expirationDate)
        {
            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException("Наименование не может быть пустым.", nameof(productName));
            if (basePrice < 0)
                throw new ArgumentOutOfRangeException(nameof(basePrice), "Базовая цена не может быть отрицательной.");

            _productName = productName;
            _basePrice = basePrice;
            _expirationDate = expirationDate;
        }

        /// <summary>
        /// Рассчитывает итоговую цену продукта питания с учетом скидки 10%.
        /// </summary>
        /// <returns>Цена после применения скидки.</returns>
        public decimal CalculateDiscountedPrice()
        {
            return _basePrice * (1 - DiscountRate);
        }

        /// <summary>
        /// Возвращает информацию о примененной скидке.
        /// </summary>
        /// <returns>Строка с описанием скидки.</returns>
        public string GetDiscountInfo()
        {
            return $"Продукт питания \"{_productName}\": скидка {DiscountRate:P0} (до {_expirationDate:dd.MM.yyyy})";
        }

        /// <summary>
        /// Возвращает строковое представление продукта питания.
        /// </summary>
        /// <returns>Строка с информацией о продукте.</returns>
        public override string ToString()
        {
            return $"{nameof(FoodProduct)}: {_productName}, Базовая цена: {_basePrice:C}, Со скидкой: {CalculateDiscountedPrice():C}";
        }
    }
}
