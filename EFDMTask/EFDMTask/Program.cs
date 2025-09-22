using EFDMTask.Data;
using EFDMTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace EFDMTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BikeStores519Context dbContext = new BikeStores519Context();
            //1-List all customers' first and last names along with their email addresses.
            var customerWithEmailContainName = dbContext.Customers.Where(c => c.Email.Contains(c.FirstName) && c.Email.Contains(c.LastName));
            foreach (var customer in customerWithEmailContainName)
                Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}\t\t Email: {customer.Email}");
            Console.WriteLine("\n");

            //2 - Retrieve all orders processed by a specific staff member(e.g., staff_id = 3).
            var orderWitheSpecificStaff = dbContext.Orders.Where(o => o.StaffId == 3);
            foreach (var order in orderWitheSpecificStaff)
                Console.WriteLine($"Order Id: {order.OrderId}\tOrder Date: {order.OrderDate}\tStaff Id: {order.StaffId}");

            Console.WriteLine("\n");

            //3- Get all products that belong to a category named "Mountain Bikes".
            var mountainBikesProduct = dbContext.Products.Where(p => p.Category.CategoryName == "Mountain Bikes");
            foreach (var product in mountainBikesProduct)
                Console.WriteLine($"Product Name: {product.ProductName}\t\t| Product Price: {product.ListPrice}");

            Console.WriteLine("\n");

            //4-Count the total number of orders per store.
            var totalCountPerStore = dbContext.Orders.GroupBy(o => o.Store.StoreName).Select(s =>
                new
                {
                    StoreName = s.Key,
                    countOrder = s.Count()
                });
            foreach (var order in totalCountPerStore)
                Console.WriteLine($"Store Name: {order.StoreName}\t|\tOrder Count: {order.countOrder}");

            Console.WriteLine("\n");

            //5- List all orders that have not been shipped yet (shipped_date is null).
            var orderEithNull = dbContext.Orders.Where(o => o.ShippedDate == null);
            foreach (var order in orderEithNull)
                Console.WriteLine($"Order Id: {order.OrderId}\tShipped Date: {order.ShippedDate}");

            Console.WriteLine("\n");

            //6- Display each customer’s full name and the number of orders they have placed.
            var customerName = dbContext.Orders.GroupBy(o => new { o.Customer.FirstName, o.Customer.LastName }).Select(c => new
            {
                name = c.Key,
                orderCount = c.Count()
            });
            foreach (var customer in customerName)
                Console.WriteLine($"Customer Name: {customer.name.FirstName} {customer.name.LastName}\t\t | \t\tOrder Count: {customer.orderCount}");

            Console.WriteLine("\n");

            //7- List all products that have never been ordered (not found in order_items).
            var productNotOrdered = dbContext.OrderItems.Where(ot => ot.OrderId == null).Join(dbContext.Products,
                oi => oi.ProductId,
                pi => pi.ProductId,
                (o, p) => new
                {
                    p.ProductName,
                    p.ProductId,
                    p.ModelYear,
                    p.ListPrice
                });
            foreach (var product in productNotOrdered)
                Console.WriteLine($"Id: {product.ProductId}\tProduct Name: {product.ProductName}\tModel Year: {product.ModelYear}\tPrice: {product.ListPrice}");

            Console.WriteLine("\n");

            //8- Display products that have a quantity of less than 5 in any store stock.
            var productLessThan5 = dbContext.Stocks.Where(s => s.Quantity < 5).Select(s => s.Product.ProductName);
            foreach (var product in productLessThan5)
                Console.WriteLine($"Product Name: {product}");

            Console.WriteLine("\n");

            //9- Retrieve the first product from the products table.
            var firstProduct = dbContext.Products.FirstOrDefault();
            Console.WriteLine($"Name: {firstProduct.ProductName} , Id: {firstProduct.ProductId}");

            Console.WriteLine("\n");

            //10- Retrieve all products from the products table with a certain model year.
            var productrWithSpecificYear = dbContext.Products.Where(p => p.ModelYear == 2019);
            foreach (var product in productrWithSpecificYear)
                Console.WriteLine($"Product Name: {product.ProductName} , Model Year: {product.ModelYear} , Price: {product.ListPrice}");

            Console.WriteLine("\n");

            //11- Display each product with the number of times it was ordered.
            var productWithItem = dbContext.OrderItems.Join(dbContext.Products,
                oi => oi.ProductId,
                p => p.ProductId,
                (o, p) => new
                {
                    p.ProductName,
                    p.ProductId,
                    p.ModelYear,
                    o.ListPrice,
                    o.Quantity,
                    o.OrderId
                });
            foreach (var product in productWithItem)
                Console.WriteLine($"Product Id: {product.ProductId} , Product Name: {product.ProductName} , Price: {product.ListPrice} , Quantity: {product.Quantity}");

            Console.WriteLine("\n");

            //12- Count the number of products in a specific category.
            Console.WriteLine("Products in a Specific Category");
            var productWithspecificcategory = dbContext.Products.Where(p => p.Category.CategoryName == "Electric Bikes");
            foreach (var product in productWithspecificcategory)
                Console.WriteLine($" Product Name: {product.ProductName} , Price: {product.ListPrice}");

            Console.WriteLine("\n");

            //13- Calculate the average list price of products.
            Console.WriteLine("average list price of products");
            var averagePriceOfProduct = dbContext.Products.Average(p => p.ListPrice);
            Console.WriteLine($"average list price of products: {averagePriceOfProduct}");

            Console.WriteLine("\n");

            //14- Retrieve a specific product from the products table by ID.
            var productWithSpecificId = dbContext.Products.Where(p => p.ProductId == 90).Select(p => new { p.ProductName, p.ListPrice, p.ProductId });
            foreach (var product in productWithSpecificId)
                Console.WriteLine($"Product Id: {product.ProductId} , Product Name: {product.ProductName} , Price: {product.ListPrice}");

            Console.WriteLine("\n");

            //15- List all products that were ordered with a quantity greater than 3 in any order.
            var orderedProductWithQuantityGreater3 = dbContext.OrderItems.Join(dbContext.Orders,
                oi => oi.OrderId,
                o => o.OrderId,
                (oi, o) => new
                {
                    oi.ListPrice,
                    oi.Quantity,
                    oi.ProductId
                }).Join(dbContext.Products, oi => oi.ProductId, p => p.ProductId, (oi, p) => new
                {
                    p.ProductName,
                    p.ModelYear,
                    oi.Quantity,
                    oi.ProductId,
                    oi.ListPrice
                }).Where(q => q.Quantity > 3);
            foreach (var product in orderedProductWithQuantityGreater3)
                Console.WriteLine($"Product Id: {product.ProductId} , Product Name: {product.ProductName} , Price: {product.ListPrice} , Quantity: {product.Quantity}" +
                    $" , Model: {product.ModelYear}");

            Console.WriteLine("\n");

            //16- Display each staff member’s name and how many orders they processed.
            var staffManyOrdersTheyProcessed = dbContext.Orders.Join(dbContext.Staffs, o => o.StaffId, s => s.StaffId, (od, st) => new { od, st }).GroupBy(st => new
            {
                st.st.FirstName,
                st.st.LastName
            }).Select(se => new
            {
                name = se.Key,
                countOrder = se.Count()
            });
            foreach (var staff in staffManyOrdersTheyProcessed)
                Console.WriteLine($"Staff Name: {staff.name.FirstName} {staff.name.LastName}, Order Count: {staff.countOrder}");

            Console.WriteLine("\n");

            //17- List active staff members only (active = true) along with their phone numbers.
            var activeStaff = dbContext.Staffs.Where(st => st.Active == 1);
            foreach (var staff in activeStaff)
            {
                bool active = (staff.Active == 1)? true : false;
                Console.WriteLine($"Staff Name: {staff.FirstName} {staff.LastName} , Active: {active}");
            }

            Console.WriteLine("\n");

            //18- List all products with their brand name and category name.
            var productWithCategroyBrand = dbContext.Products.Join(dbContext.Categories, p => p.CategoryId, c => c.CategoryId, (p, c) => new { p, c })
                .Join(dbContext.Brands, pr => pr.p.BrandId, br => br.BrandId, (pr, br) => new { pr, br });
            foreach (var product in productWithCategroyBrand)
                Console.WriteLine($"Product Name: {product.pr.p.ProductName} , Categroy Name: {product.pr.c.CategoryName} , Brand Name: {product.br.BrandName}");

            Console.WriteLine("\n");

            //19- Retrieve orders that are completed.
            var orderCompleted = dbContext.Orders.Where(o => o.OrderStatus == 3);
            foreach (var order in orderCompleted)
                Console.WriteLine($"Order Id: {order.OrderId} , Requier Date: {order.RequiredDate}");

            Console.WriteLine("\n");

            //20- List each product with the total quantity sold (sum of quantity from order_items).
            var productQuantitySold = dbContext.OrderItems.Join(dbContext.Products, oi => oi.ProductId, pr => pr.ProductId, (oi, pr) => new { oi, pr })
                .GroupBy(g => g.pr.ProductName).Select(se => new { productName = se.Key, sum = se.Sum(o => o.oi.Quantity) });
            foreach (var product in productQuantitySold)
                Console.WriteLine($"Product Name: {product.productName} , Total Count Sold: {product.sum}");
        }
    }
}
