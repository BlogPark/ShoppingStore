using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShoppingStore.Model.Admin
{
    /// <summary>
    /// 商品的扩展属性
    /// </summary>
    [DataContract]
    public class ProductVOModel : ProductModel
    {
        /// <summary>
        /// SKU列表
        /// </summary>
        [DataMember]
        public List<SKUModel> SKUS { get; set; }
        /// <summary>
        /// 商品属性列表
        /// </summary>
        [DataMember]
        public List<AttributeModel> Attributrte { get; set; }
    }
}
