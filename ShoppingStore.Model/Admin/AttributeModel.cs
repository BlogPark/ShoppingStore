using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShoppingStore.Model.Admin
{
    [DataContract]
    public class AttributeModel
    {
        /// <summary>
        /// attrid
        /// </summary>
        [DataMember]
        public int attrid { get; set; }
        /// <summary>
        /// 属性名称
        /// </summary>
        [DataMember]
        public string name { get; set; }
        /// <summary>
        /// 属性编号
        /// </summary>
        [DataMember]
        public string attributecode { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public int IsEnable { get; set; }
        /// <summary>
        /// 展示类型(0代表文字,1代表图片)
        /// </summary>
        [DataMember]
        public int showtype { get; set; }
        /// <summary>
        /// 是否为筛选属性
        /// </summary>
        [DataMember]
        public int isfilter { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [DataMember]
        public int displayorder { get; set; }
        /// <summary>
        /// 是否规格
        /// </summary>
        [DataMember]
        public int IsSpec { get; set; }
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
        /// <summary>
        /// 是否筛选属性
        /// </summary>
        [DataMember]
        public string Isfiltername { get; set; }
        /// <summary>
        /// 是否规格
        /// </summary>
        [DataMember]
        public string Isspecname { get; set; }
        /// <summary>
        /// 前端ID
        /// </summary>
        [DataMember]
        public string ShowIDname { get; set; }
        /// <summary>
        /// 是否多选
        /// </summary>
        [DataMember]
        public int IsMultiple { get; set; }
    }
}
