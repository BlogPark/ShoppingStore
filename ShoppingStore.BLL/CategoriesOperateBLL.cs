using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ShoppingStore.Model;
using ShoppingStore.DAL;

namespace ShoppingStore.BLL
{
    public  class CategoriesOperateBLL
    {
        CategoriesOperateDAL dal = new CategoriesOperateDAL();
        ProductOperateDAL productdal = new ProductOperateDAL();
        /// <summary>
        /// 得到所有的主类类别
        /// </summary>
        /// <returns></returns>
        public List<CategoriesModel> GetAllMainCategories()
        {
            List<CategoriesModel> categories = new List<CategoriesModel>();
            DataTable dt = dal.GetAllMainCategories();
            foreach (DataRow item in dt.Rows)
            {
                CategoriesModel model = new CategoriesModel();
                model.cateid=int.Parse(item["cateid"].ToString());
                model.name = item["name"].ToString();
                categories.Add(model);
            }
            return categories;
        }
       
        /// <summary>
        /// 为分类页面准备数据
        /// </summary>
        /// <param name="category">类别ID</param>
        /// <param name="type">是否是最末分类 0 大类 1最末分类</param>
        /// <returns></returns>
        public CategoriesPageModel GetAllCategory(int category, int type)
        {
            CategoriesPageModel categorypagemodel = new CategoriesPageModel();
            if (type == 0)
            {
                DataTable dt = dal.GetChildCategoryList(category);//得到分类消息
                List<CategoriesModel> categorylist = new List<CategoriesModel>();
                foreach (DataRow item in dt.Rows)
                {
                    CategoriesModel model = new CategoriesModel();
                    model.cateid = int.Parse(item["cateid"].ToString());
                    model.name = item["name"].ToString();
                    model.path = item["path"].ToString();
                    model.parentid = int.Parse(item["parentid"].ToString());
                    categorylist.Add(model);
                }
                categorypagemodel.categories = categorylist;
                categorypagemodel.brands = null;
            }
            else {
                DataTable brandt = dal.GetBrandsByBlogcategory(category);//品牌信息
                List<BrandsModel> brandslist = new List<BrandsModel>();
                foreach (DataRow item in brandt.Rows)
                {
                    BrandsModel model = new BrandsModel();
                    model.brandid = int.Parse(item["brandid"].ToString());
                    model.name = item["name"].ToString();
                    model.BelongsCategoryID = int.Parse(item["BelongsCategoryID"].ToString());
                    brandslist.Add(model);
                }
                categorypagemodel.brands = brandslist;
                categorypagemodel.categories = null; 
            }
            categorypagemodel.Products = productdal.GetProductsBycategory(category, type,0);//商品信息
            DataTable prodt= productdal.GetProductsBycategory(category, type,1);//热卖商品信息
            List<ProductsModel> promodel = new List<ProductsModel>();
            foreach (DataRow item in prodt.Rows)
            {
                ProductsModel model = new ProductsModel();
                model.ShowimgPath = item["ShowimgPath"].ToString();
                model.Shopprice = decimal.Parse(item["Shopprice"].ToString());
                model.pid = int.Parse(item["pid"].ToString());
                model.ProductName = item["ProductName"].ToString();
                promodel.Add(model);
            }
            categorypagemodel.HotProducts = promodel;
            return categorypagemodel;
        }

    }
}
