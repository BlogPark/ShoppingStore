using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ShoppingStore.DAL;
using ShoppingStore.Model;

namespace ShoppingStore.BLL
{
    /// <summary>
    /// 产品操作逻辑类
    /// </summary>
    public class ProductOperateBLL
    {
        ProductOperateDAL dal=new ProductOperateDAL();
        CategoriesOperateDAL catedal = new CategoriesOperateDAL();
        /// <summary>
        /// 得到首页显示的商品信息
        /// </summary>
        /// <returns></returns>
        public List<ProductsModel> GetProShowIndexPage(int categoryid)
        {
            DataTable dt= dal.GetProShowIndexPage(categoryid);
            List<ProductsModel> products = new List<ProductsModel>();
            foreach (DataRow item in dt.Rows)
            {
                ProductsModel model = new ProductsModel();
                model.ShowimgPath = item["showimgPath"].ToString();
                model.pid = int.Parse(item["pid"].ToString());
                model.Shopprice = decimal.Parse(item["shopprice"].ToString());
                model.ProductName = item["ProductName"].ToString();
                products.Add(model);
            }
            return products;
        }
        /// <summary>
        /// 商品详情页产品信息
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public ProductDetailsPageModel GetSingleProductDetails(int productid)
        {
            ProductDetailsPageModel productmodel = new ProductDetailsPageModel();
            productmodel.product = dal.GetSingleProductInfo(productid);//获取商品信息
            DataTable imgdt = dal.GetProductMainimageByPid(productid);//获取主图
            List<ProductImagesModel> proimglist = new List<ProductImagesModel>();
            foreach (DataRow item in imgdt.Rows)
            {
                ProductImagesModel model = new ProductImagesModel();
                model.showimg = item["showimg"].ToString();
                model.pimgid = int.Parse(item["pimgid"].ToString());
                proimglist.Add(model);
            }
            productmodel.MainImages = proimglist;
            DataTable catedt = catedal.GetRelevantCategoryByProductid(productid);//得到相关分类
            List<CategoriesModel> categorylist = new List<CategoriesModel>();
            foreach (DataRow item in catedt.Rows)
            {
                CategoriesModel model = new CategoriesModel();
                model.cateid=int.Parse(item["cateid"].ToString());
                model.name = item["name"].ToString();
                categorylist.Add(model);
            }
            productmodel.category = categorylist;
            DataTable brandt = catedal.GetRelevantBrandsByProductid(productid);//得到相关品牌
            List<BrandsModel> brandslist = new List<BrandsModel>();
            foreach (DataRow item in brandt.Rows)
            {
                BrandsModel model = new BrandsModel();
                model.brandid = int.Parse(item["brandid"].ToString());
                model.name = item["name"].ToString();
                brandslist.Add(model);
            }
            productmodel.brands = brandslist;
            DataTable prodt = dal.GetRelevantHotMaleProduct(productid);//得到热卖产品列表
            List<ProductsModel> productlist = new List<ProductsModel>();
            foreach (DataRow item in prodt.Rows)
            {
                ProductsModel model = new ProductsModel();
                model.ShowimgPath = item["ShowimgPath"].ToString();
                model.pid = int.Parse(item["pid"].ToString());
                model.ProductName = item["ProductName"].ToString();
                productlist.Add(model);
            }
            productmodel.BestProducts = productlist;
            return productmodel;
        }
    }
}
