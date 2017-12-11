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
                    var clients = item.IGD_Clients.ToList();
                    
                    if (clients == null)
                    {
                        return new List<ClientInfo>();
                    }

                    List<ClientInfo> clientsList = clients.Select(client => new ClientInfo
                    {
                        Id = client.Id,
                        Phone = client.Phone,
                        Readed = client.Readed,
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
                    var client = item.IGD_Clients.Find(clientId);

                    if (client == null)
                    {
                        return new ClientInfo();
                    }

                    ClientInfo clientInfo = new ClientInfo
                    {
                        Id = client.Id,
                        Phone = client.Phone,
                        Readed = client.Readed,
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
                    var client = item.IGD_Clients.FirstOrDefault(c => c.Phone == phone);

                    if (client == null)
                    {
                        return new ClientInfo();
                    }

                    ClientInfo clientInfo = new ClientInfo
                    {
                        Id = client.Id,
                        Phone = client.Phone,
                        Readed = client.Readed,
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
                        IGD_Clients igdClient = new IGD_Clients()
                        {
                            Readed = client.Readed,
                            Phone = client.Phone,
                            LastReading = client.LastReading,
                            IGD_Deliveries = new List<IGD_Deliveries>()
                        };

                        item.IGD_Clients.Add(igdClient);

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
                        // Un tercer parámetro del FirstOrDefault recibe un predicado que es una función que me devuelve un valor.
                        var clientData = item.IGD_Clients.FirstOrDefault(c => c.Id == client.Id);

                        if (clientData != null)
                        {
                            clientData.Readed = client.Readed;
                            clientData.Phone = client.Phone;
                            clientData.LastReading = client.LastReading;

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
                        var clientData = item.IGD_Clients.FirstOrDefault(c => c.Id == clientId);

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