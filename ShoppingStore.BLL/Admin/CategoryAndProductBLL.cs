using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingStore.Model.Admin;
using ShoppingStore.DAL.Admin;
using System.Data;
using System.Data.SqlClient;

namespace ShoppingStore.BLL.Admin
{
    public class CategoryAndProductBLL
    {
        CategoryAndProductDAL dal = new CategoryAndProductDAL();
        /// <summary>
        /// 添加类别信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddCategoryInfo(Categories model)
        {
            return dal.AddCategoryInfo(model);
        }
        public List<Categories> SelectAllCategory()
        {
            DataTable dt = dal.SelectAllCategory();
            List<Categories> categorys = new List<Categories>();
            foreach (DataRow item in dt.Rows)
            {
                Categories model = new Categories();
                model.cateid = int.Parse(item["cateid"].ToString());
                model.name = item["name"].ToString();
                model.parentid = int.Parse(item["parentid"].ToString());
                categorys.Add(model);
            }
            return categorys;
        }

        /// <summary>
        /// 修改单个类别信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateCategoryItem(Categories model)
        {
            return dal.UpdateCategoryItem(model);
        }
        /// <summary>
        /// 查询所有的品牌
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetAllBrands(BrandsInfoModel model)
        {
            return dal.GetAllBrands(model);
        }
        /// <summary>
        /// 添加品牌信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Addbranditem(BrandsInfoModel model)
        {
            return dal.Addbranditem(model);
        }
        /// <summary>
        /// 修改品牌信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateBrandsitem(BrandsInfoModel model)
        {
            return dal.UpdateBrandsitem(model);
        }
        /// <summary>
        /// 删除品牌信息
        /// </summary>
        /// <param name="brandid"></param>
        /// <returns></returns>
        public int DeleteBrandItem(int brandid)
        {
            return dal.DeleteBrandItem(brandid);
        }
        /// <summary>
        /// 查询所有的属性
        /// </summary>
        /// <returns></returns>
        public List<AttributeModel> GetAllAttribute()
        {
            DataTable dt = dal.GetAllAttribute();
            List<AttributeModel> list = new List<AttributeModel>();
            foreach (DataRow item in dt.Rows)
            {
                AttributeModel model = new AttributeModel();
                model.attributecode = item["attributecode"].ToString();
                model.attrid = int.Parse(item["attrid"].ToString());
                model.IsEnable = int.Parse(item["IsEnable"].ToString());
                model.isfilter = int.Parse(item["isfilter"].ToString());
                model.IsSpec = int.Parse(item["IsSpec"].ToString());
                model.name = item["name"].ToString();
                model.showtype = int.Parse(item["showtype"].ToString());
                model.Enablename = item["enablename"].ToString();
                model.Isfiltername = item["isfiltername"].ToString();
                model.Isspecname = item["IsSpecname"].ToString();
                model.Showtypename = item["showtypename"].ToString();
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 查询属性值
        /// </summary>
        /// <param name="attrid"></param>
        /// <returns></returns>
        public List<AttributeValuesModel> GetAttributeValues(int attrid)
        {
            DataTable dt = dal.GetAttributevalues(attrid);
            List<AttributeValuesModel> list = new List<AttributeValuesModel>();
            foreach (DataRow item in dt.Rows)
            {
                AttributeValuesModel model = new AttributeValuesModel();
                model.attrid = int.Parse(item["attrid"].ToString());
                model.attrshowtype = int.Parse(item["attrshowtype"].ToString());
                model.attrvalueCode = item["attrvalueCode"].ToString();
                model.attrvalueid = int.Parse(item["attrvalueid"].ToString());
                model.attrvaluename = item["attrvaluename"].ToString();
                model.Enablename = item["enablename"].ToString();
                model.IsEnable = int.Parse(item["IsEnable"].ToString());
                model.isinput = int.Parse(item["isinput"].ToString());
                model.Showtypename = item["showtypename"].ToString();
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 插入属性
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertAttribute(AttributeModel model)
        {
            return dal.InsertAttribute(model);
        }
        /// <summary>
        /// 插入属性值信息
        /// </summary>
        /// <param name="valuemodel"></param>
        /// <returns></returns>
        public int InsertAttributeValue(AttributeValuesModel valuemodel)
        {
            return dal.InsertAttributeValue(valuemodel);
        }

        /// <summary>
        /// 得到类别和属性的对应关系
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<CategoryAttributeModel> GetCategoryAttribute(int id)
        {
            DataTable dt = dal.GetCategoryAttribute(id);
            List<CategoryAttributeModel> modellist = new List<CategoryAttributeModel>();
            foreach (DataRow item in dt.Rows)
            {
                CategoryAttributeModel model = new CategoryAttributeModel();
                model.CategoryID = item["CategoryID"].ToString().ToInt(0);
                model.AttributeName = item["name"].ToString();
                model.AttributeID = item["AttributeID"].ToString().ToInt(0);
                model.Enablename = item["enablename"].ToString();
                model.SpecName = item["isspec"].ToString();
                modellist.Add(model);
            }
            return modellist;
        }
        /// <summary>
        /// 插入属性和类别关系表
        /// </summary>
        /// <param name="attributeid"></param>
        /// <param name="cateid"></param>
        /// <returns></returns>
        public int InsertAttributeCategory(string attributeid, int cateid)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(attributeid))
                    return 0;
                string[] ids = attributeid.Split(';');
                foreach (string item in ids)
                {
                    int attid = item.ToInt(0);
                    int k = dal.InsertCategoryAttribute(cateid, attid);
                }
                return 1;
            }
            catch 
            {
                return 0;
            }
        }
        /// <summary>
        /// 得到属性列表
        /// </summary>
        /// <param name="cateid"></param>
        /// <returns></returns>
        public List<AttributeModel> GetAttributeDataforAddProduct(int cateid)
        {
            List<AttributeModel> models = new List<AttributeModel>();
            DataTable dt = dal.GetAttributeForProduct(cateid);
            foreach (DataRow item in dt.Rows)
            {
                AttributeModel model = new AttributeModel();
                model.name = item["name"].ToString();
                model.ShowIDname = item["showIDname"].ToString();
                model.attrid = item["attrid"].ToString().ToInt(0);
                model.attributecode = item["attributecode"].ToString();
                model.IsSpec = item["IsSpec"].ToString().ToInt(0);
                model.IsMultiple = item["IsMultiple"].ToString().ToInt(0);
                models.Add(model);
            }
            return models;
        }
        /// <summary>
        /// 得到品牌数据
        /// </summary>
        /// <param name="cateid"></param>
        /// <returns></returns>
        public List<BrandsInfoModel> GetbrandBycateid(int cateid)
        {
            List<BrandsInfoModel> models = new List<BrandsInfoModel>();
            DataTable dt = dal.GetbrandsByCateid(cateid);
            foreach (DataRow item in dt.Rows)
            {
                BrandsInfoModel model = new BrandsInfoModel();
                model.name = item["name"].ToString();
                model.brandid = item["brandid"].ToString().ToInt(0);
                models.Add(model);
            }
            return models;
        }
    }
}
