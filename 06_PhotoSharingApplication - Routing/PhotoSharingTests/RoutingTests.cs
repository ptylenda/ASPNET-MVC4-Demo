using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoSharingApplication;
using PhotoSharingTests.Doubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace PhotoSharingTests
{
    [TestClass]
    public class RoutingTests
    {
        [TestMethod]
        public void TestDefaultRouteControllerOnly()
        {
            var data = CreateRouteData("~/ControllerName");

            Assert.IsNotNull(data);
            Assert.AreEqual("ControllerName", data.Values["controller"]);
            Assert.AreEqual("Index", data.Values["action"]);
        }

        [TestMethod]
        public void TestDefaultRouteWithPhotoId()
        {
            var data = CreateRouteData("~/Photo/2");

            Assert.IsNotNull(data);
            Assert.AreEqual("Photo", data.Values["controller"]);
            Assert.AreEqual("Display", data.Values["action"]);
            Assert.AreEqual("2", data.Values["id"]);
        }

        [TestMethod]
        public void TestDefaultRouteTitleRoute()
        {
            var data = CreateRouteData("~/photo/title/my%20title");

            Assert.IsNotNull(data);
            Assert.AreEqual("Photo", data.Values["controller"]);
            Assert.AreEqual("DisplayByTitle", data.Values["action"]);
            Assert.AreEqual("my%20title", data.Values["title"]);
        }

        private static RouteData CreateRouteData(string url)
        {
            var context = new FakeHttpContextForRouting(requestUrl: url);
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            return routes.GetRouteData(context);
        }
    }
}
