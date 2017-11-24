//-----------------------------------------------------------------------
// <copyright file="ClientsBL.cs" company="Ingeniería GD®">
//     Copyright (c) Ingeniería GD® 2017. All rights reserved.
// </copyright>
// <author>Gabriel Eduardo Duarte Vega</author>
// <date>11/23/2017 9:55:41 AM</date>
//-----------------------------------------------------------------------
namespace DemoEF.Backend.Business.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Transactions;
    using DemoEF.Backend.Business.Entities;

    /// <summary>
    /// Class.
    /// </summary>
    public class ClientsBL
    {
        #region Singleton

        private static readonly ClientsBL clientsBL = new ClientsBL();
        //private static ClientsBL clientsBL;

        public static ClientsBL GetInstance()
        {
            //if (clientsBL == null)
            //{
            //    clientsBL = new ClientsBL();
            //}

            return clientsBL;
        }

        #endregion

        #region CRUD Methods

        public void Insert(EPM_Clients client)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    // Debemos crear una nueva instancia del contexto.
                    using (var item = new ZuluSoftwareEntities())
                    {
                        item.EPM_Clients.Add(client);
                        // No es necesario utilizar transaccionalidad por que no estamos manejando varias tablas.
                        item.SaveChanges();
                    }

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public void Update(EPM_Clients client)
        {
            using (var item = new ZuluSoftwareEntities())
            {
                // Un tercer parámetro del FirstOrDefault recibe un predicado que es una función que me devuelve un valor.
                var clientData = item.EPM_Clients.FirstOrDefault(c => c.Id == client.Id);

                if (clientData != null)
                {
                    item.Entry(clientData).State = System.Data.Entity.EntityState.Modified;
                    item.Entry(clientData).CurrentValues.SetValues(client);
                }

                if (clientData == null)
                {
                    item.EPM_Clients.Add(clientData);
                }

                item.SaveChanges();
            }
        }

        public void Delete(int idClient)
        {
            using (var item = new ZuluSoftwareEntities())
            {
                var clientData = item.EPM_Clients.FirstOrDefault(c => c.Id == idClient);

                if (clientData != null)
                {
                    item.Entry(clientData).State = System.Data.Entity.EntityState.Deleted;
                    item.SaveChanges();
                }
            }
        }

        public List<EPM_Clients> SelectAll()
        {
            using (var item = new ZuluSoftwareEntities())
            {
                // Consulta filtrada por número de teléfono específico.
                //var query = from c in item.EPM_Clients
                //            where c.Phone == "xx"
                //            select c;

                // Consulta que devuelve solo una columna.
                //var query = from c in item.EPM_Clients
                //            select new { c.Phone };

                // Retornamos una cantidad específica.
                //return query.Take(2).ToList();

                var query = from c in item.EPM_Clients.Include("EPM_Deliveries")
                            select c;

                return query.ToList();
            }
        }

        #endregion
    }
}