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
        /// <summary>
        /// 查询单件商品的信息
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public DataTable GetSingleProductInfo(int productid)
        {
            string sqltxt = @"SELECT  pid ,
        InternalCode ,
        MainCategoryid ,
        Cateid ,
        Brandid ,
        ProductName ,
        Shopprice ,
        Marketprice ,
        Costprice ,
        ProductState ,
        Isbest ,
        Ishot ,
        Isnew ,
        Displayorder ,
        Weight ,
        ShowimgPath ,
        Salecount ,
        Visitcount ,
        Reviewcount ,
        Star1 ,
        Star2 ,
        Star3 ,
        Star4 ,
        Star5 ,
        Description ,
        CreateTime ,
        SimpleDescription
FROM    ShoppingStore.dbo.bsp_products WITH ( NOLOCK )
WHERE   pid = @id";
            SqlParameter[] paramter = { new SqlParameter("@id",SqlDbType.Int)};
            paramter[0].Value = productid;
            return helper.Query(sqltxt, paramter).Tables[0];
        }
        /// <summary>
        /// 按照pid得到产品的主图
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public DataTable GetProductMainimageByPid(int productid)
        {
            string sqltxt = @"SELECT TOP 4
        pimgid ,
        pid ,
        showimg ,
        ismain ,
        displayorder
FROM    ShoppingStore.dbo.bsp_productimages WITH ( NOLOCK )
WHERE   pid = @pid
        AND ismain = 1
ORDER BY displayorder ASC";
            SqlParameter[] paramter = { new SqlParameter("@pid",SqlDbType.Int)};
            paramter[0].Value = productid;
            return helper.Query(sqltxt,paramter).Tables[0];
        }
        /// <summary>
        /// 按照sku得到产品的主图
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        public DataTable GetProductMainimageBySKU(int sku)
        {
            string sqltxt = @"SELECT TOP 4
        pimgid ,
        pid ,
        showimg ,
        ismain ,
        displayorder
FROM    ShoppingStore.dbo.bsp_productimages WITH ( NOLOCK )
WHERE   SKU = @sku
        AND ismain = 1
ORDER BY displayorder ASC";
            SqlParameter[] paramter = {new SqlParameter("@sku",SqlDbType.Int) };
            paramter[0].Value = sku;
            return helper.Query(sqltxt, paramter).Tables[0];
        }
        /// <summary>
        /// 根据一个产品推荐5个相关热卖产品
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public DataTable GetRelevantHotMaleProduct(int productid)
        {
            string sqltxt = @"SELECT TOP 5 pid ,
        InternalCode ,
        MainCategoryid ,
        Cateid ,
        Brandid ,
        ProductName ,
        Shopprice ,
        Marketprice ,
        Costprice ,
        ProductState ,
        Isbest ,
        Ishot ,
        Isnew ,
        Displayorder ,
        Weight ,
        ShowimgPath ,
        Salecount ,
        Visitcount ,
        Reviewcount ,
        Star1 ,
        Star2 ,
        Star3 ,
        Star4 ,
        Star5 ,
        Description ,
        CreateTime ,
        SimpleDescription
FROM    ShoppingStore.dbo.bsp_products WITH ( NOLOCK )
WHERE   Cateid = ( SELECT   Cateid
                   FROM     ShoppingStore.dbo.bsp_products WITH ( NOLOCK )
                   WHERE    pid = @id
                 )
        AND ishot = 1
ORDER BY CreateTime DESC ";
            SqlParameter[] parmter = { new SqlParameter("@id",SqlDbType.Int)};
            parmter[0].Value = productid;
            return helper.Query(sqltxt, parmter).Tables[0];
        }

        public DataTable GetProductsBycategory(int category, int type,int isbest)
        {
            string sqltxt = @"SELECT  [pid] ,
        [InternalCode] ,
        [MainCategoryid] ,
        [Cateid] ,
        [Brandid] ,
        [ProductName] ,
        [Shopprice] ,
        [Marketprice] ,
        [Costprice] ,
        [ProductState] ,
        [Isbest] ,
        [Ishot] ,
        [Isnew] ,
        [Displayorder] ,
        [Weight] ,
        [ShowimgPath] ,
        [Salecount] ,
        [Visitcount] ,
        [Reviewcount] ,
        [Star1] ,
        [Star2] ,
        [Star3] ,
        [Star4] ,
        [Star5] ,
        [Description] ,
        [CreateTime] ,
        [SimpleDescription]
FROM    [ShoppingStore].[dbo].[bsp_products] WITH(NOLOCK)
WHERE  productstate=0";
            if (isbest == 1)
            {
                sqltxt += @" AND Isbest=1";
            }
            if (type == 0)
                sqltxt += @"  AND MainCategoryid=@id 
ORDER BY CreateTime DESC";
            else
                sqltxt += @"  AND Cateid=@id 
ORDER BY CreateTime DESC";
            SqlParameter[] paramter = { new SqlParameter("@id",SqlDbType.Int)};
            paramter[0].Value = category;
            return helper.Query(sqltxt, paramter).Tables[0];
        }



    }
}
