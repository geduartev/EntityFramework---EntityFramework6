//-----------------------------------------------------------------------
// <copyright file="UnitTestDocumentTypes.cs" company="Ingeniería GD®">
//     Copyright (c) Ingeniería GD® 2017. All rights reserved.
// </copyright>
// <author>Gabriel Eduardo Duarte Vega</author>
// <date>12/12/2017 11:12:35 AM</date>
//-----------------------------------------------------------------------
namespace IngenieriaGD.IGDDemo.Library.DALTest
{
    using IngenieriaGD.IGDDemo.Library.DAL.Data;
    using IngenieriaGD.IGDDemo.Library.DAL.Entities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Class.
    /// </summary>
    public class UnitTestDocumentTypes
    {
        [TestClass]
        public class UnitTestClients
        {
            [TestMethod]
            public void TestDocumentTypesInsert()
            {
                Assert.IsTrue(DocumentTypesRepository.GetInstance().Insert(new DocumentTypeInfo() { Title = "Tipo Documento Prueba", Code = "TDP001" }));

                DocumentTypeInfo temp = DocumentTypesRepository.GetInstance().SelectByCode("TDP001");

                Assert.IsTrue(DocumentTypesRepository.GetInstance().Delete(temp.Id));
            }

            [TestMethod]
            public void TestDocumentTypesSelectById()
            {
                Assert.IsTrue(DocumentTypesRepository.GetInstance().Insert(new DocumentTypeInfo() { Title = "Tipo Documento Prueba", Code = "TDP001" }));

                DocumentTypeInfo temp = DocumentTypesRepository.GetInstance().SelectByCode("TDP001");

                DocumentTypeInfo data = DocumentTypesRepository.GetInstance().SelectById(temp.Id);

                Assert.AreEqual("TDP001", data.Code);

                Assert.IsTrue(DocumentTypesRepository.GetInstance().Delete(data.Id));
            }

            [TestMethod]
            public void TestDocumentTypesSelectByPhone()
            {
                Assert.IsTrue(DocumentTypesRepository.GetInstance().Insert(new DocumentTypeInfo() { Title = "Tipo Documento Prueba", Code = "TDP001" }));

                DocumentTypeInfo temp = DocumentTypesRepository.GetInstance().SelectByCode("TDP001");

                DocumentTypeInfo data = DocumentTypesRepository.GetInstance().SelectByCode(temp.Code);

                Assert.AreEqual("TDP001", data.Code);

                Assert.IsTrue(DocumentTypesRepository.GetInstance().Delete(data.Id));
            }

            [TestMethod]
            public void TestDocumentTypesUpdate()
            {
                Assert.IsTrue(DocumentTypesRepository.GetInstance().Insert(new DocumentTypeInfo() { Title = "Tipo Documento Prueba", Code = "TDP001" }));

                DocumentTypeInfo temp = DocumentTypesRepository.GetInstance().SelectByCode("TDP001");

                temp.Title = "Tipo Documento Prueba MODIFICADO";
                temp.Code = "TDPM001";

                Assert.IsTrue(DocumentTypesRepository.GetInstance().Update(temp));

                Assert.IsTrue(DocumentTypesRepository.GetInstance().Delete(temp.Id));
            }

            [TestMethod]
            public void TestDocumentTypesDelete()
            {
                Assert.IsTrue(DocumentTypesRepository.GetInstance().Insert(new DocumentTypeInfo() { Title = "Tipo Documento Prueba", Code = "TDP001" }));

                DocumentTypeInfo temp = DocumentTypesRepository.GetInstance().SelectByCode("TDP001");

                Assert.IsTrue(DocumentTypesRepository.GetInstance().Delete(temp.Id));
            }

            [TestMethod]
            public void TestDocumentTypesSelectAll()
            {
                Assert.IsTrue(DocumentTypesRepository.GetInstance().Insert(new DocumentTypeInfo() { Title = "Tipo Documento Prueba", Code = "TDP001" }));

                DocumentTypeInfo temp = DocumentTypesRepository.GetInstance().SelectByCode("TDP001");

                var data = DocumentTypesRepository.GetInstance().SelectAll();

                Assert.IsTrue(data.Exists(x => x.Id == temp.Id));

                Assert.IsTrue(DocumentTypesRepository.GetInstance().Delete(temp.Id));
            }
        }
    }
}