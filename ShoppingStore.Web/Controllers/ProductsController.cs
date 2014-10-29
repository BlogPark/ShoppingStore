using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingStore.Model;
using ShoppingStore.BLL;


namespace ShoppingStore.Web.Controllers
{
    public class ProductsController : Controller
    {
        ProductOperateBLL bll = new ProductOperateBLL();
        public ActionResult itemdetail(int productid=1)
        {
            ProductDetailsPageModel model = bll.GetSingleProductDetails(productid);
            return View(model);
        }
        public ActionResult test()
        { return View(); }
    }
}
