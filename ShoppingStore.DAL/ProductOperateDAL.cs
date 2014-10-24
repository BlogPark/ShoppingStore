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
        public DataTable GetProShowIndexPage()
        {
            string sqltxt = @"SELECT  pid ,
        showimg ,
        name ,
        shopprice
FROM    ShoppingStore.dbo.bsp_products WITH ( NOLOCK )
WHERE [state]=0 
ORDER BY addtime DESC";
            //SqlParameter[] paramter = { };
            return helper.Query(sqltxt).Tables[0];
        }
    }
}
