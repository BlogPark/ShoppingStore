using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShoppingStore.Model.Admin
{
    /// <summary>
    /// SKU 类
    /// </summary>
    [DataContract]
    public  class SKUModel
    {
        /// <summary>
        /// SKU
        /// </summary>
        [DataMember]
        public long SKU { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        [DataMember]
        public int ProductID { get; set; }
        /// <summary>
        /// 属性值1
        /// </summary>
        [DataMember]
        public int AtributeValueid1 { get; set; }
        /// <summary>
        /// 属性值2
        /// </summary>
        [DataMember]
        public int AtributeValueid2 { get; set; }
        /// <summary>
        /// 属性值3
        /// </summary>
        [DataMember]
        public int AtributeValueid3 { get; set; }
        /// <summary>
        /// 属性1
        /// </summary>
        [DataMember]
        public int Atributeid1 { get; set; }
        /// <summary>
        /// 属性2
        /// </summary>
        [DataMember]
        public int Atributeid2 { get; set; }
        /// <summary>
        /// 属性3
        /// </summary>
        [DataMember]
        public int Atributeid3 { get; set; }
        /// <summary>
        /// 条码
        /// </summary>
        [DataMember]
        public string BarCode { get; set; }
        /// <summary>
        /// 商城价
        /// </summary>
        [DataMember]
        public decimal ShopPrice { get; set; }

    }
}
