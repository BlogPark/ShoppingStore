using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShoppingStore.Model.Admin
{
    [DataContract]
    public class FriendlinksModel
    {
        /// <summary>
        /// ID 
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [DataMember]
        public string Title { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [DataMember]
        public string Logo { get; set; }
        /// <summary>
        /// URL
        /// </summary>
        [DataMember]
        public string Url { get; set; }
        /// <summary>
        /// 打开方式
        /// </summary>
        [DataMember]
        public string Target { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [DataMember]
        public string Displayorder { get; set; }
    }
}
