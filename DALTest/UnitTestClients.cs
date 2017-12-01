using IngenieriaGD.IGDDemo.Library.DAL.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IngenieriaGD.IGDDemo.Library.DALTest
{
    [TestClass]
    public class UnitTestClients
    {
        [TestMethod]
        public void TestInsert()
        {
            Assert.IsTrue( Clients.GetInstance().Insert( new IGD_Clients() {Phone = "0000000000002", Readed = true, LastReading = 1} ) );

            IGD_Clients tempClient = Clients.GetInstance().SelectByPhone("0000000000002");

            Assert.IsTrue(Clients.GetInstance().Delete(tempClient.Id));
        }

        [TestMethod]
        public void TestSelectById()
        {
            Assert.IsTrue( Clients.GetInstance().Insert(new IGD_Clients() { Phone = "0000000000002", Readed = false, LastReading = 0 }) );

            IGD_Clients tempClient = Clients.GetInstance().SelectByPhone("0000000000002");

            IGD_Clients client = Clients.GetInstance().SelectById(tempClient.Id);

            Assert.AreEqual("0000000000002", client.Phone);

            Assert.IsTrue(Clients.GetInstance().Delete(client.Id));
        }

        [TestMethod]
        public void TestSelectByPhone()
        {
            Assert.IsTrue(Clients.GetInstance().Insert(new IGD_Clients() { Phone = "0000000000002", Readed = false, LastReading = 0 }));

            IGD_Clients tempClient = Clients.GetInstance().SelectByPhone("0000000000002");

            IGD_Clients client = Clients.GetInstance().SelectByPhone(tempClient.Phone);

            Assert.AreEqual("0000000000002", client.Phone);

            Assert.IsTrue(Clients.GetInstance().Delete(client.Id));
        }

       [TestMethod]
        public void TestUpdate()
        {
            Assert.IsTrue(Clients.GetInstance().Insert(new IGD_Clients() { Phone = "0000000000002", Readed = false, LastReading = 0 }));

            IGD_Clients tempClient = Clients.GetInstance().SelectByPhone("0000000000002");

            tempClient.Readed = true;
            tempClient.LastReading += tempClient.LastReading;

            Assert.IsTrue(Clients.GetInstance().Update(tempClient));

            Assert.IsTrue(Clients.GetInstance().Delete(tempClient.Id));
        }
        
        [TestMethod]
        public void TestDelete()
        {
            Assert.IsTrue(Clients.GetInstance().Insert(new IGD_Clients() { Phone = "0000000000002", Readed = false, LastReading = 0 }));

            IGD_Clients tempClient = Clients.GetInstance().SelectByPhone("0000000000002");

            Assert.IsTrue(Clients.GetInstance().Delete(tempClient.Id));
        }

        [TestMethod]
        public void TestSelectAll()
        {
            Assert.IsTrue(Clients.GetInstance().Insert(new IGD_Clients() { Phone = "0000000000002", Readed = false, LastReading = 0 }));

            IGD_Clients tempClient = Clients.GetInstance().SelectByPhone("0000000000002");

            var QuantityClients = Clients.GetInstance().SelectAll();

            // TODO: Revisar.
            Assert.IsTrue(QuantityClients.Contains(tempClient));

            Assert.IsTrue(Clients.GetInstance().Delete(tempClient.Id));
        }
    }
}
