using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DTO;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodCheckUser()
        {
            string connStr = "Data Source=COMPUTER-SQLEXPRESS02;Initial Catalog=KursovaPZ;Integrated Security=True";
            ProductsDAL dal = new ProductsDAL(connStr);
            ProductsDTO currentproduct = null;
            currentproduct = dal.GetProductById(1);

            Assert.AreEqual(currentproduct.Price, 100);
        }

        [TestMethod]
        public void TestMethodCheckPriceUpdate()
        {
            string connStr = "Data Source=COMPUTER-SQLEXPRESS02;Initial Catalog=KursovaPZ;Integrated Security=True";
            ProductsDAL dal = new ProductsDAL(connStr);
            ProductsDTO currentproduct = null;
            currentproduct = dal.GetProductById(4);
            currentproduct.Price = 1000;
            currentproduct = dal.UpdatePrice(currentproduct);

            Assert.AreEqual(currentproduct.Price, 1000);
        }


        [TestMethod]
        public void CheckProductsCount()
        {
            string connStr = "Data Source=COMPUTER-SQLEXPRESS02;Initial Catalog=KursovaPZ;Integrated Security=True";
            ProductsDAL dal = new ProductsDAL(connStr);
            int count = dal.GetAllProducts().Count;

            Assert.AreEqual(count, 3);
        }


    }
}
