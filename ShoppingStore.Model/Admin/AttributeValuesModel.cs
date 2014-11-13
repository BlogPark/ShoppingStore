using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShoppingStore.Model.Admin
{
    [DataContract]
    public class AttributeValuesModel
    {
        /// <summary>
        /// attrvalueid
        /// </summary>
        [DataMember]
        public int attrvalueid { get; set; }
        /// <summary>
        /// 属性ID
        /// </summary>
        [DataMember]
        public int attrid { get; set; }
        /// <summary>
        /// 属性编号
        /// </summary>
        [DataMember]
        public string attrnameCode { get; set; }
        /// <summary>
        /// 属性值名称
        /// </summary>
        [DataMember]
        public string attrvaluename { get; set; }
        /// <summary>
        /// 是否为输入属性值(0代表是输入属性值,1代表选择属性值)
        /// </summary>
        [DataMember]
        public int isinput { get; set; }
        /// <summary>
        /// 属性值编号
        /// </summary>
        [DataMember]
        public string attrvalueCode { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [DataMember]
        public int attrvaluedisplayorder { get; set; }
        /// <summary>
        /// 属性展示类型(0代表文字,1代表图片)
        /// </summary>
        [DataMember]
        public int attrshowtype { get; set; }
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
        /// 显示类型
        /// </summary>
        [DataMember]
        public string Showtypename { get; set; }
    }
}
