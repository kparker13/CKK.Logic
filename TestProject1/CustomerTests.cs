using CKK.Logic.Models;
using Xunit;
using Xunit.Sdk;


namespace CKK.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void AddingProduct()
        {
            Customer customer = new Customer();
            Product testProduct = new Product();
            testProduct.SetName("test");
            testProduct.SetPrice(1);
            testProduct.SetId(123);
            ShoppingCart testCart = new ShoppingCart(customer);
            testCart.AddProduct(testProduct, 2);

            int expected = 2;
            int actual = testCart.GetProduct(123).GetQuantity();

            Assert.Equal(actual, expected);

        }
        [Fact]
        public void RemovingProduct()
        {
            Customer customer = new Customer();
            Product testProduct = new Product();
            testProduct.SetName("test");
            testProduct.SetPrice(1);
            testProduct.SetId(123);
            ShoppingCart testCart = new ShoppingCart(customer);
            testCart.AddProduct(testProduct, 2);
            testCart.RemoveProduct(testProduct, 1);

            int expected = 1;
            int actual = testCart.GetProduct(123).GetQuantity();

            Assert.Equal(actual, expected);
        }
        [Fact]
        public void GettingTotal()
        {
            Customer customer = new Customer();
            Product testProduct = new Product();
            testProduct.SetName("test");
            testProduct.SetPrice(1);
            testProduct.SetId(123);
            ShoppingCart testCart = new ShoppingCart(customer);
            testCart.AddProduct(testProduct, 2);

            decimal expected = 2;
            decimal actual = testCart.GetProduct(123).GetTotal();

            Assert.Equal(actual, expected);
        }
    }
}