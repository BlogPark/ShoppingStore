using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// 扩展方法类
    /// </summary>
    public static class ExtenceClass
    {
        /// <summary>
        /// 将字符串转换为数字
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultnum">默认数字 转换失败时返回此数字</param>
        /// <returns></returns>
        public static int ToInt(this string value,int defaultnum)
        {
            int returnnum = 0;
            if (!int.TryParse(value, out returnnum))
            {
                returnnum = defaultnum;
            }
            return int.Parse(value);
        }
        /// <summary>
        /// 将字符串转换为Decimal
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultnum">默认值 转换失败时返回此值</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string value, decimal defaultnum)
        {
            decimal returnnum;
            if (!decimal.TryParse(value, out returnnum))
            { returnnum = defaultnum; }
            return returnnum;
        }
        /// <summary>
        /// 字符串左边补0
        /// </summary>
        /// <param name="value"></param>
        /// <param name="strlengh">字符串总长度</param>
        /// <returns></returns>
        public static string AddZeroToLeft(this string value, int strlengh)
        {
            return value.PadLeft(strlengh, '0');
        }
    }
}
