using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.Serialization;

namespace ShoppingStore.Model.Admin
{
    [DataContract]
    public class Categories
    {
        /// <summary>
        /// cateid
        /// </summary>
        [DataMember]
        public int cateid { get; set; }
        /// <summary>
        /// isshow
        /// </summary>
        [DataMember]
        public int isshow { get; set; }
        /// <summary>
        /// displayorder
        /// </summary>
        [DataMember]
        public int displayorder { get; set; }
        /// <summary>
        /// name
        /// </summary>
        [DataMember]
        public string name { get; set; }
        /// <summary>
        /// pricerange
        /// </summary>
        [DataMember]
        public string pricerange { get; set; }
        /// <summary>
        /// parentid
        /// </summary>
        [DataMember]
        public int parentid { get; set; }
        /// <summary>
        /// layer
        /// </summary>
        [DataMember]
        public int layer { get; set; }
        /// <summary>
        /// haschild
        /// </summary>
        [DataMember]
        public int haschild { get; set; }
        /// <summary>
        /// path
        /// </summary>
        [DataMember]
        public string path { get; set; }
    }
}
