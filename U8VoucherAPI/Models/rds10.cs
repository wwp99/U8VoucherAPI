using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U8VoucherAPI.Models
{
    /// <summary>
    /// 产成品入库单子表
    /// </summary>
    public class rds10
    {
        /// <summary>
        /// 存货编码
        /// </summary>
        public string cInvCode { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal iQuantity { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal iUnitCost { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal iPrice { get; set; }

        /// <summary>
        /// 批号
        /// </summary>
        public string cBatch { get; set; }

        /// <summary>
        /// 标志
        /// </summary>
        public int iFlag { get; set; } = 0;

        /// <summary>
        /// 货位
        /// </summary>
        public string cPosition { get; set; }

        /// <summary>
        /// 应收应发数量
        /// </summary>
        public decimal iNQuantity { get; set; }

        /// <summary>
        /// 生产订单子表标识
        /// </summary>
        public int iMPoIds { get; set; }

        public int bRelated { get; set; } = 0;

        public int bLPUseFree { get; set; } = 0;

        public int iRSRowNO { get; set; } = 0;

        /// <summary>
        /// 表体记账人
        /// </summary>
        public string cbaccounter { get; set; }

        /// <summary>
        /// 表体记账日期
        /// </summary>
        public string dbKeepDate { get; set; }

        /// <summary>
        /// 单据是否核算
        /// </summary>
        public int bCosting { get; set; } = 1;

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