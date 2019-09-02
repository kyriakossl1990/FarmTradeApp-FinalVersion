using System.Collections.Generic;
using FarmTradeApp.Core.Models.Products;

namespace FarmTradeApp.Core.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        Product GetProduct(int productId);
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsWithCategoryAndName();
        void Remove(Product product);
    }
}