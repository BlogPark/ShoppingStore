using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShoppingStore.Model.Admin
{
    /// <summary>
    /// 商品Model
    /// </summary>
    [DataContract]
    public class ProductModel
    {
        /// <summary>
        /// pid
        /// </summary>
        [DataMember]
        public int pid { get; set; }
        /// <summary>
        /// 商品款号
        /// </summary>
        [DataMember]
        public string InternalCode { get; set; }
        /// <summary>
        /// 一级分类ID
        /// </summary>
        [DataMember]
        public int MainCategoryid { get; set; }
        /// <summary>
        /// 末级分类ID
        /// </summary>
        [DataMember]
        public int Cateid { get; set; }
        /// <summary>
        /// 品牌ID
        /// </summary>
        [DataMember]
        public int Brandid { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }
        /// <summary>
        /// 商城价
        /// </summary>
        [DataMember]
        public decimal Shopprice { get; set; }
        /// <summary>
        /// 市场价
        /// </summary>
        [DataMember]
        public decimal Marketprice { get; set; }
        /// <summary>
        /// 成本价
        /// </summary>
        [DataMember]
        public decimal Costprice { get; set; }
        /// <summary>
        /// 状态(0代表上架，1代表下架，2代表回收站，3代表隐藏品牌，4代表隐藏分类)
        /// </summary>
        [DataMember]
        public int ProductState { get; set; }
        /// <summary>
        /// 是否推荐
        /// </summary>
        [DataMember]
        public int Isbest { get; set; }
        /// <summary>
        /// 是否热卖
        /// </summary>
        [DataMember]
        public int Ishot { get; set; }
        /// <summary>
        /// 是否新品
        /// </summary>
        [DataMember]
        public int Isnew { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [DataMember]
        public int Displayorder { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        [DataMember]
        public decimal Weight { get; set; }
        /// <summary>
        /// 首页图片路径
        /// </summary>
        [DataMember]
        public string ShowimgPath { get; set; }
        /// <summary>
        /// 售卖数量
        /// </summary>
        [DataMember]
        public int Salecount { get; set; }
        /// <summary>
        /// 访问数量
        /// </summary>
        [DataMember]
        public int Visitcount { get; set; }
        /// <summary>
        /// 评论数量
        /// </summary>
        [DataMember]
        public int Reviewcount { get; set; }
        /// <summary>
        /// 一星
        /// </summary>
        [DataMember]
        public int Star1 { get; set; }
        /// <summary>
        /// 两星
        /// </summary>
        [DataMember]
        public int Star2 { get; set; }
        /// <summary>
        /// 三星
        /// </summary>
        [DataMember]
        public int Star3 { get; set; }
        /// <summary>
        /// 四星
        /// </summary>
        [DataMember]
        public int Star4 { get; set; }
        /// <summary>
        /// 五星
        /// </summary>
        [DataMember]
        public int Star5 { get; set; }
        /// <summary>
        /// 商品详情
        /// </summary>
        [DataMember]
        public string Description { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 简单描述
        /// </summary>
        [DataMember]
        public string SimpleDescription { get; set; }

    }
}
