using System.Collections.Generic;
using FarmTradeApp.Core.Models.Products;

namespace FarmTradeApp.Core.Repositories
{
    public interface IFinalProductRepository
    {
        void Add(FinalProduct finalProduct);
        FinalProduct GetFinalProduct(int finalProductId);
        IEnumerable<FinalProduct> GetFinalProductsWIthQualityAndProduct();
        IEnumerable<FinalProduct> GetFullFinalProducts(string userId);
        IEnumerable<FinalProduct> GetSellerFullFinalProducts(string roleId);
        IEnumerable<FinalProduct> GetUserFinalProductsWIthQualityAndProduct(string userId);
    }
}