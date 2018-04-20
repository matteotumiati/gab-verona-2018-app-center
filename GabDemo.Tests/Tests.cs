using System;
using System.IO;
using System.Linq;
using GabDemo.Tests.Models;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace GabDemo.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void FindCustomerInList()
        {
            var customer = new Customer(app);

            customer.GoToCustomersPage();
            customer.SearchCustomer("Matteo Tumiati");
            customer.SelectCustomer("Matteo Tumiati");
        }

        [Test]
        public void ModifyCustomerDetails()
        {
            var customer = new Customer(app);

            customer.GoToCustomersPage();
            customer.SearchCustomer("Matteo Tumiati");
            customer.ModifyCustomerDetails("Matteo Tumiati");
        }
    }
}