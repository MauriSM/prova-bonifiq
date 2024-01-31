


//namespace ProvaPub.Tests
//{
//    public class CustomerServiceTests
//    {



//    }
//}

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPub.Tests
{
    [TestClass()]
    public class CustomerServiceTests
    {
        TestDbContext _ctx;

        public CustomerServiceTests(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        [TestMethod()]
        public async void CanPurchaseTest(int customerId = 1)
        {
            var customer = await _ctx.Customers.FindAsync(customerId);
            if (customer == null) throw new InvalidOperationException($"Customer Id {customerId} does not exists");
        }

        [TestMethod()]
        public async void CanPurchaseTest1(int customerId = 1)
        {
            var baseDate = DateTime.UtcNow.AddMonths(-1);
            var ordersInThisMonth = await _ctx.Orders.CountAsync(s => s.CustomerId == customerId && s.OrderDate >= baseDate);

            //if (ordersInThisMonth > 0)
            //    return false;
            Assert.IsFalse(ordersInThisMonth > 0);
        }

        [TestMethod()]
        public async void CanPurchaseTest2(int customerId = 1, decimal purchaseValue = 50)
        {
            var haveBoughtBefore = await _ctx.Customers.CountAsync(s => s.Id == customerId && s.Orders.Any());
            //if (haveBoughtBefore == 0 && purchaseValue > 100)
            //return false;
            Assert.IsFalse(haveBoughtBefore == 0 && purchaseValue > 100);
        }

        [TestMethod]
        public void CanPurchaseTest3(int customerId = 1)
        {
            if (customerId <= 0) throw new ArgumentOutOfRangeException(nameof(customerId));

        }

        [TestMethod]
        public void CanPurchaseTest4(decimal purchaseValue = 50)
        {
            if (purchaseValue <= 0) throw new ArgumentOutOfRangeException(nameof(purchaseValue));
        }

    }
}