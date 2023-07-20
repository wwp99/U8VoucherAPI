using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicVatti.Model
{
    /// <summary>
    /// 供应商档案实体
    /// </summary>
    public class Vendor
    {
        /// <summary>
        /// 第三方供应商ID
        /// </summary>
        public string BIPID { get; set; }

        /// <summary>
        /// 供应商编码
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 供应商简称
        /// </summary>
        public string abbrname { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// 到货地址
        /// </summary>
        public string receive_site { get; set; }

        /// <summary>
        /// 停用日期
        /// </summary>
        public string end_date { get; set; }

        /// <summary>
        /// 开户银行
        /// </summary>
        public string bank_open { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        public string bank_acc_number { get; set; }

        /// <summary>
        /// 税率
        /// </summary>
        public double iVenTaxRate { get; set; }

        /// <summary>
        /// 法人
        /// </summary>
        public string cVenLPerson { get; set; }

        /// <summary>
        /// 是否有分支机构
        /// </summary>
        public int bVenHomeBranch { get; set; }

        /// <summary>
        /// 企业类型
        /// </summary>
        public int iVenGSPType { get; set; }

        /// <summary>
        /// 账期管理
        /// </summary>
        public int bVenAccPeriodMng { get; set; } 

        /// <summary>
        /// 是否国外
        /// </summary>
        public int bVenOverseas { get; set; } 

        /// <summary>
        /// 单价是否含税
        /// </summary>
        public int bVenTax { get; set; } 

        /// <summary>
        /// 营业执照是否期限
        /// </summary>
        public int bLicenceDate { get; set; } 

        /// <summary>
        /// 经营许可是否期限
        /// </summary>
        public int bBusinessDate { get; set; } 

        /// <summary>
        /// 法人委托是否期限
        /// </summary>
        public int bProxyDate { get; set; } 

        /// <summary>
        /// 是否通过GMP
        /// </summary>
        public int bPassGMP { get; set; }

        /// <summary>
        /// 采购/委外/服务
        /// </summary>
        public int bvencargo { get; set; }
        /// <summary>
        /// 是否采购
        /// </summary>
        public int bVenCargo { get; set; } = 0;

        /// <summary>
        /// 是否委外
        /// </summary>
        public int bProxyForeign { get; set; } = 0;

        /// <summary>
        /// 是否服务
        /// </summary>
        public int bVenService { get; set; } = 0;

        /// <summary>
        /// 电话
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string fax { get; set; }


        /// <summary>
        /// 邮政编码
        /// </summary>
        public string cVenPostCode { get; set; }

        /// <summary>
        /// 信用额度
        /// </summary>
        public decimal iVenCreLine { get; set; }

        /// <summary>
        /// 税号
        /// </summary>
        public decimal fRegistFund { get; set; }

        /// <summary>
        /// 信用天数
        /// </summary>
        public int iVenCreDate { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string contact { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string mobile { get; set; }


        /// <summary>
        /// 助记码
        /// </summary>
        public string cVenMnemCode { get; set; }

        /// <summary>
        /// 建档人
        /// </summary>
        public string cCreatePerson { get; set; }

        /// <summary>
        /// 建档日期
        /// </summary>
        public DateTime dVenCreateDatetime { get; set; }


        /// <summary>
        /// 变更人
        /// </summary>
        public string cModifyPerson { get; set; }

        /// <summary>
        /// 变更日期
        /// </summary>
        public DateTime dModifyDate { get; set; }

        /// <summary>
        /// 发展日期
        /// </summary>
        public DateTime dVenDevDate { get; set; }

        /// <summary>
        /// 供应商分类
        /// </summary>
        public string sort_code { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        public string cVenExch_name { get; set; }

        /// <summary>
        /// 自定义1
        /// </summary>
        public string self_define1 { get; set; }

        /// <summary>
        /// 自定义2
        /// </summary>
        public string self_define2 { get; set; }

        /// <summary>
        /// 自定义3
        /// </summary>
        public string self_define3 { get; set; }

        /// <summary>
        /// 自定义4
        /// </summary>
        public string self_define4 { get; set; }

        /// <summary>
        /// 自定义项15
        /// </summary>
        public string self_define15 { get; set; }

        /// <summary>
        /// 自定义项16
        /// </summary>
        public string self_define16 { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string memo { get; set; }


    }
}
