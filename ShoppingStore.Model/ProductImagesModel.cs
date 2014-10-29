using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShoppingStore.Model
{
    [DataContract]
    public class ProductImagesModel
    {
        /// <summary>
        /// pimgid
        /// </summary>
        [DataMember]
        public int pimgid { get; set; }
        /// <summary>
        /// productid
        /// </summary>
        [DataMember]
        public int pid { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        [DataMember]
        public string showimg { get; set; }
        /// <summary>
        /// 是否主图
        /// </summary>
        [DataMember]
        public int ismain { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [DataMember]
        public int displayorder { get; set; }
        /// <summary>
        /// skuID
        /// </summary>
        [DataMember]
        public int SKU { get; set; }
    }
}
