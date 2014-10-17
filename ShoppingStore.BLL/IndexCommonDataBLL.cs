using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingStore.DAL;
using System.Data;
using System.Data.SqlClient;

namespace ShoppingStore.BLL
{
    /// <summary>
    /// 读取首页基础信息的业务逻辑类
    /// </summary>
    public class IndexCommonDataBLL
    {
        IndexCommonDataDAL dal = new IndexCommonDataDAL();
        /// <summary>
        /// 查询所有大类别信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetFatherMenus()
        {
            DataSet ds = new DataSet("dataset");
            ds.Tables.Add(dal.GetFatherMenus().Copy()) ;
            ds.Tables.Add(dal.GetChildMenus().Copy());
            ds.Tables.Add(dal.GetRecommandBrands().Copy());
            return ds;
        }
         /// <summary>
        /// 按照主类别查找子分类
        /// </summary>
        /// <param name="fatherid"></param>
        /// <returns></returns>
        public DataTable GetChildMenus(int fatherid)
        {
            return dal.GetChildMenus();
        }
        /// <summary>
        /// 得到前端的导航
        /// </summary>
        /// <returns></returns>
        public DataTable GetPageNavlist()
        {
            return dal.GetPageNavlist();
        }
    }
}
