using System.Collections.Generic;
using FarmTradeApp.Core.Models.Products;

namespace FarmTradeApp.Core.Repositories
{
    public interface IProductCategoryRepository
    {
        IEnumerable<ProductCategory> GetProductCategories();
    }
}