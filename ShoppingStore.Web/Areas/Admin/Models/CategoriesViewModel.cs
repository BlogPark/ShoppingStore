using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingStore.Web.Areas.Admin.Models
{
    public class CategoriesViewModel
    {
        private string name;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}