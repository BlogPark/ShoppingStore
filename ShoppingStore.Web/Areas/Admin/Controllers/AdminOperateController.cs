using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingStore.Model.Admin;
using ShoppingStore.BLL.Admin;
using ShoppingStore.Common;
using System.Web.Script.Serialization;

namespace ShoppingStore.Web.Areas.Admin.Controllers
{
    public class AdminOperateController : Controller
    {
        AdminOperateBLL bll = new AdminOperateBLL();
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(string username,string pwd)
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
        public string GetOperateMenus()
        {
            List<Adminactions> models = bll.GetOperateMenus();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonstr = jss.Serialize(models);
            return jsonstr;
        }
    }
}
