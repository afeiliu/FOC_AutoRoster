using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Services.Customer;

namespace Demo.Services.Tests.Customer
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void GetAllMethod()
        {
            var service = new UserService();

            int total;
            var entities = service.GetAll(1, 10, out total);

            Assert.IsNotNull(entities);
        }
    }
}
