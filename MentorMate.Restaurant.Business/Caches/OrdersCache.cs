using MentorMate.Restaurant.Business.Dtos.Import;
using MentorMate.Restaurant.Business.Models;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace MentorMate.Restaurant.Business.Caches
{
    public class OrdersCache : BaseCache<List<Order>>
    {
        public override void Init(string jsonData)
        {
            var productsAndOrders = JsonConvert.DeserializeObject<ImportProductsAndOrdersDto>(jsonData);
            SetCache(productsAndOrders.Orders);
        }
    }
}
