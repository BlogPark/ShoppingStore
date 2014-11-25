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
        /// <summary>
        /// 返回所有类别的json字符串
        /// </summary>
        /// <returns></returns>
        public string getCategoryjsonstr()
        {
            List<Categories> categories = categoryandproduct.SelectAllCategory();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(categories);
        }
        /// <summary>
        /// 返回所有类别的Json对象
        /// </summary>
        /// <returns></returns>
        public JsonResult getCategoryjsonstr2()
        {
            List<Categories> categories = categoryandproduct.SelectAllCategory();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到所有一级类别
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 添加类别信息
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 更新类别信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pid"></param>
        /// <param name="catename"></param>
        /// <param name="isenable"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 得到品牌信息
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 添加品牌信息
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 更新品牌信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Updatebrands(BrandsInfoModel model)
        {
            int k = categoryandproduct.UpdateBrandsitem(model);
            if (k > 0)
                return Json("1", JsonRequestBehavior.DenyGet);
            else
                return Json("0", JsonRequestBehavior.DenyGet);
        }
        /// <summary>
        /// 删除（伪删除）品牌信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Deletebrand(int id)
        {
            int k = categoryandproduct.DeleteBrandItem(id);
            if (k > 0)
                return Json("1", JsonRequestBehavior.DenyGet);
            else
                return Json("0", JsonRequestBehavior.DenyGet);
        }

        public ActionResult ProductAttribute()
        {
            return View();
        }
        /// <summary>
        /// 得到所有的属性
        /// </summary>
        /// <returns></returns>
        public JsonResult GetallAttribute()
        {
            List<AttributeModel> model = categoryandproduct.GetAllAttribute();
            var griddata = new
            {
                Rows = model,
                Total = 2
            };
            return Json(griddata, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到所有的属性
        /// </summary>
        /// <returns></returns>
        public JsonResult GetallAttributeforcom()
        {
            List<AttributeModel> model = categoryandproduct.GetAllAttribute();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到所有的属性值
        /// </summary>
        /// <returns></returns>
        public JsonResult GetallAttributevalues(int id)
        {
            List<AttributeValuesModel> model = categoryandproduct.GetAttributeValues(id);
            var griddata = new
            {
                Rows = model,
                Total = model.Count
            };
            return Json(griddata, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 插入属性
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InsertAttribute(AttributeModel model)
        {
            int k = categoryandproduct.InsertAttribute(model);
            if (k > 0)
                return Json("1", JsonRequestBehavior.DenyGet);
            else
                return Json("0", JsonRequestBehavior.DenyGet);
        }
        /// <summary>
        /// 插入属性值
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InsertAttributevalue(AttributeValuesModel valmodel)
        {
            int k = categoryandproduct.InsertAttributeValue(valmodel);
            if (k > 0)
                return Json("1", JsonRequestBehavior.DenyGet);
            else
                return Json("0", JsonRequestBehavior.DenyGet);
        }
        /// <summary>
        /// 得到分类和属性对应关系
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetCategoryAttribute(int id)
        {
            List<CategoryAttributeModel> modellist = categoryandproduct.GetCategoryAttribute(id);
            var gdata = new { Rows = modellist, Total = modellist.Count };
            return Json(gdata, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 插入属性和类别关系表
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="cateid"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult InsertCategoryAttribute(string attribute, int cateid)
        {
            int k = categoryandproduct.InsertAttributeCategory(attribute, cateid);
            if (k > 0)
                return Json("1", JsonRequestBehavior.DenyGet);
            else
                return Json("0", JsonRequestBehavior.DenyGet);
        }

        public ActionResult AddProduct()
        {
            return View();
        }
        /// <summary>
        /// 得到品牌数据
        /// </summary>
        /// <param name="cateid"></param>
        /// <returns></returns>
        public ActionResult getBrandsbycate(int cateid)
        {
            List<BrandsInfoModel> model = categoryandproduct.GetbrandBycateid(cateid);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到属性列表
        /// </summary>
        /// <param name="cateid"></param>
        /// <returns></returns>
        public ActionResult Getattributebycate(int cateid)
        {
            List<AttributeModel> model = categoryandproduct.GetAttributeDataforAddProduct(cateid);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到属性值
        /// </summary>
        /// <param name="attid"></param>
        /// <returns></returns>
        public JsonResult GetAttributeValue(int attid)
        {
            List<AttributeValuesModel> model = categoryandproduct.GetAttributeValues(attid);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 上传缩略图
        /// </summary>
        /// <param name="Filedata"></param>
        /// <returns></returns>
        public ActionResult uploadThumbnailpic(HttpPostedFileBase Filedata)
        {
            // 如果没有上传文件
            if (Filedata == null ||
                string.IsNullOrEmpty(Filedata.FileName) ||
                Filedata.ContentLength == 0)
            {
                return this.HttpNotFound();
            }

            // 保存到 ~/photos 文件夹中，名称不变
            string filename = System.IO.Path.GetFileName(Filedata.FileName);
            string virtualPath =
                string.Format("/skuimgs/{0}", filename);
            // 文件系统不能使用虚拟路径
            string path = this.Server.MapPath(virtualPath);

            Filedata.SaveAs(path);
            return Json(new { Success = true, FileName = filename, SaveName = virtualPath });
        }
    }
}
