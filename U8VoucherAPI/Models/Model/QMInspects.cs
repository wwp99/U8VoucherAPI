using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.U8API.Model
{
    /// <summary>
    /// 报检单子表
    /// </summary>
    public class QMInspects
    {
        /// <summary>
        /// 来源单据子表ID
        /// </summary>
        public string sourceautoid { get; set; }

        /// <summary>
        /// 检验方式
        /// </summary>
        public string iteststyle { get; set; }

        /// <summary>
        /// 存货编码
        /// </summary>
        public string cinvcode { get; set; }

        /// <summary>
        /// 报检数量
        /// </summary>
        public decimal fquantity { get; set; }

        /// <summary>
        /// 采购订单
        /// </summary>
        public string cpocode { get; set; }
    }
}
