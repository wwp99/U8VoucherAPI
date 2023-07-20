using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U8VoucherAPI.Models
{
    /// <summary>
    /// 产成品入库单主表
    /// </summary>
    public class rd10
    {
        /// <summary>
        /// 收发标志
        /// </summary>
        public int bRdFlag { get; set; } = 1;

        /// <summary>
        /// 单据类型
        /// </summary>
        public string cVouchType { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary>
        public string cBusType { get; set; }

        /// <summary>
        /// 单据来源
        /// </summary>
        public string cSource { get; set; }

        /// <summary>
        /// 对应业务单号
        /// </summary>
        public string cBusCode { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string cWhCode { get; set; }

        /// <summary>
        /// 单据日期
        /// </summary>
        public string dDate { get; set; }

        /// <summary>
        /// 单据编号
        /// </summary>
        public string cCode { get; set; }

        /// <summary>
        /// 收发类别编码
        /// </summary>
        public string cRdCode { get; set; }

        /// <summary>
        /// 部门编码
        /// </summary>
        public string cDepCode { get; set; }

        /// <summary>
        /// 是否传递
        /// </summary>
        public int bTransFlag { get; set; } = 0;

        /// <summary>
        /// 制单人
        /// </summary>
        public string cMaker { get; set; }

        /// <summary>
        /// 单据模板号
        /// </summary>
        public int VT_ID { get; set; }

        /// <summary>
        /// 生产订单编号
        /// </summary>
        public string cMPoCode { get; set; }

        /// <summary>
        /// 制单日期
        /// </summary>
        public string dnmaketime { get; set; }

        /// <summary>
        /// 采购期初标志
        /// </summary>
        public int bpufirst { get; set; } = 0;

        /// <summary>
        /// 存货期初标志
        /// </summary>
        public int biafirst { get; set; } = 0;

        /// <summary>
        /// 库存期初标志
        /// </summary>
        public int bIsSTQc { get; set; } = 0;

        /// <summary>
        /// 生产订单主表标识
        /// </summary>
        public string iproorderid { get; set; }

        /// <summary>
        /// 补料标志
        /// </summary>
        public int bIsComplement { get; set; } = 0;

        /// <summary>
        /// 扣税标志
        /// </summary>
        public int iDiscountTaxType { get; set; } = 0;

        /// <summary>
        /// 打回次数
        /// </summary>
        public int ireturncount { get; set; } = 0;

        /// <summary>
        /// 工作流审批状态
        /// </summary>
        public int iverifystate { get; set; } = 0;

        /// <summary>
        /// 是否启用工作流
        /// </summary>
        public int iswfcontrolled { get; set; } = 0;

        /// <summary>
        /// 红蓝标识
        /// </summary>
        public int bredvouch { get; set; } = 0;

        /// <summary>
        /// 打印次数
        /// </summary>
        public int iPrintCount { get; set; } = 0;
    }
}