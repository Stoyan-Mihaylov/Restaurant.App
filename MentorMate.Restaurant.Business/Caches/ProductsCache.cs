using MentorMate.Restaurant.Business.Dtos.Import;
using MentorMate.Restaurant.Business.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MentorMate.Restaurant.Business.Caches
{
    public class ProductsCache : BaseCache<List<Product>>
    {
        public override void Init(string jsonData)
        {
            var productsAndOrders = JsonConvert.DeserializeObject<ImportProductsAndOrdersDto>(jsonData);
            SetCache(productsAndOrders.Products);
        }
    }
}
