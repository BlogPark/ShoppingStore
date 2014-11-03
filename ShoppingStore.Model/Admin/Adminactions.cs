using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShoppingStore.Model.Admin
{
    [DataContract]
    public class Adminactions
    {
        /// <summary>
        /// adminaid
        /// </summary>
        [DataMember]
        public int adminaid { get; set; }
        /// <summary>
        /// title
        /// </summary>
        [DataMember]
        public string title { get; set; }
        /// <summary>
        /// action
        /// </summary>
        [DataMember]
        public string url { get; set; }
        /// <summary>
        /// parentid
        /// </summary>
        [DataMember]
        public int parentid { get; set; }
        /// <summary>
        /// displayorder
        /// </summary>
        [DataMember]
        public int displayorder { get; set; }
    }
}
