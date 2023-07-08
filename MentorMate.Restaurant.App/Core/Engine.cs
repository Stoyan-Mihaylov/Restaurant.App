using MentorMate.Restaurant.Business.Caches;
using MentorMate.Restaurant.Business.Common;
using MentorMate.Restaurant.Business.Services;
using Newtonsoft.Json;
using System;
using System.IO;

namespace MentorMate.Restaurant.App.Core
{
    public class Engine : IEngine
    {
        private readonly ProductsCache _productsCache;
        private readonly OrdersCache _ordersCache;
        private readonly IOrderProductService _orderProductService;

        public Engine(
            ProductsCache productsCache,
            OrdersCache ordersCache,
            IOrderProductService orderProductService)
        {
            _productsCache = productsCache;
            _ordersCache = ordersCache;
            _orderProductService = orderProductService;
        }

        public void Run()
        {
            var jsonData = ReadsFromJsonFile(Constants.DataFilePath);

            if (!Directory.Exists(Constants.DirectoryPath))
            {
                Directory.CreateDirectory(Constants.DirectoryPath);
            }

            _ordersCache.Init(jsonData);
            _productsCache.Init(jsonData);


            var startDate = new DateTime(2022, 11, 27);
            var endDate = new DateTime(2022, 11, 30);

            var product = _orderProductService.FindProductById(Constants.ProductId);
            var products = _orderProductService.FindProductsWithPriceLessThan(Constants.ProductPrice);
            var productsContainsBerries = _orderProductService.FindProductsThatContain(Constants.Berry);
            var ordersWhichContainsApple = _orderProductService.FindOrdersWhichContain(Constants.ProductApple);
            var ordersWhichContainsPineappleOrKiwi = _orderProductService.FindOrdersWhichContainOneOfBoth(Constants.ProductPineapple, Constants.ProductKiwi);
            var ordersBetweenDates = _orderProductService.FindOredersBetweenDates(startDate, endDate);
            var soldProducts = _orderProductService.FindSoldProducts();
            var summaryDataOfCompletedOrders = _orderProductService.FindSummaryDataOfCompletedOrders(startDate, endDate);
            var secondTwentyOrders = _orderProductService.FindOrders(Constants.NumbersToSkip, Constants.NumbersToTake);


            WritesInJsonFile(Constants.OutputFilePath, summaryDataOfCompletedOrders);
        }

        private string ReadsFromJsonFile(string dataFilePath)
        {
            string jsonData = default!;
            try
            {
                jsonData = File.ReadAllText(dataFilePath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }
            return jsonData;
        }

        private void WritesInJsonFile<T>(string outputFilePath, T obj)
        {
            var result = JsonConvert.SerializeObject(obj, Formatting.Indented);

            File.WriteAllText(outputFilePath, result);
        }
    }
}
