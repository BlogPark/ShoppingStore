using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShoppingStore.Model.Admin
{
    /// <summary>
    /// 类别和属性的对应关系模型
    /// </summary>
    [DataContract]
    public class CategoryAttributeModel
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        [DataMember]
        public int CategoryID { get; set; }
        /// <summary>
        /// 属性ID
        /// </summary>
        [DataMember]
        public int AttributeID { get; set; }
        /// <summary>
        /// 属性列表
        /// </summary>
        [DataMember]
        public string AttributeIDlist { get; set; }
        /// <summary>
        /// 属性名称
        /// </summary>
        [DataMember]
        public string AttributeName { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public int IsEnable { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public string Enablename { get; set; }
        /// <summary>
        /// 是否规格
        /// </summary>
        [DataMember]
        public int IsSpec { get; set; }
        /// <summary>
        /// 是否规格
        /// </summary>
        [DataMember]
        public string SpecName { get; set; }
    }
}
