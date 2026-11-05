using System.Collections.Generic;

namespace ProductBuiltIn
{
    /// <summary>
    /// Реализует интерфейс IComparer&lt;Product&gt; для сортировки товаров по наименованию.
    /// </summary>
    public class ProductNameComparer : IComparer<Product>
    {
        /// <summary>
        /// Сравнивает два товара по наименованию в алфавитном порядке.
        /// </summary>
        /// <param name="x">Первый товар.</param>
        /// <param name="y">Второй товар.</param>
        /// <returns>
        /// Значение меньше нуля, если x меньше y;
        /// ноль, если равны;
        /// значение больше нуля, если x больше y.
        /// </returns>
        public int Compare(Product? x, Product? y)
        {
            if (x is null && y is null) return 0;
            if (x is null) return -1;
            if (y is null) return 1;

            return string.Compare(x.Name, y.Name, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
