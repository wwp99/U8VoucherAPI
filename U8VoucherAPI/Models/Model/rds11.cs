using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.U8API.Model
{
    public class rds11
    {
        /// <summary>
        /// 存货编码
        /// </summary>
        public string cinvcode { get; set; }

        /// <summary>
        /// 货位
        /// </summary>
        public string cposition { get; set; }

        /// <summary>
        /// 批号
        /// </summary>
        public string cbatch { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal iquantity { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal iunitcost { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal iprice { get; set; }

        /// <summary>
        /// 应发数量
        /// </summary>
        public decimal inquantity { get; set; }

        /// <summary>
        /// 领料申请单子表ID
        /// </summary>
        public string imaids { get; set; }

    }
}
