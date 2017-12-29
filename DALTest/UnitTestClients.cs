//-----------------------------------------------------------------------
// <copyright file="UnitTestClients.cs" company="Ingeniería GD®">
//     Copyright (c) Ingeniería GD® 2017. All rights reserved.
// </copyright>
// <author>Gabriel Eduardo Duarte Vega</author>
// <date>12/12/2017 11:12:35 AM</date>
//-----------------------------------------------------------------------
namespace IngenieriaGD.IGDDemo.Library.DALTest
{
    using System;
    using IngenieriaGD.IGDDemo.Library.DAL.Data;
    using IngenieriaGD.IGDDemo.Library.DAL.Entities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTestClients
    {
        private const string PHONE_NUMBER = "0000000000002";
        private const int DOCUMENT_TYPE_ID = 1;
        private const string DOCUMENT_NUMBER = "80040257";
        private const string FIRST_NAME = "Gabriel";
        private const string SECOND_NAME = "Duarte";

        private ClientInfo ClientTest = new ClientInfo() {
            DocumentTypeId = DOCUMENT_TYPE_ID,
            DocumentNumber = DOCUMENT_NUMBER,
            Phone = PHONE_NUMBER,
            FirstName = FIRST_NAME,
            SecondName = SECOND_NAME,
            Anniversary =DateTime.UtcNow,
            Address ="Bogotá DC",
            Email ="geduartev@gmail.com",
            Readed = true,
            LastReading = 1 };

        [TestMethod]
        public void TestClientsInsert()
        {
            ClientInfo tempClient = CreateClientTest(PHONE_NUMBER);
            DeleteClientTest(tempClient);
        }

        [TestMethod]
        public void TestClientsSelectById()
        {
            ClientInfo tempClient = CreateClientTest(PHONE_NUMBER);

            ClientInfo client = ClientsRepository.GetInstance().SelectById(tempClient.Id);

            Assert.AreEqual(PHONE_NUMBER, client.Phone);

            DeleteClientTest(tempClient);
        }

        [TestMethod]
        public void TestClientsSelectByPhone()
        {
            ClientInfo tempClient = CreateClientTest(PHONE_NUMBER);

            ClientInfo client = ClientsRepository.GetInstance().SelectByPhone(tempClient.Phone);

            Assert.AreEqual(PHONE_NUMBER, client.Phone);

            DeleteClientTest(tempClient);
        }

        [TestMethod]
        public void TestClientsSelectByDocument()
        {
            ClientInfo tempClient = CreateClientTest(PHONE_NUMBER);

            ClientInfo client = ClientsRepository.GetInstance().SelectByDocument(tempClient.DocumentTypeId, tempClient.DocumentNumber);

            Assert.AreEqual(DOCUMENT_TYPE_ID, client.DocumentTypeId);
            Assert.AreEqual(DOCUMENT_NUMBER, client.DocumentNumber);

            DeleteClientTest(tempClient);
        }

        [TestMethod]
        public void TestClientsUpdate()
        {
            ClientInfo tempClient = CreateClientTest(PHONE_NUMBER);

            tempClient.Readed = true;
            tempClient.LastReading += tempClient.LastReading;

            Assert.IsTrue(ClientsRepository.GetInstance().Update(tempClient));

            DeleteClientTest(tempClient);
        }

        [TestMethod]
        public void TestClientsDelete()
        {
            ClientInfo tempClient = CreateClientTest(PHONE_NUMBER);
            DeleteClientTest(tempClient);
        }

        [TestMethod]
        public void TestClientsSelectAll()
        {
            ClientInfo tempClient = CreateClientTest(PHONE_NUMBER);

            var QuantityClients = ClientsRepository.GetInstance().SelectAll();

            Assert.IsTrue(QuantityClients.Exists(x => x.Id == tempClient.Id));

            DeleteClientTest(tempClient);
        }

        #region Private

        private ClientInfo CreateClientTest(string phoneNumber)
        {
            Assert.IsTrue(ClientsRepository.GetInstance().Insert(ClientTest));

            ClientInfo tempClient = ClientsRepository.GetInstance().SelectByPhone(phoneNumber);
            return tempClient;
        }

        private static void DeleteClientTest(ClientInfo tempClient)
        {
            Assert.IsTrue(ClientsRepository.GetInstance().Delete(tempClient.Id));
        }

        #endregion
    }
}
