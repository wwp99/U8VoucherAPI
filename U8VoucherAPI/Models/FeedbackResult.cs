using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U8VoucherAPI.Models
{
    /// <summary>
    /// 调用结果返回
    /// </summary>
    public class FeedbackResult
    {

        /// <summary>
        /// 错误码
        /// </summary>
        public string errcode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string errmsg { get; set; }
        /// <summary>
        /// id
        /// </summary>
        public string id { get; set; }
    }

    /// <summary>
    /// Token调用结果返回
    /// </summary>
    public class TokenFeedbackResult:FeedbackResult
    {
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
    }
}