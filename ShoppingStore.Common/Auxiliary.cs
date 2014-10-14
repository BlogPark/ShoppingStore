using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingStore.Common
{
    public class Auxiliary
    {
        /// <summary>
        /// MD5加密字符串
        /// </summary>
        /// <param name="encodingstr">待加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5Encoding(string encodingstr)
        {
            MD5 md5 = MD5.Create();
            byte[] bs = Encoding.UTF8.GetBytes(encodingstr);
            byte[] hs = md5.ComputeHash(bs);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hs)
            {  
                // 以十六进制格式格式化  
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();  
        }
        /// <summary>
        /// MD5加盐值加密
        /// </summary>
        /// <param name="encodingstr">待加密的字符串</param>
        /// <param name="saltvalue">盐值</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5WithSaltEncoding(string encodingstr, object saltvalue)
        {
            if (saltvalue == null)
                return encodingstr;
            return MD5Encoding(encodingstr + "{" + saltvalue.ToString() + "}");
        }
    }
}
