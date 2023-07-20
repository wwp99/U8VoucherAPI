using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.U8API.Model
{
    /// <summary>
    /// 盘点单子表
    /// </summary>
    public class Checks
    {
        /// <summary>
        /// 盘点单号
        /// </summary>
        public string ccvcode { get; set; }

        /// <summary>
        /// 存货编码
        /// </summary>
        public string cinvcode { get; set; }

        /// <summary>
        /// 账面数量
        /// </summary>
        public decimal icvquantity { get; set; }

        /// <summary>
        /// 盘点数量
        /// </summary>
        public decimal icvcquantity { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal ijhdj { get; set; }

        /// <summary>
        /// 盘点金额
        /// </summary>
        public decimal isjdj { get; set; }

        /// <summary>
        /// 盈亏金额
        /// </summary>
        public decimal isjje { get; set; }

        /// <summary>
        /// 调整入库数量
        /// </summary>
        public decimal iadinquantity { get; set; }

        /// <summary>
        /// 调整出库数量
        /// </summary>
        public decimal iadoutquantity { get; set; }

        /// <summary>
        /// 货位
        /// </summary>
        public string cposition { get; set; }

        /// <summary>
        /// 批号
        /// </summary>
        public string ccvbatch { get; set; }

        /// <summary>
        /// 实际损耗率 盈亏数量/（账面数量+调整入库数量-调整出库数量） *100
        /// </summary>
        public string iActualWaste { get; set; }
    }
}
