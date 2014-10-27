using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingStore.BLL;
using System.Data;
using ShoppingStore.Web.Models;
using ShoppingStore.Model;

namespace ShoppingStore.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "";
            return View();
        }
        /// <summary>
        /// 根据大类读取商品信息
        /// </summary>
        /// <param name="categoryid"></param>
        /// <returns></returns>
        public List<ProductsModel> GetProductsByMainCate(int categoryid)
        {
            ProductOperateBLL bll = new ProductOperateBLL();
            List<ProductsModel> products = bll.GetProShowIndexPage(categoryid);
            return products;
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        /// 首页Action
        /// </summary>
        /// <returns></returns>
        public ActionResult defaultpage()
        {
            ViewBag.Message = "";
            CategoriesOperateBLL bll = new CategoriesOperateBLL();
            List<CategoriesModel> model = bll.GetAllMainCategories();
            return View(model);
        }
        public ActionResult BigCategoryList()
        {
            MenuCategoriesPModel model = new MenuCategoriesPModel();
            IndexCommonDataBLL bll = new IndexCommonDataBLL();
            DataSet ds = bll.GetFatherMenus();
            model.bigcategory=ds.Tables[0];
            model.subcategory=ds.Tables[1];
            model.brandtable=ds.Tables[2];
            model.categorytable = ds.Tables[3];
            return PartialView("_MenuPartial",model);
        }
        public ActionResult PageNavList()
        {
            IndexCommonDataBLL bll = new IndexCommonDataBLL();
            DataTable dt = bll.GetPageNavlist();
            return PartialView("_PageNavPartial",dt);
        }
        public ActionResult PageBannerList()
        {
            IndexCommonDataBLL bll = new IndexCommonDataBLL();
            DataTable dt = bll.Getbannerlist();
            return PartialView("_BannerPartial", dt);
        }
        public ActionResult PageNewsList()
        {
            return PartialView("_NewsPartial");
        }
    }
}
