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
 new SqlParameter("@name",SqlDbType.NVarChar),
 new SqlParameter("@pricerange",SqlDbType.NVarChar),
 new SqlParameter("@parentid",SqlDbType.Int),
 new SqlParameter("@layer",SqlDbType.Int),
 new SqlParameter("@haschild",SqlDbType.Int),
 new SqlParameter("@path",SqlDbType.NVarChar)
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
        /// <summary>
        /// 修改单个类别信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateCategoryItem(Categories model)
        {
            string sqltxt = @"UPDATE  ShoppingStore.dbo.bsp_categories WITH ( ROWLOCK )
SET     isshow = @isshow ,
        name = @name ,
        parentid = @pid
WHERE   cateid = @id";
            SqlParameter[] paramter = {
                                          new SqlParameter("@isshow",SqlDbType.Int),
                                          new SqlParameter("@name",SqlDbType.NVarChar),
                                          new SqlParameter("@pid",SqlDbType.Int),
                                          new SqlParameter("@id",SqlDbType.Int)
                                      };
            paramter[0].Value = model.isshow;
            paramter[1].Value = model.name;
            paramter[2].Value = model.parentid;
            paramter[3].Value = model.cateid;
            return helper.ExecuteSql(sqltxt,paramter);
        }
        /// <summary>
        /// 查询所有的品牌
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetAllBrands(BrandsInfoModel model)
        {
            string sqltxt = @"SELECT  IDENTITY( INT,1,1 ) AS rowid ,
        brandid * 1 AS brandid
INTO    #t
FROM    ShoppingStore.dbo.bsp_brands WITH ( NOLOCK )
DECLARE @totalco INT = @@ROWCOUNT

SELECT  @totalco AS tco ,
        A.brandid ,
        CASE A.isshow
          WHEN 1 THEN '启用'
          ELSE '未启用'
        END AS isused ,
        A.displayorder ,
        A.name AS brandname ,
        ISNULL(A.logo, '(无)') AS logopath ,
        A.BelongsCategoryID ,
        CASE  A.IsRecommend WHEN 1 THEN '是' ELSE '否' END  AS IsRecommend,
        A.MainCategoryID ,
        B.name AS blongcatename ,
        C.name AS maincatename
FROM    #t D
        INNER JOIN ShoppingStore.dbo.bsp_brands A WITH ( NOLOCK ) ON D.brandid = A.brandid
                                                              AND D.rowid > ( @pageindex
                                                              - 1 )
                                                              * @pagesize
                                                              AND D.rowid <= ( @pageindex
                                                              * @pagesize )
        INNER JOIN ShoppingStore.dbo.bsp_categories B WITH ( NOLOCK ) ON A.BelongsCategoryID = B.cateid
        INNER JOIN ShoppingStore.dbo.bsp_Categories C WITH ( NOLOCK ) ON A.MainCategoryID = C.cateid";
            SqlParameter[] paramter = {
                                          new SqlParameter("@pageindex",SqlDbType.Int),
                                          new SqlParameter("@pagesize",SqlDbType.Int)
                                      };
            paramter[0].Value = model.PageIndex;
            paramter[1].Value = model.PageSize;
            return helper.Query(sqltxt, paramter).Tables[0];
        }
        /// <summary>
        /// 添加品牌信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Addbranditem(BrandsInfoModel model)
        {
            string sqltxt = @"INSERT  INTO ShoppingStore.dbo.bsp_brands
        ( isshow ,
          displayorder ,
          name ,
          logo ,
          BelongsCategoryID ,
          IsRecommend ,
          MainCategoryID
        )
        SELECT  @isshow ,
                0 ,
                @name ,
                @logo ,
                @belongscategoryid ,
                @isrecommend ,
                parentid
        FROM    ShoppingStore.dbo.bsp_categories WITH ( NOLOCK )
        WHERE   cateid = @belongscategoryid";
            SqlParameter[] paramter = {
                                          new SqlParameter("@isshow",SqlDbType.Int),
                                          new SqlParameter("@name",SqlDbType.NVarChar),
                                          new SqlParameter("@logo",SqlDbType.NVarChar),
                                          new SqlParameter("@belongscategoryid",SqlDbType.Int),
                                          new SqlParameter("@isrecommend",SqlDbType.Int)
                                      };
            paramter[0].Value = model.isshow;
            paramter[1].Value = model.name;
            paramter[2].Value = model.logo;
            paramter[3].Value = model.BelongsCategoryID;
            paramter[4].Value = model.IsRecommend;
            return helper.ExecuteSql(sqltxt,paramter);
        }
        /// <summary>
        /// 修改品牌信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateBrandsitem(BrandsInfoModel model)
        {
            string sqltxt = @"UPDATE  A WITH ( ROWLOCK )
SET     A.NAME = @name ,
        A.BelongsCategoryID = @blongcateid ,
        A.isshow = @isshow ,
        A.IsRecommend = @IsRecommend ,
        A.MainCategoryID = B.parentid
FROM    ShoppingStore.dbo.bsp_brands A
        LEFT JOIN ShoppingStore.dbo.bsp_categories B WITH ( NOLOCK ) ON A.BelongsCategoryID = B.cateid
                                                              AND B.cateid = @blongcateid
WHERE   A.brandid = @id ";
            SqlParameter[] paramter = {
                                          new SqlParameter("@name",SqlDbType.NVarChar),
                                          new SqlParameter("@blongcateid",SqlDbType.Int),
                                          new SqlParameter("@isshow",SqlDbType.Int),
                                          new SqlParameter("@IsRecommend",SqlDbType.Int),
                                          new SqlParameter("@id",SqlDbType.Int)
                                      };
            paramter[0].Value = model.name;
            paramter[1].Value = model.BelongsCategoryID;
            paramter[2].Value = model.isshow;
            paramter[3].Value = model.IsRecommend;
            paramter[4].Value = model.brandid;
            return helper.ExecuteSql(sqltxt, paramter);
        }
        /// <summary>
        /// 删除品牌信息
        /// </summary>
        /// <param name="brandid"></param>
        /// <returns></returns>
        public int DeleteBrandItem(int brandid)
        {
            string sqltxt = @"UPDATE  A WITH ( ROWLOCK )
SET    
        A.isshow =0 
FROM    ShoppingStore.dbo.bsp_brands A 
WHERE A.brandid = @id ";
            SqlParameter[] paramter = {
                                          new SqlParameter("@id",SqlDbType.Int)
                                      };
            paramter[0].Value = brandid;
            return helper.ExecuteSql(sqltxt,paramter);
        }
    }
}
