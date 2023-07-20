using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U8VoucherAPI.Models
{
    /// <summary>
    /// 返回查询数据
    /// </summary>
    public class FeedbackResultData<T>: FeedbackResult
    {
        /// <summary>
        /// 数据
        /// </summary>
        public List<T> data { get; set; }
    }
}