//-----------------------------------------------------------------------
// <copyright file="DeliveryInfo.cs" company="Ingeniería GD®">
//     Copyright (c) Ingeniería GD® 2017. All rights reserved.
// </copyright>
// <author>Gabriel Eduardo Duarte Vega</author>
// <date>12/9/2017 10:14:40 AM</date>
//-----------------------------------------------------------------------
namespace IngenieriaGD.IGDDemo.Library.DAL.Entities
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Class.
    /// </summary>
    [DataContract]
    public class DeliveryInfo
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string DeliveryNumber { get; set; }
        [DataMember]
        public decimal Mount { get; set; }
    }
}