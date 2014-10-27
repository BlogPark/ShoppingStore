using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingStore.Model
{
    public class CategoriesModel
    {
        /// <summary>
        /// 分类ID
        /// </summary>
        public int cateid { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public int isshow { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int displayorder { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 引用图片
        /// </summary>
        public string pricerange { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public int parentid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int layer { get; set; }
        /// <summary>
        /// 是否有下级
        /// </summary>
        public int haschild { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public string path { get; set; }
    }
}
