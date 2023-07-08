using MentorMate.Restaurant.Business.Caches;
using MentorMate.Restaurant.Business.Dtos.Export;
using MentorMate.Restaurant.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MentorMate.Restaurant.Business.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly OrdersCache _ordersCache;
        private readonly ProductsCache _productsCache;

        public OrderProductService(
            OrdersCache ordersCache,
            ProductsCache productsCache)
        {
            _ordersCache = ordersCache;
            _productsCache = productsCache;
        }

        // Task 1
        public Product FindProductById(int id)
        {
            var product = _productsCache
                .Data
                .FirstOrDefault(p => p.Id == id);

            return product;
        }

        // Task 2
        public List<Product> FindProductsWithPriceLessThan(decimal productPrice)
        {
            var products = _productsCache
                .Data
                .Where(p => p.Price < productPrice)
                .ToList();

            return products;
        }

        // Task 3
        public List<Product> FindProductsThatContain(string data)
        {
            var products = _productsCache
                .Data
                .Where(p => p.Name.ToLower().Contains(data))
                .ToList();

            return products;
        }

        // Task 4
        public List<Order> FindOrdersWhichContain(string product)
        {
            var orders = _ordersCache
                .Data
                .Where(o => o.Products.Any(p => string.Compare(p.Product.Name, product, true) == 0))
                .ToList();

            return orders;
        }

        // Task 5
        public List<Order> FindOrdersWhichContainOneOfBoth(string productPineapple, string productKiwi)
        {
            var orders = _ordersCache
                .Data
                .Where(o => o.Products.Any(p => string.Compare(p.Product.Name, productPineapple, true) == 0) ||
                            o.Products.Any(p => string.Compare(p.Product.Name, productKiwi, true) == 0))
                .ToList();

            return orders;
        }

        // Task 6
        public List<Order> FindOredersBetweenDates(DateTime startDate, DateTime endDate)
        {
            var orders = _ordersCache
                .Data
                .Where(o => o.CompleteOn.HasValue && o.CompleteOn >= startDate && o.CompleteOn <= endDate)
                .OrderByDescending(o => o.TotalPrice)
                .ToList();

            return orders;
        }

        // Task 7
        public Dictionary<string, ExportProductDto> FindSoldProducts()
        {
            var products = _ordersCache
                .Data
                .Where(o => o.CompleteOn.HasValue)
                .SelectMany(o => o.Products)
                .GroupBy(p => p.Product.Name)
                .OrderBy(dto => dto.Key)
                .ToDictionary(dto => dto.Key, dto => new ExportProductDto
                {
                    Quantity = dto.Sum(p => p.Quantity),
                    AggregatedPrice = dto.Sum(p => p.Price * p.Quantity) / dto.Sum(p => p.Quantity)
                });

            return products;
        }

        // Task 8
        public Dictionary<DateTime, ExportOrderDto> FindSummaryDataOfCompletedOrders(DateTime startDate, DateTime endDate)
        {
            var completedOrders = _ordersCache
                .Data
                .Where(o => o.CompleteOn.HasValue && o.CompleteOn >= startDate && o.CompleteOn <= endDate)
                .GroupBy(o => o.CompleteOn.Value.Date)
                .OrderBy(o => o.Key)
                .ToDictionary(o => o.Key, o => new ExportOrderDto
                {
                    AvgOrderPrice = o.Average(o => o.TotalPrice),
                    MinOrderPrice = o.Min(o => o.TotalPrice),
                    MaxOrderPrice = o.Max(o => o.TotalPrice),
                    OrdersQuantityForDay = o.Count()
                });

            return completedOrders;
        }

        // Task 9
        public List<Order> FindOrders(int numbersToSkip, int numbersToTake)
        {
            var orders = _ordersCache
                .Data
                .OrderByDescending(o => o.CreateOn.Value.Day)
                .Skip(numbersToSkip)
                .Take(numbersToTake)
                .ToList();

            return orders;
        }
    }
}
