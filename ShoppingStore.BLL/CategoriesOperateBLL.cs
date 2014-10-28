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
    }
}
