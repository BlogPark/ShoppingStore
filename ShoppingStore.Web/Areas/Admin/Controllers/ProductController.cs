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
        [HttpPost]
        public ActionResult AddCategoryitem(FormCollection from)
        {
            Categories model = new Categories();
            model.name = from["name"].ToString();
            model.isshow = from["chk"] == null ? 0 : 1;
            model.parentid = string.IsNullOrWhiteSpace(from["txt2"].ToString()) ? 0 : int.Parse(from["hiddenarea"].ToString());
            model.pricerange = from["pricerange"].ToString();
            model.haschild = model.parentid == 0 ? 1 : 0;
            model.layer = 0;
            model.path = model.parentid == 0 ? "1" : "2";
            model.displayorder = 0;
            int k = categoryandproduct.AddCategoryInfo(model);
            return RedirectToAction("AddCategory");
        }
    }
}
