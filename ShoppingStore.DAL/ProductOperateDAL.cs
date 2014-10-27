using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ShoppingStore.Model;

namespace ShoppingStore.DAL
{
    /// <summary>
    /// 产品操作类
    /// </summary>
    public class ProductOperateDAL
    {
        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 得到首页显示的商品信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetProShowIndexPage(int categoryid)
        {
            string sqltxt = @"SELECT  pid ,
        showimgPath ,
        ProductName ,
        shopprice
FROM    ShoppingStore.dbo.bsp_products WITH ( NOLOCK )
WHERE productstate=0 and MainCategoryid=@id 
ORDER BY CreateTime DESC";
            SqlParameter[] paramter = { new SqlParameter("@id",SqlDbType.Int)};
            paramter[0].Value = categoryid;
            return helper.Query(sqltxt,paramter).Tables[0];
        }
    }
}
