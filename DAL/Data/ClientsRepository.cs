//-----------------------------------------------------------------------
// <copyright file="ClientsRepository.cs" company="Ingeniería GD®">
//     Copyright (c) Ingeniería GD® 2017. All rights reserved.
// </copyright>
// <author>Gabriel Eduardo Duarte Vega</author>
// <date>11/23/2017 9:55:41 AM</date>
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
    public class ClientsRepository
    {
        #region Singleton

        private static readonly ClientsRepository clientsRepository = new ClientsRepository();

        public static ClientsRepository GetInstance()
        {
            return clientsRepository;
        }

        #endregion

        #region CRUD Methods
        
        public List<ClientInfo> SelectAll()
        {
            try
            {
                using (var item = new IGDDemoEntities())
                {
                    var clients = item.Clients.ToList();

                    if (clients == null)
                    {
                        return null;
                    }
                    
                    List<ClientInfo> clientsList = clients.Select(client => new ClientInfo
                    {
                        Id = client.Id,
                        DocumentTypeId = item.People.FirstOrDefault(p => p.Id == client.PersonId).DocumentTypeId,
                        DocumentNumber = item.People.FirstOrDefault(p => p.Id == client.PersonId).DocumentNumber,
                        FirstName = item.People.FirstOrDefault(p => p.Id == client.PersonId).FirstName,
                        SecondName = item.People.FirstOrDefault(p => p.Id == client.PersonId).SecondName,
                        Phone = client.Phone,
                        Readed = client.Readed,
                        Anniversary = client.Anniversary.Value,
                        Email = client.Email,
                        Address = client.Address,
                        LastReading = client.LastReading
                    }).ToList();

                    return clientsList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ClientInfo SelectById(int clientId)
        {
            try
            {
                using (var item = new IGDDemoEntities())
                {
                    var client = item.Clients.Find(clientId);

                    if (client == null)
                    {
                        return null;
                    }

                    ClientInfo clientInfo = new ClientInfo
                    {
                        Id = client.Id,
                        DocumentTypeId = item.People.FirstOrDefault(p => p.Id == client.PersonId).DocumentTypeId,
                        DocumentNumber = item.People.FirstOrDefault(p => p.Id == client.PersonId).DocumentNumber,
                        FirstName = item.People.FirstOrDefault(p => p.Id == client.PersonId).FirstName,
                        SecondName = item.People.FirstOrDefault(p => p.Id == client.PersonId).SecondName,
                        Phone = client.Phone,
                        Readed = client.Readed,
                        Anniversary = client.Anniversary.Value,
                        Email = client.Email,
                        Address = client.Address,
                        LastReading = client.LastReading
                    };

                    return clientInfo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ClientInfo SelectByPhone(string phone)
        {
            try
            {
                using (var item = new IGDDemoEntities())
                {
                    var client = item.Clients.FirstOrDefault(c => c.Phone == phone);

                    if (client == null)
                    {
                        return null;
                    }

                    ClientInfo clientInfo = new ClientInfo
                    {
                        Id = client.Id,
                        DocumentTypeId = item.People.FirstOrDefault(p => p.Id == client.PersonId).DocumentTypeId,
                        DocumentNumber = item.People.FirstOrDefault(p => p.Id == client.PersonId).DocumentNumber,
                        FirstName = item.People.FirstOrDefault(p => p.Id == client.PersonId).FirstName,
                        SecondName = item.People.FirstOrDefault(p => p.Id == client.PersonId).SecondName,
                        Phone = client.Phone,
                        Readed = client.Readed,
                        Anniversary = client.Anniversary.Value,
                        Email = client.Email,
                        Address = client.Address,
                        LastReading = client.LastReading
                    };

                    return clientInfo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ClientInfo SelectByDocument(int documentTypeId, string documentNumber)
        {
            try
            {
                using (var item = new IGDDemoEntities())
                {
                    var person = item.People.FirstOrDefault(p => p.DocumentTypeId == documentTypeId && p.DocumentNumber == documentNumber);

                    if (person == null)
                    {
                        return null;
                    }

                    var client = item.Clients.FirstOrDefault(c => c.PersonId == person.DocumentTypeId);

                    if (client == null)
                    {
                        return null;
                    }

                    ClientInfo clientInfo = new ClientInfo
                    {
                        Id = client.Id,
                        DocumentTypeId = item.People.FirstOrDefault(p => p.Id == client.PersonId).DocumentTypeId,
                        DocumentNumber = item.People.FirstOrDefault(p => p.Id == client.PersonId).DocumentNumber,
                        FirstName = item.People.FirstOrDefault(p => p.Id == client.PersonId).FirstName,
                        SecondName = item.People.FirstOrDefault(p => p.Id == client.PersonId).SecondName,
                        Phone = client.Phone,
                        Readed = client.Readed,
                        Anniversary = client.Anniversary.Value,
                        Email = client.Email,
                        Address = client.Address,
                        LastReading = client.LastReading
                    };

                    return clientInfo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Insert(ClientInfo client)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    using (var item = new IGDDemoEntities())
                    {
                        var personData = item.People.FirstOrDefault(p => p.DocumentTypeId == client.DocumentTypeId && p.DocumentNumber == client.DocumentNumber);

                        if  (personData == null)
                        {
                            People person = new People()
                            {
                                DocumentTypeId = client.DocumentTypeId,
                                DocumentNumber = client.DocumentNumber,
                                FirstName = client.FirstName,
                                SecondName = client.SecondName
                            };

                            item.People.Add(person);

                            if (!item.SaveChanges().Equals(1))
                            {
                                return false;
                            }

                            personData = item.People.FirstOrDefault(p => p.DocumentTypeId == client.DocumentTypeId && p.DocumentNumber == client.DocumentNumber);
                        }

                        Clients igdClient = new Clients()
                        {
                            Readed = client.Readed,
                            Phone = client.Phone,
                            LastReading = client.LastReading,
                            Deliveries = new List<Deliveries>(),
                            PersonId = personData.Id,
                            Anniversary = client.Anniversary,
                            Email = client.Email,
                            Address = client.Address
                        };

                        item.Clients.Add(igdClient);

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

        public bool Update(ClientInfo client)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    using (var item = new IGDDemoEntities())
                    {
                        var clientData = item.Clients.FirstOrDefault(c => c.Id == client.Id);

                        if (clientData != null)
                        {
                            var personData = item.People.FirstOrDefault(p => p.Id == clientData.PersonId);

                            personData.DocumentTypeId = client.DocumentTypeId;
                            personData.DocumentNumber = client.DocumentNumber;
                            personData.FirstName = client.FirstName;
                            personData.SecondName = client.SecondName;

                            item.Entry(personData).State = System.Data.Entity.EntityState.Modified;
                            item.Entry(personData).CurrentValues.SetValues(personData);
                            item.SaveChanges();

                            clientData.Readed = client.Readed;
                            clientData.Phone = client.Phone;
                            clientData.LastReading = client.LastReading;
                            clientData.Anniversary = client.Anniversary;
                            clientData.Email = client.Email;
                            clientData.Address = client.Address;

                            item.Entry(clientData).State = System.Data.Entity.EntityState.Modified;
                            item.Entry(clientData).CurrentValues.SetValues(clientData);
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

        public bool Delete(int clientId)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    using (var item = new IGDDemoEntities())
                    {
                        var clientData = item.Clients.FirstOrDefault(c => c.Id == clientId);

                        if (clientData != null)
                        {
                            item.Entry(clientData).State = System.Data.Entity.EntityState.Deleted;
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