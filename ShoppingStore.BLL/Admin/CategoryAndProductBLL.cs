using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingStore.Model.Admin;
using ShoppingStore.DAL.Admin;
using System.Data;
using System.Data.SqlClient;

namespace ShoppingStore.BLL.Admin
{
    public  class CategoryAndProductBLL
    {
        CategoryAndProductDAL dal = new CategoryAndProductDAL();
        /// <summary>
        /// 添加类别信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddCategoryInfo(Categories model)
        {
            return dal.AddCategoryInfo(model);
        }
        public List<Categories> SelectAllCategory()
        {
            DataTable dt= dal.SelectAllCategory();
            List<Categories> categorys = new List<Categories>();
            foreach (DataRow item in dt.Rows)
            {
                Categories model = new Categories();
                model.cateid = int.Parse(item["cateid"].ToString());
                model.name = item["name"].ToString();
                model.parentid = int.Parse(item["parentid"].ToString());
                categorys.Add(model);
            }
            return categorys;
        }

        /// <summary>
        /// 修改单个类别信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateCategoryItem(Categories model)
        {
            return dal.UpdateCategoryItem(model);
        }
        /// <summary>
        /// 查询所有的品牌
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetAllBrands(BrandsInfoModel model)
        {
            return dal.GetAllBrands(model);
        }
    }
}
