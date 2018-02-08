//Author: Ray Medrano   //Purpose: This Will Test the ProductManager
using System;
using BangazonCLI.Managers;
using BangazonCLI.Models;
using Xunit;

namespace BangazonCLI.Tests
{
    public class ProductManagerShould
    {

        [Fact]
        public void AddProductToProductTable()
        {
            //create instances of both the productManager and a new product
            ProductManager pm = new ProductManager();
            //create SQL Insert Statement to add to database
            string NewProductString = "@$'INSERT INTO Product(Id, CustomerId, Title, Description, Price, Quantity, DateAdded)VALUES(null, Ray Medrano, Refrigerator, A 22 cubic foot refrigerator, 50000, 1, 2018-01-15)'";

            //Use the AddProduct method to add a new product
            pm.AddProduct(NewProductString);

            //Assert that the Product List contains the new product that was added
            Assert.Contains(NewProductString, pm.GetCustomerProducts(1));
        }

        [Fact]
        public void FindAllProductsNotForActiveCustomer()
        {
            //create instance of ProductManager to use for test
           ProductManager pm = new ProductManager();

           //create a new product with a customer id of 1
           Product NewProduct1 = new Product(1, 1, "NewProduct1", "This is a dummy Product1", 2000, 2);

           //add newproduct1 to product list
           pm.AddProduct(NewProduct1);

           //create a new product with a customer id of 2
           Product NewProduct2 = new Product(2, 2, "NewProduct2", "This is a dummy Product2",42000, 4);

           //add newProduct2 to product list
           pm.AddProduct(NewProduct2);

            Assert.DoesNotContain(NewProduct1, pm.GetNonActiveUserProduct(1));
        }

    }
}