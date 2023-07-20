using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.U8API
{
    /// <summary>
    /// U8登录信息
    /// </summary>
    public class U8LoginInfo
    {
        /// <summary>
        /// 子模块ID
        /// </summary>
        public static string SubId { get; set; } = "DP";
        /// <summary>
        /// 账套号
        /// </summary>
        public static string AccId { get; set; }
        /// <summary>
        /// 年度
        /// </summary>
        public static string YearId { get; set; } = DateTime.Now.Year.ToString();
        /// <summary>
        /// 用户名
        /// </summary>
        public static string UserId { get; set; } = "13927990427";
        /// <summary>
        /// 密码
        /// </summary>
        public static string Password { get; set; } = "";
        /// <summary>
        /// 登录日期
        /// </summary>
        public static string Date { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        /// <summary>
        /// U8连接字符串(VB)
        /// </summary>
        public static string ConnectionStringVB { get; set; }
        /// <summary>
        /// U8连接字符串(Net)
        /// </summary>
        public static string ConnectionStringNet { get; set; }
    }
}
