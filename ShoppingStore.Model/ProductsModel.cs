using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingStore.Model
{
    /// <summary>
    /// 产品（款）模型
    /// </summary>
    public class ProductsModel
    {
        /// <summary>
        /// ProductID
        /// </summary>
        public int pid { get; set; }
        /// <summary>
        /// 款号
        /// </summary>
        public string InternalCode { get; set; }
        /// <summary>
        /// 主类别ID
        /// </summary>
        public int MainCategoryid { get; set; }
        /// <summary>
        /// 分类别ID
        /// </summary>
        public int Cateid { get; set; }
        /// <summary>
        /// 品牌ID
        /// </summary>
        public int Brandid { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 商城价
        /// </summary>
        public decimal Shopprice { get; set; }
        /// <summary>
        /// 市场价
        /// </summary>
        public decimal Marketprice { get; set; }
        /// <summary>
        /// 成本价
        /// </summary>
        public decimal Costprice { get; set; }
        /// <summary>
        /// 商品状态
        /// </summary>
        public int ProductState { get; set; }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public int Isbest { get; set; }
        /// <summary>
        /// 是否热卖
        /// </summary>
        public int Ishot { get; set; }
        /// <summary>
        /// 是否新品
        /// </summary>
        public int Isnew { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Displayorder { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        public decimal Weight { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ShowimgPath { get; set; }
        /// <summary>
        /// 出售数量
        /// </summary>
        public int Salecount { get; set; }
        /// <summary>
        /// 访问数量
        /// </summary>
        public int Visitcount { get; set; }
        /// <summary>
        /// 评论数量
        /// </summary>
        public int Reviewcount { get; set; }
        /// <summary>
        /// 商品明细
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 简单描述
        /// </summary>
        public string SimpleDescription { get; set; }
    }
}
