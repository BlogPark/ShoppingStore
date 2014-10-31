using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ShoppingStore.Model.Admin;
using ShoppingStore.DAL.Admin;

namespace ShoppingStore.BLL.Admin
{
    /// <summary>
    /// 商城后台基础操作逻辑数据层
    /// </summary>
    public class AdminOperateBLL
    {
        AdminOperateDAL dal = new AdminOperateDAL();
        public List<Adminactions> GetOperateMenus()
        {
            List<Adminactions> models = new List<Adminactions>();
            foreach (DataRow item in dal.GetOperateMenus().Rows)
            {
                Adminactions model = new Adminactions();
                model.adminaid = int.Parse(item["adminaid"].ToString());
                model.action = item["action"].ToString();
                model.parentid = int.Parse(item["parentid"].ToString());
                model.title = item["title"].ToString();
                models.Add(model);
            }
            return models;
        }
    }
}
