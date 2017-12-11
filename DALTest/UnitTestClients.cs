using IngenieriaGD.IGDDemo.Library.DAL.Data;
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
            Assert.IsTrue(ClientsRepository.GetInstance().Insert(new ClientInfo() { Phone = "0000000000002", Readed = true, LastReading = 1 }));

            ClientInfo tempClient = ClientsRepository.GetInstance().SelectByPhone("0000000000002");

            Assert.IsTrue(ClientsRepository.GetInstance().Delete(tempClient.Id));
        }

        [TestMethod]
        public void TestSelectById()
        {
            Assert.IsTrue(ClientsRepository.GetInstance().Insert(new ClientInfo() { Phone = "0000000000002", Readed = false, LastReading = 0 }));

            ClientInfo tempClient = ClientsRepository.GetInstance().SelectByPhone("0000000000002");

            ClientInfo client = ClientsRepository.GetInstance().SelectById(tempClient.Id);

            Assert.AreEqual("0000000000002", client.Phone);

            Assert.IsTrue(ClientsRepository.GetInstance().Delete(client.Id));
        }

        [TestMethod]
        public void TestSelectByPhone()
        {
            Assert.IsTrue(ClientsRepository.GetInstance().Insert(new ClientInfo() { Phone = "0000000000002", Readed = false, LastReading = 0 }));

            ClientInfo tempClient = ClientsRepository.GetInstance().SelectByPhone("0000000000002");

            ClientInfo client = ClientsRepository.GetInstance().SelectByPhone(tempClient.Phone);

            Assert.AreEqual("0000000000002", client.Phone);

            Assert.IsTrue(ClientsRepository.GetInstance().Delete(client.Id));
        }

        [TestMethod]
        public void TestUpdate()
        {
            Assert.IsTrue(ClientsRepository.GetInstance().Insert(new ClientInfo() { Phone = "0000000000002", Readed = false, LastReading = 0 }));

            ClientInfo tempClient = ClientsRepository.GetInstance().SelectByPhone("0000000000002");

            tempClient.Readed = true;
            tempClient.LastReading += tempClient.LastReading;

            Assert.IsTrue(ClientsRepository.GetInstance().Update(tempClient));

            Assert.IsTrue(ClientsRepository.GetInstance().Delete(tempClient.Id));
        }

        [TestMethod]
        public void TestDelete()
        {
            Assert.IsTrue(ClientsRepository.GetInstance().Insert(new ClientInfo() { Phone = "0000000000002", Readed = false, LastReading = 0 }));

            ClientInfo tempClient = ClientsRepository.GetInstance().SelectByPhone("0000000000002");

            Assert.IsTrue(ClientsRepository.GetInstance().Delete(tempClient.Id));
        }

        [TestMethod]
        public void TestSelectAll()
        {
            Assert.IsTrue(ClientsRepository.GetInstance().Insert(new ClientInfo() { Phone = "0000000000002", Readed = false, LastReading = 0 }));

            ClientInfo tempClient = ClientsRepository.GetInstance().SelectByPhone("0000000000002");

            var QuantityClients = ClientsRepository.GetInstance().SelectAll();

            Assert.IsTrue(QuantityClients.Exists(x => x.Id == tempClient.Id));

            Assert.IsTrue(ClientsRepository.GetInstance().Delete(tempClient.Id));
        }
    }
}
