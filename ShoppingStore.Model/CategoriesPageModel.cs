using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ShoppingStore.Model
{
    /// <summary>
    /// 商品分类列表页面的Model
    /// </summary>
    public class CategoriesPageModel
    { 
        /// <summary>
        /// 分类信息
        /// </summary>
        public List<CategoriesModel> categories;
        /// <summary>
        /// 品牌信息
        /// </summary>
        public List<BrandsModel> brands;
        /// <summary>
        /// 热门品牌信息
        /// </summary>
        public List<BrandsModel> hotbrands;
        /// <summary>
        /// 商品信息
        /// </summary>
        public DataTable Products;
        /// <summary>
        /// 轮播图信息
        /// </summary>
        public List<Adverts> CarouselAdvertising;
        /// <summary>
        /// 热卖商品信息
        /// </summary>
        public List<ProductsModel> HotProducts;
    }
}
