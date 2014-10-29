using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ShoppingStore.Model
{
    public class ProductDetailsPageModel
    {
        /// <summary>
        /// 商品信息
        /// </summary>
        public DataTable product;
        /// <summary>
        /// 分类信息
        /// </summary>
        public List<CategoriesModel> category;
        /// <summary>
        /// 品牌信息
        /// </summary>
        public List<BrandsModel> brands;
        /// <summary>
        /// 推荐商品信息
        /// </summary>
        public List<ProductsModel> BestProducts;
        /// <summary>
        /// 主图列表
        /// </summary>
        public List<ProductImagesModel> MainImages;
    }
}
