using IngenieriaGD.IGDDemo.Library.DAL.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IngenieriaGD.IGDDemo.Library.DALTest
{
    [TestClass]
    public class UnitTestClients
    {
        [TestMethod]
        public void TestMethod1()
        {
            var QuantityClients = Clients.GetInstance().SelectAll().Count;
            Assert.AreEqual(2, QuantityClients);
        }
    }
}
