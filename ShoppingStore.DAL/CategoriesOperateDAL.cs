using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ShoppingStore.Model;

namespace ShoppingStore.DAL
{
    public  class CategoriesOperateDAL
    {
        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 得到所有的主类别
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllMainCategories()
        {
            string sqltxt = @"SELECT  cateid ,
        name
FROM    ShoppingStore.dbo.bsp_categories WITH ( NOLOCK )
WHERE   [path] = 1
        AND isshow = 1
ORDER BY displayorder ASC";
            return helper.Query(sqltxt).Tables[0];
        }
    }
}
