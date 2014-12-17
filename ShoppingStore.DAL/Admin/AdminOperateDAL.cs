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
    /// <summary>
    /// 商城后台基础数据操作类
    /// </summary>
    public class AdminOperateDAL
    {
        DAL.DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 得到左侧的菜单项
        /// </summary>
        /// <returns></returns>
        public DataTable GetOperateMenus()
        {
            string sqltxt = @"SELECT  adminaid ,
        title ,
        [action] AS url ,
        parentid 
FROM    ShoppingStore.dbo.bsp_adminactions WITH(NOLOCK)
ORDER BY displayorder DESC";
            return helper.Query(sqltxt).Tables[0];
        }
        /// <summary>
        /// 查询所有的友情链接
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllfriendlinks()
        {
            string sqltxt = @"SELECT id,name,title,logo,url,[target],displayorder
FROM ShoppingStore.dbo.bsp_friendlinks Order by displayorder desc";
            return helper.Query(sqltxt).Tables[0];
        }
        /// <summary>
        /// 新增友情链接
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insertfriendlink(FriendlinksModel model)
        {
            string sqltxt = @"INSERT INTO ShoppingStore.dbo.bsp_friendlinks
        ( name ,
          title ,
          logo ,
          url ,
          [target] ,
          displayorder
        )
VALUES  (@name,
         @title,
		 @logo,
		 @url,
		 @target,
		 @Displayorder
        )";
            SqlParameter[] paramter = {
                                          new SqlParameter("@name",SqlDbType.NVarChar),
                                          new SqlParameter("@title",SqlDbType.NVarChar),
                                          new SqlParameter("@logo",SqlDbType.NVarChar),
                                          new SqlParameter("@url",SqlDbType.NVarChar),
                                          new SqlParameter("@target",SqlDbType.NVarChar),
                                          new SqlParameter("@Displayorder",SqlDbType.NVarChar)
                                      };
            paramter[0].Value = model.Name;
            paramter[1].Value = model.Title;
            paramter[2].Value = model.Logo;
            paramter[3].Value = model.Url;
            paramter[4].Value = model.Target;
            paramter[5].Value = model.Displayorder;
            return helper.ExecuteSql(sqltxt, paramter);
        }
    }
}
