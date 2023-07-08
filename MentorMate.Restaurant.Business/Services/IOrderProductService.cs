using MentorMate.Restaurant.Business.Dtos.Export;
using MentorMate.Restaurant.Business.Models;
using System;
using System.Collections.Generic;

namespace MentorMate.Restaurant.Business.Services
{
    public interface IOrderProductService
    {
        List<Order> FindOrdersWhichContain(string product);
        List<Order> FindOrdersWhichContainOneOfBoth(string productPineapple, string productKiwi);
        List<Order> FindOredersBetweenDates(DateTime startDate, DateTime endDate);
        Product FindProductById(int id);
        public List<Order> FindOrders(int numbersToSkip, int numbersToTake);
        Dictionary<string, ExportProductDto> FindSoldProducts();
        List<Product> FindProductsThatContain(string data);
        List<Product> FindProductsWithPriceLessThan(decimal productPrice);
        Dictionary<DateTime, ExportOrderDto> FindSummaryDataOfCompletedOrders(DateTime startDate, DateTime endDate);
    }
}