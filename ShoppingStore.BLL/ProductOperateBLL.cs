using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ShoppingStore.DAL;
using ShoppingStore.Model;

namespace ShoppingStore.BLL
{
    /// <summary>
    /// 产品操作逻辑类
    /// </summary>
    public class ProductOperateBLL
    {
        ProductOperateDAL dal=new ProductOperateDAL();
        /// <summary>
        /// 得到首页显示的商品信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetProShowIndexPage()
        {
            return dal.GetProShowIndexPage();
        }
    }
}
