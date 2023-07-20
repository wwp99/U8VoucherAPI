using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.U8API.Model
{
    /// <summary>
    /// 调拨单子表
    /// </summary>
    public class TransVouchs
    {
        /// <summary>
        /// 存货编码
        /// </summary>
        public string cInvCode { get; set; }

        /// <summary>
        /// 调拨单单号
        /// </summary>
        public string cTVCode { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal iTVQuantity { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal iTVACost { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal iTVAPrice { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string cbMemo { get; set; }

        /// <summary>
        /// 批号
        /// </summary>
        public string cTVBatch { get; set; }

        /// <summary>
        /// 调入货位
        /// </summary>
        public string cinposcode { get; set; }

        /// <summary>
        /// 调出货位
        /// </summary>
        public string coutposcode { get; set; }
    }
}
