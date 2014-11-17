using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingStore.Web.Areas.Admin.Models
{
    public class UserinfoModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// 是否自动登录
        /// </summary>
        public bool IsSession { get; set; }
        /// <summary>
        /// 返回URL
        /// </summary>
        public string ReturnURL { get; set; }

    }
}