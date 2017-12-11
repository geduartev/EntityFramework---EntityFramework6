//-----------------------------------------------------------------------
// <copyright file="ClientInfo.cs" company="Ingeniería GD®">
//     Copyright (c) Ingeniería GD® 2017. All rights reserved.
// </copyright>
// <author>Gabriel Eduardo Duarte Vega</author>
// <date>12/9/2017 10:13:41 AM</date>
//-----------------------------------------------------------------------
namespace IngenieriaGD.IGDDemo.Library.DAL.Entities
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Class.
    /// </summary>
    [DataContract]
    public class ClientInfo
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public int LastReading { get; set; }
        [DataMember]
        public bool Readed { get; set; }
    }
}