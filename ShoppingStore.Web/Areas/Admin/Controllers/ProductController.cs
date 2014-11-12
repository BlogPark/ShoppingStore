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
        public JsonResult getCategoryjsonstr2()
        {
            List<Categories> categories = categoryandproduct.SelectAllCategory();

            return Json(categories, JsonRequestBehavior.AllowGet);
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
            model.PageSize = Convert.ToInt32(Request.Params["pagesize"]);
            model.PageIndex = Convert.ToInt32(Request.Params["page"]);
            DataTable brandstable = categoryandproduct.GetAllBrands(model);
            List<BrandsInfoModel> brandslist = new List<BrandsInfoModel>();
            foreach (DataRow item in brandstable.Rows)
            {
                BrandsInfoModel brandmodel = new BrandsInfoModel();
                brandmodel.brandid = int.Parse(item["brandid"].ToString());
                brandmodel.name = item["brandname"].ToString();
                brandmodel.IsUsed = item["isused"].ToString();
                brandmodel.IsRecommended = item["IsRecommend"].ToString();
                brandmodel.logo = item["logopath"].ToString();
                brandmodel.MainCategoryName = item["maincatename"].ToString();
                brandmodel.MainCategoryID = int.Parse(item["MainCategoryID"].ToString());
                brandmodel.BlongCategoryName = item["blongcatename"].ToString();
                brandmodel.BelongsCategoryID = int.Parse(item["BelongsCategoryID"].ToString());
                brandslist.Add(brandmodel);
            }
            var griddata = new
            {
                Rows = brandslist,
                Total = int.Parse(brandstable.Rows[0]["tco"].ToString())
            };
            return Json(griddata, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddBrands(FormCollection form)
        {
            BrandsInfoModel model = new BrandsInfoModel();
            model.name = form["addbrands"].ToString();
            model.isshow = form["addcheckuse"] == null ? 0 : 1;
            model.IsRecommend = form["addcheckRecommended"] == null ? 0 : 1;
            model.BelongsCategoryID = int.Parse(form["addhidden"].ToString());
            int k = categoryandproduct.Addbranditem(model);
            return RedirectToAction("Brands");
        }

        [HttpPost]
        public ActionResult Updatebrands(BrandsInfoModel model)
        {
            int k = categoryandproduct.UpdateBrandsitem(model);
            if (k > 0)
                return Json("1", JsonRequestBehavior.DenyGet);
            else
                return Json("0", JsonRequestBehavior.DenyGet);
        }
    }
}
