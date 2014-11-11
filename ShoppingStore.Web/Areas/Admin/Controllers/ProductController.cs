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
            model.layer = model.parentid == 0 ? 1 : 0; ;
            model.path = model.parentid == 0 ? "1" : "2";
            model.displayorder = 0;
            int k = categoryandproduct.AddCategoryInfo(model);
            return RedirectToAction("AddCategory");
        }

        public string UpdateCategoryItem(int id, int pid, string catename, bool isenable = false)
        {
            Categories model = new Categories();
            model.name = catename;
            model.isshow = isenable ? 1 : 0;
            model.parentid = pid;
            model.cateid = id;
            int k = categoryandproduct.UpdateCategoryItem(model);
            if (k > 0)
                return "1";
            else
                return "0";
        }

        public ActionResult Brands()
        {
            return View();
        }
        public JsonResult GetAllBrands()
        {
            BrandsInfoModel model = new BrandsInfoModel();
            //int pageindexsd = Convert.ToInt32(Request.Params["pageindex"]) + Convert.ToInt32(Request.Params["pagesize"]);
            model.PageSize = 30;//Convert.ToInt32(Request.Params["pagesize"]);
            model.PageIndex = 1;//Convert.ToInt32(Request.Params["page"]);
            DataTable brandstable = categoryandproduct.GetAllBrands(model);
            var griddata = new
            {
                Rows =brandstable,
                Total = int.Parse(brandstable.Rows[0]["tco"].ToString())
            };
            return Json(griddata,JsonRequestBehavior.AllowGet);
        }
    }
}
