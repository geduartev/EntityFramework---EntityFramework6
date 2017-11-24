using System;
using DemoEF.Backend.Business.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoEF.BackendTest
{
    [TestClass]
    public class UnitTestClientsBL
    {
        [TestMethod]
        public void TestMethod1()
        {
            var QuantityClients = ClientsBL.GetInstance().SelectAll().Count;
            Assert.AreEqual(3, QuantityClients);
        }
    }
}
