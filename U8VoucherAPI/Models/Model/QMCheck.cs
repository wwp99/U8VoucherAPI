using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.U8API.Model
{
    /// <summary>
    /// 检验单主表
    /// </summary>
    public class QMCheck
    {
        /// <summary>
        /// 检验单GUID
        /// </summary>
        public string checkguid { get; set; }


        /// <summary>
        /// 检验单据类型
        /// </summary>
        public string cvouchtype { get; set; }

        /// <summary>
        /// 检验单号
        /// </summary>
        public string ccheckcode { get; set; }

        /// <summary>
        /// 报检单ID
        /// </summary>
        public string inspectid { get; set; }

        /// <summary>
        /// 报检单号
        /// </summary>
        public string cinspectcode { get; set; }

        /// <summary>
        /// 报检单子表ID
        /// </summary>
        public string inspectautoid { get; set; }

        /// <summary>
        /// 来源主表ID
        /// </summary>
        public string sourceautoid { get; set; }

        /// <summary>
        /// 来源子表ID
        /// </summary>
        public string sourceid { get; set; }

        /// <summary>
        /// 来源单据号
        /// </summary>
        public string sourcecode { get; set; }

        /// <summary>
        /// 来源单据类型
        /// </summary>
        public string csource { get; set; }

        /// <summary>
        /// 采购订单号
        /// </summary>
        public string cpocode { get; set; }

        /// <summary>
        /// 报检部门
        /// </summary>
        public string cinspectdepcode { get; set; }

        /// <summary>
        /// 到货日期
        /// </summary>
        public string darrivaldate { get; set; }

        /// <summary>
        /// 检验日期
        /// </summary>
        public string ddate { get; set; }

        /// <summary>
        /// 报检人
        /// </summary>
        public string cinspectperson { get; set; }

        /// <summary>
        /// 检验时间
        /// </summary>
        public string ctime { get; set; }

        /// <summary>
        /// /检验部门编码
        /// </summary>
        public string cdepcode { get; set; }

        /// <summary>
        /// /检验部门
        /// </summary>
        public string cdepname { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        public string cvencode { get; set; }

        public string cvenname { get; set; }

        /// <summary>
        /// 存货编码
        /// </summary>
        public string cinvcode { get; set; }

        /// <summary>
        /// 存货名称
        /// </summary>
        public string cinvname { get; set; }

        /// <summary>
        /// 检验方式
        /// </summary>
        public string iteststyle { get; set; }

        /// <summary>
        /// 质量检验方案主表编号
        /// </summary>
        public string projectid { get; set; }

        /// <summary>
        /// 检验数量
        /// </summary>
        public decimal fquantity { get; set; }

        /// <summary>
        /// 合格接受数量
        /// </summary>
        public decimal fregquantity { get; set; }

        /// <summary>
        /// 不良品数量
        /// </summary>
        public decimal fdisquantity { get; set; }

        /// <summary>
        /// 检验员编码
        /// </summary>
        public string ccheckpersoncode { get; set; }

        /// <summary>
        /// 检验员
        /// </summary>
        public string ccheckpersonname { get; set; }
        /// <summary>
        /// 制单人
        /// </summary>
        public string cmaker { get; set; }

        /// <summary>
        /// 单据模板号
        /// </summary>
        public int ivtid { get; set; }

        /// <summary>
        /// 检验类型 ARR
        /// </summary>
        public string cchecktypecode { get; set; }
    }
}
