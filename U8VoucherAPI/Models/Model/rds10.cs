using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZR.U8API.Model
{
    /// <summary>
    /// 产成品入库单子表
    /// </summary>
    public class rds10
    {
        /// <summary>
        /// 存货编码
        /// </summary>
        public string cinvcode { get; set; }

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
        /// 批号
        /// </summary>
        public string cbatch { get; set; }

        /// <summary>
        /// 标志
        /// </summary>
        public int iflag { get; set; } = 0;

        /// <summary>
        /// 货位
        /// </summary>
        public string cposition { get; set; }

        /// <summary>
        /// 应收应发数量
        /// </summary>
        public decimal inquantity { get; set; }

        /// <summary>
        /// 生产订单子表标识
        /// </summary>
        public int impoIds { get; set; }

        public int brelated { get; set; } = 0;

        public int blpusefree { get; set; } = 0;

        public int irsrowno { get; set; } = 0;

        /// <summary>
        /// 表体记账人
        /// </summary>
        public string cbaccounter { get; set; }

        /// <summary>
        /// 表体记账日期
        /// </summary>
        public string dbkeepdate { get; set; }

        /// <summary>
        /// 单据是否核算
        /// </summary>
        public int bcosting { get; set; } = 1;

        /// <summary>
        /// 生产订单号
        /// </summary>
        public string cmocode { get; set; }

        /// <summary>
        /// 生产订单行号
        /// </summary>
        public int imoseq { get; set; }

        public int iorderdid { get; set; } = 0;

        public int iordertype { get; set; } = 0;

        public int isotype { get; set; } = 0;

        /// <summary>
        /// 单据体行号
        /// </summary>
        public int irowno { get; set; }
    }
}