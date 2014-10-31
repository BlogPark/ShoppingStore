﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


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
        action ,
        parentid 
FROM    ShoppingStore.dbo.bsp_adminactions WITH(NOLOCK)
ORDER BY displayorder DESC";
            return helper.Query(sqltxt).Tables[0];
        }
    }
}
