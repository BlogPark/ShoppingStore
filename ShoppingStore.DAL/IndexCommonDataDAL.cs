﻿using System;
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
        isshow ,
        displayorder ,
        name ,
        pricerange ,
        parentid ,
        layer ,
        haschild ,
        path
FROM    ShoppingStore.dbo.bsp_categories WITH(NOLOCK)
WHERE isshow=1 AND parentid=0
ORDER BY displayorder";
            return helper.Query(sqltxt).Tables[0];
        }
        /// <summary>
        /// 查找主类别
        /// </summary>
        /// <returns></returns>
        public DataTable GetChildsubMenus()
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
FROM    ShoppingStore.dbo.bsp_categories WITH(NOLOCK)
WHERE isshow=1 AND parentid<>0
ORDER BY displayorder";
            DataTable dt= helper.Query(sqltxt).Tables[0];
            dt.TableName = "childmenus";
            return dt;
        }
        /// <summary>
        /// 按照主类别查找子类别
        /// </summary>
        /// <param name="fatherid"></param>
        /// <returns></returns>
        public DataTable GetChildMenus()
        {
            string sqltxt = @"SELECT  id ,
        SubCategoryName ,
        Isshow ,
        ParentID ,
        MainCategory ,
        DisplayOrder ,
        [Path]
FROM    ShoppingStore.dbo.bsp_subcategories WITH ( NOLOCK )
WHERE   isshow = 1
ORDER BY DisplayOrder";
            DataTable dt= helper.Query(sqltxt).Tables[0];
            dt.TableName = "subcategories";
            return dt;
        }
        /// <summary>
        /// 得到推荐的品牌列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetRecommandBrands()
        {
            string sqltxt = @"SELECT  [brandid] ,
        [isshow] ,
        [displayorder] ,
        [name] ,
        [logo] ,
        [BelongsCategoryID] ,
        [IsRecommend] ,
        [MainCategoryID]
FROM    [ShoppingStore].[dbo].[bsp_brands] WITH ( NOLOCK )
WHERE   IsRecommend = 1";
            DataTable dt = helper.Query(sqltxt).Tables[0];
            dt.TableName = "brands";
            return dt;
        }
        /// <summary>
        /// 得到前端的导航
        /// </summary>
        /// <returns></returns>
        public DataTable GetPageNavlist()
        {
            string sqltxt = @"SELECT  id ,
        pid ,
        layer ,
        name ,
        title ,
        url ,
        [target] ,
        displayorder
FROM    ShoppingStore.dbo.bsp_navs WITH ( NOLOCK )
WHERE   isshow = 1
ORDER BY displayorder ASC";
            return helper.Query(sqltxt).Tables[0];
        }
        /// <summary>
        /// 得到banner的列表
        /// </summary>
        /// <returns></returns>
        public DataTable Getbannerlist()
        {
            string sqltxt = @"SELECT  id ,
        starttime ,
        endtime ,
        isshow ,
        title ,
        img ,
        url ,
        displayorder
FROM    ShoppingStore.dbo.bsp_banners WITH ( NOLOCK )
WHERE   starttime < GETDATE()
        AND endtime > GETDATE()
ORDER BY displayorder ASC";
            return helper.Query(sqltxt).Tables[0];
        }

    }
}
