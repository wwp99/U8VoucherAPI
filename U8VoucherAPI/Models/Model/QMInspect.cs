using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.U8API.Model
{
    /// <summary>
    /// 报检单主表
    /// </summary>
    public class QMInspect
    {
        /// <summary>
        /// 报检单号
        /// </summary>
        public string cinspectcode { get; set; }

        /// <summary>
        /// 报检单GUID
        /// </summary>
        public string inspectguid { get; set; }

        /// <summary>
        /// 单据类型
        /// </summary>
        public string cvouchtype { get; set; }

        /// <summary>
        /// 来源单号
        /// </summary>
        public string csourcecode { get; set; }

        /// <summary>
        /// 来源单据ID
        /// </summary>
        public string csourceid { get; set; }

        /// <summary>
        /// 到货日期
        /// </summary>
        public string darrivaldate { get; set; }

        /// <summary>
        /// 检验日期
        /// </summary>
        public string ddate { get; set; }

        /// <summary>
        /// 采购/委外部门
        /// </summary>
        public string cdepcode { get; set; }

        /// <summary>
        /// 报检部门
        /// </summary>
        public string cinspectdepcode { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        public string cvencode { get; set; }

        /// <summary>
        /// 报检时间
        /// </summary>
        public string ctime { get; set; }

        /// <summary>
        /// 来源单据类型
        /// </summary>
        public string csource { get; set; }

        /// <summary>
        /// 单据模板号
        /// </summary>
        public string ivtid { get; set; }

        /// <summary>
        /// 检验类型
        /// </summary>
        public string cchecktypecode { get; set; }

        /// <summary>
        /// 制单人
        /// </summary>
        public string cmaker { get; set; }
    }
}
