namespace DiscountCustom
{
    /// <summary>
    /// Определяет контракт для сущностей, поддерживающих систему скидок.
    /// Интерфейс содержит 4 члена: 2 свойства и 2 метода.
    /// </summary>
    public interface IDiscountable
    {
        /// <summary>
        /// Получает или задает базовую цену товара.
        /// </summary>
        decimal BasePrice { get; set; }

        /// <summary>
        /// Получает или задает наименование товара.
        /// </summary>
        string ProductName { get; set; }

        /// <summary>
        /// Рассчитывает итоговую цену товара с учетом скидки.
        /// </summary>
        /// <returns>Цена после применения скидки.</returns>
        decimal CalculateDiscountedPrice();

        /// <summary>
        /// Возвращает информацию о примененной скидке.
        /// </summary>
        /// <returns>Строка с описанием скидки.</returns>
        string GetDiscountInfo();
    }
}
