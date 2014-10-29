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
        /// <summary>
        /// 根据ProductID得到此商品相关分类
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public DataTable GetRelevantCategoryByProductid(int productid)
        {
            string sqltxt = @"SELECT  cateid ,
        isshow ,
        displayorder ,
        name ,
        pricerange ,
        parentid ,
        layer ,
        haschild ,
        [path]
FROM    ShoppingStore.dbo.bsp_categories WITH ( NOLOCK )
WHERE   parentid = ( SELECT MainCategoryid
                     FROM   ShoppingStore.dbo.bsp_products WITH ( NOLOCK )
                     WHERE  pid = @id
                   )";
            SqlParameter[] paramter = { new SqlParameter("@id",SqlDbType.Int)};
            paramter[0].Value = productid;
            return helper.Query(sqltxt, paramter).Tables[0];
        }
        /// <summary>
        /// 根据ProductID得到此商品相关品牌
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public DataTable GetRelevantBrandsByProductid(int productid)
        {
            string sqltxt = @"SELECT TOP 15
        brandid ,
        isshow ,
        displayorder ,
        name ,
        logo ,
        BelongsCategoryID ,
        IsRecommend ,
        MainCategoryID
FROM    ShoppingStore.dbo.bsp_brands WITH ( NOLOCK )
WHERE   BelongsCategoryID = ( SELECT    Cateid
                              FROM      ShoppingStore.dbo.bsp_products WITH ( NOLOCK )
                              WHERE     pid = @id
                            )";
            SqlParameter[] pramter = {new SqlParameter("@id",SqlDbType.Int) };
            pramter[0].Value = productid;
            return helper.Query(sqltxt, pramter).Tables[0];
        }
    }
}
