using System.Collections.Generic;
using FarmTradeApp.Core.Models.Products;

namespace FarmTradeApp.Core.Repositories
{
    public interface IProductQualityRepository
    {
        IEnumerable<ProductQuality> GetProductQualities();
    }
}