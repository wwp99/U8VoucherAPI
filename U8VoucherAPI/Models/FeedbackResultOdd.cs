using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U8VoucherAPI.Models
{
    /// <summary>
    /// 返回信息携带单号
    /// </summary>
    public class FeedbackResultOdd:FeedbackResult
    {
        /// <summary>
        /// 单号
        /// </summary>
        public string billon { get; set; }
    }
}