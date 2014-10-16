using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ShoppingStore.DAL
{
    /// <summary>
    /// 读取首页信息的基础数据数据库查询类
    /// </summary>
    public  class IndexCommonDataDAL
    {
        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 查找主类别
        /// </summary>
        /// <returns></returns>
        public DataTable GetFatherMenus()
        {
            string sqltxt = @"SELECT  cateid ,
        name
FROM    [ShoppingStore].[dbo].bsp_categories WITH ( NOLOCK )
WHERE   parentid = 0
        AND isshow = 1
        AND layer = 1
ORDER BY displayorder ASC";
            return helper.Query(sqltxt).Tables[0];
        }
        /// <summary>
        /// 按照主类别查找子分类
        /// </summary>
        /// <param name="fatherid"></param>
        /// <returns></returns>
        public DataTable GetChildMenus(int fatherid)
        {
            string sqltxt = @"SELECT  cateid ,
        name
FROM    [ShoppingStore].[dbo].bsp_categories WITH ( NOLOCK )
WHERE   isshow = 1
        AND parentid = @prentid
        AND layer <> 1
ORDER BY displayorder ASC";
            SqlParameter[] paramter = {
                                          new SqlParameter("@prentid",SqlDbType.Int)
                                      };
            paramter[0].Value = fatherid;
            return helper.Query(sqltxt,paramter).Tables[0];
        }
    }
}
