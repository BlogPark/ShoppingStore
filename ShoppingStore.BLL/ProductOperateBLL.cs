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
    }
}
