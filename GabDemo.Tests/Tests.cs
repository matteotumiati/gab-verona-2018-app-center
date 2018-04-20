using System;
using System.IO;
using System.Linq;
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

        public void NavigateToCustomerDetails()
        {
            
        }

        [Test]
        public void FindCustomerInList()
        {
            app.Tap(x => x.Text("Go to tests"));
            app.Screenshot("Customer list");

            app.ScrollDownTo(x => x.Text("Matteo Tumiati"));
            app.WaitForElement(x => x.Text("Matteo Tumiati"),
                               timeoutMessage: "Cannot find the element",
                               timeout: TimeSpan.FromSeconds(120));
            app.Flash(x => x.Text("Matteo Tumiati"));
            app.Screenshot("Customer selected");

            app.Tap(x => x.Text("Matteo Tumiati"));
        }
    }
}