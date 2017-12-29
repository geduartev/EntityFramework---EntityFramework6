//-----------------------------------------------------------------------
// <copyright file="DocumentTypesRepository.cs" company="Ingeniería GD®">
//     Copyright (c) Ingeniería GD® 2017. All rights reserved.
// </copyright>
// <author>Gabriel Eduardo Duarte Vega</author>
// <date>12/12/2017 11:03:47 AM</date>
//-----------------------------------------------------------------------
namespace IngenieriaGD.IGDDemo.Library.DAL.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Transactions;
    using IngenieriaGD.IGDDemo.Library.DAL.Entities;

    /// <summary>
    /// Class.
    /// </summary>
    public class DocumentTypesRepository
    {
        #region Singleton

        private static readonly DocumentTypesRepository documentTypesRepository = new DocumentTypesRepository();

        public static DocumentTypesRepository GetInstance()
        {
            return documentTypesRepository;
        }

        #endregion

        #region CRUD Methods

        public List<DocumentTypeInfo> SelectAll()
        {
            try
            {
                using (var item = new IGDDemoEntities())
                {
                    var documentTypes = item.DocumentTypes.ToList();

                    if (documentTypes == null)
                    {
                        return null;
                    }

                    List<DocumentTypeInfo> documentTypesList = documentTypes.Select(document => new DocumentTypeInfo
                    {
                        Id = document.Id,
                        Title = document.Title,
                        Code = document.Code
                    }).ToList();

                    return documentTypesList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DocumentTypeInfo SelectById(int documentTypeId)
        {
            try
            {
                using (var item = new IGDDemoEntities())
                {
                    var documentType = item.DocumentTypes.Find(documentTypeId);

                    if (documentType == null)
                    {
                        return null;
                    }

                    DocumentTypeInfo documentTypeInfo = new DocumentTypeInfo
                    {
                        Id = documentType.Id,
                        Title = documentType.Title,
                        Code = documentType.Code
                    };

                    return documentTypeInfo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DocumentTypeInfo SelectByCode(string Code)
        {
            try
            {
                using (var item = new IGDDemoEntities())
                {
                    var documentType = item.DocumentTypes.FirstOrDefault(d => d.Code == Code);

                    if (documentType == null)
                    {
                        return null;
                    }

                    DocumentTypeInfo documentTypeInfo = new DocumentTypeInfo
                    {
                        Id = documentType.Id,
                        Title = documentType.Title,
                        Code = documentType.Code
                    };

                    return documentTypeInfo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Insert(DocumentTypeInfo documentType)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    using (var item = new IGDDemoEntities())
                    {
                        DocumentTypes igdDocumentTypes = new DocumentTypes()
                        {
                            Title = documentType.Title,
                            Code = documentType.Code
                        };

                        item.DocumentTypes.Add(igdDocumentTypes);

                        if (item.SaveChanges().Equals(1))
                        {
                            scope.Complete();
                            return true;
                        }

                        scope.Dispose();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public bool Update(DocumentTypeInfo documentTypeInfo)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    using (var item = new IGDDemoEntities())
                    {
                        // Un tercer parámetro del FirstOrDefault recibe un predicado que es una función que me devuelve un valor.
                        var documentTypeData = item.DocumentTypes.FirstOrDefault(d => d.Id == documentTypeInfo.Id);

                        if (documentTypeData != null)
                        {
                            documentTypeData.Title = documentTypeInfo.Title;
                            documentTypeData.Code = documentTypeInfo.Code;

                            item.Entry(documentTypeData).State = System.Data.Entity.EntityState.Modified;
                            item.Entry(documentTypeData).CurrentValues.SetValues(documentTypeData);
                            item.SaveChanges();
                            scope.Complete();
                            return true;
                        }

                        scope.Dispose();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(int documentTypeId)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    using (var item = new IGDDemoEntities())
                    {
                        var documentTypeData = item.DocumentTypes.FirstOrDefault(d => d.Id == documentTypeId);

                        if (documentTypeData != null)
                        {
                            item.Entry(documentTypeData).State = System.Data.Entity.EntityState.Deleted;
                            item.SaveChanges();
                            scope.Complete();
                            return true;
                        }

                        scope.Dispose();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}