﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShoppingStore.Model.Admin
{
    [DataContract]
    public class BrandsInfoModel
    {
        /// <summary>
        /// 品牌ID
        /// </summary>
        [DataMember]
        public int brandid { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        [DataMember]
        public int isshow { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public string IsUsed { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [DataMember]
        public int displayorder { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string name { get; set; }
        /// <summary>
        /// 标志
        /// </summary>
        [DataMember]
        public string logo { get; set; }
        /// <summary>
        /// 所属分类
        /// </summary>
        [DataMember]
        public int BelongsCategoryID { get; set; }
        /// <summary>
        /// 是否推荐
        /// </summary>
        [DataMember]
        public int IsRecommend { get; set; }
        /// <summary>
        /// 是否推荐
        /// </summary>
        [DataMember]
        public string IsRecommended { get; set; }
        /// <summary>
        /// 主类ID
        /// </summary>
        [DataMember]
        public int MainCategoryID { get; set; }
        /// <summary>
        /// 页索引
        /// </summary>
        [DataMember]
        public int PageIndex { get; set; }
        /// <summary>
        /// 页容量
        /// </summary>
        [DataMember]
        public int PageSize { get; set; }
        /// <summary>
        /// 主类的名称
        /// </summary>
        [DataMember]
        public string MainCategoryName { get; set; }
        /// <summary>
        /// 所属类别名称
        /// </summary>
        [DataMember]
        public string BlongCategoryName { get; set; }

    }
}
