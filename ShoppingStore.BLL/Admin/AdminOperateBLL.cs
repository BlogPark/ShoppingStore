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
                model.url = item["url"].ToString();
                model.parentid = int.Parse(item["parentid"].ToString());
                model.title = item["title"].ToString();
                models.Add(model);
            }
            return models;
        }

        public List<FriendlinksModel> FriendLinkList()
        {
            DataTable dt = dal.GetAllfriendlinks();
            List<FriendlinksModel> modellist = new List<FriendlinksModel>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    FriendlinksModel model = new FriendlinksModel();
                    model.Name = item["name"].ToString();
                    model.Logo = item["logo"].ToString();
                    model.Target = item["target"].ToString();
                    model.Title = item["title"].ToString();
                    model.Url = item["url"].ToString();
                    model.Displayorder = item["Displayorder"].ToString();
                    modellist.Add(model);
                }
            }
            return modellist;
        }
    }
}
