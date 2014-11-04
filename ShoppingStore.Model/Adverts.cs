using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShoppingStore.Model
{
    [DataContract]
    public class Adverts 
    {
        /// <summary>
        /// adid
        /// </summary>
        [DataMember]
        public int adid { get; set; }
        /// <summary>
        /// clickcount
        /// </summary>
        [DataMember]
        public int clickcount { get; set; }
        /// <summary>
        /// adposid
        /// </summary>
        [DataMember]
        public int adposid { get; set; }
        /// <summary>
        /// state
        /// </summary>
        [DataMember]
        public int state { get; set; }
        /// <summary>
        /// starttime
        /// </summary>
        [DataMember]
        public DateTime starttime { get; set; }
        /// <summary>
        /// endtime
        /// </summary>
        [DataMember]
        public DateTime endtime { get; set; }
        /// <summary>
        /// displayorder
        /// </summary>
        [DataMember]
        public int displayorder { get; set; }
        /// <summary>
        /// type
        /// </summary>
        [DataMember]
        public int type { get; set; }
        /// <summary>
        /// title
        /// </summary>
        [DataMember]
        public string title { get; set; }
        /// <summary>
        /// url
        /// </summary>
        [DataMember]
        public string url { get; set; }
        /// <summary>
        /// body
        /// </summary>
        [DataMember]
        public string body { get; set; }

    }
}
