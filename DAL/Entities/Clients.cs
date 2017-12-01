//-----------------------------------------------------------------------
// <copyright file="Clients.cs" company="Ingeniería GD®">
//     Copyright (c) Ingeniería GD® 2017. All rights reserved.
// </copyright>
// <author>Gabriel Eduardo Duarte Vega</author>
// <date>11/23/2017 9:55:41 AM</date>
//-----------------------------------------------------------------------
namespace IngenieriaGD.IGDDemo.Library.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Transactions;

    /// <summary>
    /// Class.
    /// </summary>
    public class Clients
    {
        #region Singleton

        private static readonly Clients clientsBL = new Clients();

        public static Clients GetInstance()
        {
            return clientsBL;
        }

        #endregion

        #region CRUD Methods

        public bool Insert(IGD_Clients client)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    using (var item = new IGDDemoEntities())
                    {
                        item.IGD_Clients.Add(client);
                        
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

        public IGD_Clients SelectById(int clientId)
        {
            try
            {
                using (var item = new IGDDemoEntities())
                {
                    IGD_Clients client = item.IGD_Clients.FirstOrDefault(c => c.Id == clientId);
                    return client;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IGD_Clients SelectByPhone(string phone)
        {
            try
            {
                using (var item = new IGDDemoEntities())
                {
                    IGD_Clients client = item.IGD_Clients.FirstOrDefault(c => c.Phone == phone);
                    return client;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(IGD_Clients client)
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
                            item.Entry(clientData).State = System.Data.Entity.EntityState.Modified;
                            item.Entry(clientData).CurrentValues.SetValues(client);
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

        public List<IGD_Clients> SelectAll()
        {
            try
            {
                using (var item = new IGDDemoEntities())
                {
                    // Consulta filtrada por número de teléfono específico.
                    //var query = from c in item.IGD_Clients
                    //            where c.Phone == "xx"
                    //            select c;

                    // Consulta que devuelve solo una columna.
                    //var query = from c in item.IGD_Clients
                    //            select new { c.Phone };

                    // Retornamos una cantidad específica.
                    //return query.Take(2).ToList();

                    //var query = from c in item.IGD_Clients.Include("IGD_Deliveries")
                    //            select c;
                    // return query.ToList();
                    return item.IGD_Clients.ToList<IGD_Clients>();
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