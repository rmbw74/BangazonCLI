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

            Product NewProduct = new Product();

            //Use the AddProduct method to add a new product
            pm.AddProduct(NewProduct);

            //Assert that the Product List contains the new product that was added
            Assert.Contains(NewProduct, pm.GetCustomerProducts(1));
        }

        [Fact]
        public void FindAllProductsNotForActiveCustomer()
        {
            //create instance of ProductManager to use for test
           ProductManager pm = new ProductManager();
           //create a new product
           Product NewProduct1 = new Product(1, 1, "NewProduct1", "This is a dummy Product1", 2000, 2);


            Assert.DoesNotContain(NewProduct1, pm.GetNonActiveUserProduct);
        }

    }
}