using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using ShoppingStore.Model.Admin;
using ShoppingStore.BLL.Admin;
using ShoppingStore.BLL;
using ShoppingStore.Web.Areas.Admin.Models;
using ShoppingStore.Model;
using System.Web.Script.Serialization;

namespace ShoppingStore.Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        CategoryAndProductBLL categoryandproduct = new CategoryAndProductBLL();
        CategoriesOperateBLL catebll = new CategoriesOperateBLL();
        public string getCategoryjsonstr()
        {
            List<Categories> categories = categoryandproduct.SelectAllCategory();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(categories);
        }
        public string GetMainCategories()
        {
            List<CategoriesModel> model = catebll.GetAllMainCategories();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(model);
        }
        public ActionResult AddCategory()
        {
            return View();
        }
    }
}
