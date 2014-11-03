using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ShoppingStore.Model.Admin;

namespace ShoppingStore.DAL.Admin
{
    public class CategoryAndProductDAL
    {
        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 添加类别
        /// </summary>
        /// <param name="model">类别Model</param>
        /// <returns></returns>
        public int AddCategoryInfo(Categories model)
        {
            string sqltxt = @"INSERT INTO  ShoppingStore.dbo.bsp_categories
          ( isshow ,
            displayorder ,
            name ,
            pricerange ,
            parentid ,
            layer ,
            haschild ,
            path
          )
  VALUES  ( @isshow ,
            @displayorder ,
            @name , 
            @pricerange ,
            @parentid,
            @layer,
            @haschild, 
            @path 
          )";
            SqlParameter[] paramter = {
 new SqlParameter("@isshow",SqlDbType.Int),
 new SqlParameter("@displayorder",SqlDbType.Int),
 new SqlParameter("@name",SqlDbType.Int),
 new SqlParameter("@pricerange",SqlDbType.Int),
 new SqlParameter("@parentid",SqlDbType.Int),
 new SqlParameter("@layer",SqlDbType.Int),
 new SqlParameter("@haschild",SqlDbType.Int),
 new SqlParameter("@path",SqlDbType.Int)
                                      };
            paramter[0].Value = model.isshow;
            paramter[1].Value = model.displayorder;
            paramter[2].Value = model.name;
            paramter[3].Value = model.pricerange;
            paramter[4].Value = model.parentid;
            paramter[5].Value = model.layer;
            paramter[6].Value = model.haschild;
            paramter[7].Value = model.path;
            return helper.ExecuteSql(sqltxt, paramter);
        }
        /// <summary>
        /// 得到所有的类别
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllCategory()
        {
            string sqltxt = @"SELECT  cateid ,
        isshow ,
        displayorder ,
        name ,
        pricerange ,
        parentid ,
        layer ,
        haschild ,
        path
FROM    ShoppingStore.dbo.bsp_categories WITH ( NOLOCK )
WHERE   isshow = 1";
            return helper.Query(sqltxt).Tables[0];
        }
    }
}
