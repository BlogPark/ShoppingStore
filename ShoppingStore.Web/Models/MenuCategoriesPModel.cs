using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ShoppingStore.Web.Models
{
    public class MenuCategoriesPModel
    {
        /// <summary>
        /// 主类别信息
        /// </summary>
        public DataTable bigcategory { get; set; }
        /// <summary>
        /// 子分类信息
        /// </summary>
        public DataTable subcategory { get; set; }
        /// <summary>
        /// 推荐品牌信息
        /// </summary>
        public DataTable brandtable { get; set; }
        /// <summary>
        /// 子分类
        /// </summary>
        public DataTable categorytable { get; set; }
    }
}