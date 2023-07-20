using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZR.U8API.Model
{


	/// <summary>
	/// 收发记录表单据子表
	/// </summary>
	public partial class rdrecords01 {
         
		/// <summary>
		/// 自动编号
		/// </summary>
		[JsonProperty]
		public long autoid { get; set; }

		/// <summary>
		/// 是否核算
		/// </summary>
		[JsonProperty]
		public bool? bcosting { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty]
		public int bgift { get; set; }

		/// <summary>
		/// 批次管理
		/// </summary>
		[JsonProperty]
		public bool? binvbatch { get; set; }

		/// <summary>
		/// 折扣类型
		/// </summary>
		[JsonProperty]
		public bool? binvtype { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty]
		public bool? bmergecheck { get; set; }

		/// <summary>
		/// 是否费用
		/// </summary>
		[JsonProperty]
		public bool? bservice { get; set; }

		/// <summary>
		/// 单价标准
		/// </summary>
		[JsonProperty]
		public bool? btaxcost { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty]
		public int? bveniid { get; set; }

		/// <summary>
		/// 代管消耗标识
		/// </summary>
		[JsonProperty]
		public bool bvmiused { get; set; }

		/// <summary>
		/// 库存单位码
		/// </summary>
		public string cassunit { get; set; } = string.Empty;

		/// <summary>
		/// 记账人
		/// </summary>
		public string cbaccounter { get; set; } = string.Empty;

		/// <summary>
		/// 条形码
		/// </summary>
		public string cbarcode { get; set; } = string.Empty;

		/// <summary>
		/// 到货单号
		/// </summary>
		public string cbarvcode { get; set; } = string.Empty;

		/// <summary>
		/// 批号
		/// </summary>
		public string cbatch { get; set; } = string.Empty;

		/// <summary>
		/// 批次属性1
		/// </summary>
		public decimal? cbatchproperty1 { get; set; }

		/// <summary>
		/// 批次属性10
		/// </summary>
		[JsonProperty]
		public DateTime? cbatchproperty10 { get; set; }

		/// <summary>
		/// 批次属性2
		/// </summary>
		public decimal? cbatchproperty2 { get; set; }

		/// <summary>
		/// 批次属性3
		/// </summary>
		public decimal? cbatchproperty3 { get; set; }

		/// <summary>
		/// 批次属性4
		/// </summary>
		public decimal? cbatchproperty4 { get; set; }

		/// <summary>
		/// 批次属性5
		/// </summary>
		public decimal? cbatchproperty5 { get; set; }

		/// <summary>
		/// 批次属性6
		/// </summary>
		public string cbatchproperty6 { get; set; } = string.Empty;

		/// <summary>
		/// 批次属性7
		/// </summary>
		public string cbatchproperty7 { get; set; } = string.Empty;

		/// <summary>
		/// 批次属性8
		/// </summary>
		public string cbatchproperty8 { get; set; } = string.Empty;

		/// <summary>
		/// 批次属性9
		/// </summary>
		public string cbatchproperty9 { get; set; } = string.Empty;

		/// <summary>
		/// 序列号
		/// </summary>
		public string cbinvsn { get; set; } = string.Empty;

		/// <summary>
		/// 备注
		/// </summary>
		[JsonProperty]
		public string cbmemo { get; set; } = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public string cbsysbarcode { get; set; } = string.Empty;

		/// <summary>
		/// 供应商编码
		/// </summary>
		public string cbvencode { get; set; } = string.Empty;

		/// <summary>
		/// 检验单号
		/// </summary>
		public string ccheckcode { get; set; } = string.Empty;

		/// <summary>
		/// 检验员编码
		/// </summary>
		public string ccheckpersoncode { get; set; } = string.Empty;

		/// <summary>
		/// 检验员
		/// </summary>
		public string ccheckpersonname { get; set; } = string.Empty;

		/// <summary>
		/// 手册号
		/// </summary>
		public string cciqbookcode { get; set; } = string.Empty;

		/// <summary>
		/// 表体自定义项1
		/// </summary>
		public string cdefine22 { get; set; } = string.Empty;

		/// <summary>
		/// 表体自定义项2
		/// </summary>
		public string cdefine23 { get; set; } = string.Empty;

		/// <summary>
		/// 表体自定义项3
		/// </summary>
		public string cdefine24 { get; set; } = string.Empty;

		/// <summary>
		/// 表体自定义项4
		/// </summary>
		public string cdefine25 { get; set; } = string.Empty;

		/// <summary>
		/// 表体自定义项5
		/// </summary>
		[JsonProperty]
		public double? cdefine26 { get; set; }

		/// <summary>
		/// 表体自定义项6
		/// </summary>
		[JsonProperty]
		public double? cdefine27 { get; set; }

		/// <summary>
		/// 表体自定义项7
		/// </summary>
		public string cdefine28 { get; set; } = string.Empty;

		/// <summary>
		/// 表体自定义项8
		/// </summary>
		public string cdefine29 { get; set; } = string.Empty;

		/// <summary>
		/// 表体自定义项9
		/// </summary>
		public string cdefine30 { get; set; } = string.Empty;

		/// <summary>
		/// 表体自定义项10
		/// </summary>
		public string cdefine31 { get; set; } = string.Empty;

		/// <summary>
		/// 表体自定义项11
		/// </summary>
		public string cdefine32 { get; set; } = string.Empty;

		/// <summary>
		/// 表体自定义项12
		/// </summary>
		public string cdefine33 { get; set; } = string.Empty;

		/// <summary>
		/// 表体自定义项13
		/// </summary>
		[JsonProperty]
		public int? cdefine34 { get; set; }

		/// <summary>
		/// 表体自定义项14
		/// </summary>
		[JsonProperty]
		public int? cdefine35 { get; set; }

		/// <summary>
		/// 表体自定义项15
		/// </summary>
		[JsonProperty]
		public DateTime? cdefine36 { get; set; }

		/// <summary>
		/// 表体自定义项16
		/// </summary>
		[JsonProperty]
		public DateTime? cdefine37 { get; set; }

		/// <summary>
		/// 需求分类代号说明
		/// </summary>
		[JsonProperty]
		public string cdemandmemo { get; set; } = string.Empty;

		/// <summary>
		/// 有效期至
		/// </summary>
		public string cexpirationdate { get; set; } = string.Empty;

		/// <summary>
		/// 存货自由项1
		/// </summary>
		public string cfree1 { get; set; } = string.Empty;

		/// <summary>
		/// 存货自由项10
		/// </summary>
		public string cfree10 { get; set; } = string.Empty;

		/// <summary>
		/// 存货自由项2
		/// </summary>
		public string cfree2 { get; set; } = string.Empty;

		/// <summary>
		/// 存货自由项3
		/// </summary>
		public string cfree3 { get; set; } = string.Empty;

		/// <summary>
		/// 存货自由项4
		/// </summary>
		public string cfree4 { get; set; } = string.Empty;

		/// <summary>
		/// 存货自由项5
		/// </summary>
		public string cfree5 { get; set; } = string.Empty;

		/// <summary>
		/// 存货自由项6
		/// </summary>
		public string cfree6 { get; set; } = string.Empty;

		/// <summary>
		/// 存货自由项7
		/// </summary>
		public string cfree7 { get; set; } = string.Empty;

		/// <summary>
		/// 存货自由项8
		/// </summary>
		public string cfree8 { get; set; } = string.Empty;

		/// <summary>
		/// 存货自由项9
		/// </summary>
		public string cfree9 { get; set; } = string.Empty;

		public string cgcgroupcode { get; set; } = string.Empty;

		/// <summary>
		/// 检验状态
		/// </summary>
		public string cgspstate { get; set; } = string.Empty;

		/// <summary>
		/// 库存单位
		/// </summary>
		public string cinva_unit { get; set; } = string.Empty;

		/// <summary>
		/// 存货代码
		/// </summary>
		[JsonProperty]
		public string cinvaddcode { get; set; } = string.Empty;

		/// <summary>
		/// 所属分类码
		/// </summary>
		public string cinvccode { get; set; } = string.Empty;

		/// <summary>
		/// 存货编码
		/// </summary>
		public string cinvcode { get; set; } = string.Empty;

		/// <summary>
		/// 存货自定义项1
		/// </summary>
		public string cinvdefine1 { get; set; } = string.Empty;

		/// <summary>
		/// 存货自定义项10
		/// </summary>
		public string cinvdefine10 { get; set; } = string.Empty;

		/// <summary>
		/// 存货自定义项11
		/// </summary>
		[JsonProperty]
		public int? cinvdefine11 { get; set; }

		/// <summary>
		/// 存货自定义项12
		/// </summary>
		[JsonProperty]
		public int? cinvdefine12 { get; set; }

		/// <summary>
		/// 存货自定义项13
		/// </summary>
		[JsonProperty]
		public double? cinvdefine13 { get; set; }

		/// <summary>
		/// 存货自定义项14
		/// </summary>
		[JsonProperty]
		public double? cinvdefine14 { get; set; }

		/// <summary>
		/// 存货自定义项15
		/// </summary>
		[JsonProperty]
		public DateTime? cinvdefine15 { get; set; }

		/// <summary>
		/// 存货自定义项16
		/// </summary>
		[JsonProperty]
		public DateTime? cinvdefine16 { get; set; }

		/// <summary>
		/// 存货自定义项2
		/// </summary>
		public string cinvdefine2 { get; set; } = string.Empty;

		/// <summary>
		/// 存货自定义项3
		/// </summary>
		public string cinvdefine3 { get; set; } = string.Empty;

		/// <summary>
		/// 存货自定义项4
		/// </summary>
		public string cinvdefine4 { get; set; } = string.Empty;

		/// <summary>
		/// 存货自定义项5
		public string cinvdefine5 { get; set; } = string.Empty;

		/// <summary>
		/// 存货自定义项6
		/// </summary>
		public string cinvdefine6 { get; set; } = string.Empty;

		/// <summary>
		/// 存货自定义项7
		/// </summary>
		public string cinvdefine7 { get; set; } = string.Empty;

		/// <summary>
		/// 存货自定义项8
		/// </summary>
		public string cinvdefine8 { get; set; } = string.Empty;

		/// <summary>
		/// 存货自定义项9
		/// </summary>
		public string cinvdefine9 { get; set; } = string.Empty;

		/// <summary>
		/// 主计量单位
		/// </summary>
		public string cinvm_unit { get; set; } = string.Empty;

		/// <summary>
		/// 存货名称
		/// </summary>
		[JsonProperty]
		public string cinvname { get; set; } = string.Empty;

		/// <summary>
		/// 对应入库单号
		/// </summary>
		public string cinvouchcode { get; set; } = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public string cinvouchtype { get; set; } = string.Empty;

		/// <summary>
		/// 规格型号
		/// </summary>
		[JsonProperty]
		public string cinvstd { get; set; } = string.Empty;

		/// <summary>
		/// 项目大类编码
		/// </summary>
		public string citem_class { get; set; } = string.Empty;

		/// <summary>
		/// 项目大类名称
		/// </summary>
		public string citemcname { get; set; } = string.Empty;

		/// <summary>
		/// 项目编码
		/// </summary>
		public string citemcode { get; set; } = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public string cmaininvcode { get; set; } = string.Empty;

		/// <summary>
		/// 保质期单位
		/// </summary>
		public string cmassunit { get; set; } = string.Empty;

		/// <summary>
		/// 项目名称
		/// </summary>
		[JsonProperty]
		public string cname { get; set; } = string.Empty;

		/// <summary>
		/// 时间戳
		/// </summary>
		public string corufts { get; set; } = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public string cplanlotcode { get; set; } = string.Empty;

		/// <summary>
		/// 订单号
		/// </summary>
		public string cpoid { get; set; } = string.Empty;

		/// <summary>
		/// 货位编码
		/// </summary>
		public string cposition { get; set; } = string.Empty;

		/// <summary>
		/// 货位
		/// </summary>
		public string cposname { get; set; } = string.Empty;

		/// <summary>
		/// 不良品处理单号
		/// </summary>
		public string crejectcode { get; set; } = string.Empty;

		/// <summary>
		/// 替换件
		/// </summary>
		public string creplaceitem { get; set; } = string.Empty;

		/// <summary>
		/// 
		public string creworkmocode { get; set; } = string.Empty;

		/// <summary>
		/// 需求跟踪号
		/// </summary>
		public string csocode { get; set; } = string.Empty;

		public string csyssourceautoid { get; set; } = string.Empty;

		/// <summary>
		/// 供应商存货编码
		/// </summary>
		public string cveninvcode { get; set; } = string.Empty;

		/// <summary>
		/// 供应商存货名称
		/// </summary>
		public string cveninvname { get; set; } = string.Empty;

		/// <summary>
		/// 供应商
		/// </summary>
		public string cvenname { get; set; } = string.Empty;

		/// <summary>
		/// 代管商代码
		/// </summary>
		public string cvmivencode { get; set; } = string.Empty;

		/// <summary>
		/// 代管商
		/// </summary>
		public string cvmivenname { get; set; } = string.Empty;

		/// <summary>
		/// 对应入库单id
		/// </summary>
		[JsonProperty]
		public long? cvouchcode { get; set; }

		public string cWhCodeforBack { get; set; } = string.Empty;

		/// <summary>
		/// 到货日期
		/// </summary>
		public string dbarvdate { get; set; } = string.Empty;

		[JsonProperty]
		public DateTime? dbkeepdate { get; set; }

		/// <summary>
		/// 检验日期
		/// </summary>
		[JsonProperty]
		public DateTime? dcheckdate { get; set; }

		/// <summary>
		/// 有效期计算项
		/// </summary>
		[JsonProperty]
		public DateTime? dexpirationdate { get; set; }

		/// <summary>
		/// 生产日期
		/// </summary>
		[JsonProperty]
		public DateTime? dmadedate { get; set; }

		/// <summary>
		/// 核销日期
		/// </summary>
		[JsonProperty]
		public DateTime? dmsdate { get; set; }

		/// <summary>
		/// 结算日期
		/// </summary>
		[JsonProperty]
		public DateTime? dsdate { get; set; }

		/// <summary>
		/// 失效日期
		/// </summary>
		[JsonProperty]
		public DateTime? dvdate { get; set; }

		/// <summary>
		/// 暂估单价
		/// </summary>
		public decimal? facost { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal? fOldQuantity { get; set; }

		[JsonProperty]
		public int? gcsourceid { get; set; }

		[JsonProperty]
		public int? gcsourceids { get; set; }

		/// <summary>
		/// 暂估金额
		/// </summary>
		public decimal? iaprice { get; set; }

		/// <summary>
		/// 采购到货单子表标识
		/// </summary>
		[JsonProperty]
		public long? iarrsid { get; set; }

		/// <summary>
		/// 累计保税处理抽取数量
		/// </summary>
		public decimal? ibondedsumqty { get; set; }

		/// <summary>
		/// 检验单子表id
		/// </summary>
		[JsonProperty]
		public long? icheckidbaks { get; set; }

		/// <summary>
		/// 检验单子表ID
		/// </summary>
		[JsonProperty]
		public long? icheckids { get; set; }

		/// <summary>
		/// 与收发记录主表关联项
		/// </summary>
		[JsonProperty]
		public long id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty]
		public int? idebitids { get; set; }

		/// <summary>
		/// 有效期推算方式
		/// </summary>
		[JsonProperty]
		public short? iexpiratdatecalcu { get; set; }

		/// <summary>
		/// 转资产数量
		/// </summary>
		public decimal? iFaQty { get; set; }

		/// <summary>
		/// 标志
		/// </summary>
		[JsonProperty]
		public byte iflag { get; set; }

		/// <summary>
		/// 实际件数
		/// </summary>
		public decimal? ifnum { get; set; }

		/// <summary>
		/// 实际数量
		/// </summary>
		public decimal? ifquantity { get; set; }

		[JsonProperty]
		public byte? igcgrouptype { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty]
		public int? iid { get; set; }

		/// <summary>
		/// iimbsid
		/// </summary>
		[JsonProperty]
		public int? iimbsid { get; set; }

		/// <summary>
		/// iimosid
		/// </summary>
		[JsonProperty]
		public int? iimosid { get; set; }

		/// <summary>
		/// 换算率
		/// </summary>
		public decimal? iinvexchrate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty]
		public double? iinvmpcost { get; set; }

		/// <summary>
		/// 序列号个数
		/// </summary>
		[JsonProperty]
		public int? iinvsncount { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty]
		public int? imainmodetailsid { get; set; }

		/// <summary>
		/// 保质期
		/// </summary>
		[JsonProperty]
		public int? imassdate { get; set; }

		/// <summary>
		/// 材料费
		/// </summary>
		public decimal? imaterialfee { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty]
		public int imatsettlestate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty]
		public int? imergecheckautoid { get; set; }

		/// <summary>
		/// 累计结算金额
		/// </summary>
		public decimal? imoney { get; set; }

		/// <summary>
		/// 最高进价
		/// </summary>
		public decimal? impcost { get; set; }

		/// <summary>
		/// 应收件数
		/// </summary>
		public decimal? innum { get; set; }

		/// <summary>
		/// 应收数量
		/// </summary>
		public decimal? inquantity { get; set; }

		/// <summary>
		/// 件数
		/// </summary>
		public decimal? inum { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty]
		public int? iOldPartId { get; set; }

		/// <summary>
		/// 委外订单子表ID
		/// </summary>
		[JsonProperty]
		public int? iomodid { get; set; }

		/// <summary>
		/// 销售订单号
		/// </summary>
		public string iordercode { get; set; } = string.Empty;

		/// <summary>
		/// iorderdid
		/// </summary>
		[JsonProperty]
		public int? iorderdid { get; set; }

		/// <summary>
		/// 销售订单行号
		/// </summary>
		[JsonProperty]
		public int? iorderseq { get; set; }

		/// <summary>
		/// 销售订单类别
		/// </summary>
		[JsonProperty]
		public byte? iordertype { get; set; }

		/// <summary>
		/// 原币单价
		/// </summary>
		public decimal? ioricost { get; set; }

		/// <summary>
		/// 原币金额
		/// </summary>
		public decimal? iorimoney { get; set; }

		/// <summary>
		/// 原币价税合计
		/// </summary>
		public decimal? iorisum { get; set; }

		/// <summary>
		/// 原币含税单价
		/// </summary>
		public decimal? ioritaxcost { get; set; }

		/// <summary>
		/// 原币税额
		/// </summary>
		public decimal? ioritaxprice { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty]
		public short? iposflag { get; set; }

		/// <summary>
		/// 订单子表ID
		/// </summary>
		[JsonProperty]
		public long? iposid { get; set; }

		/// <summary>
		/// 计划金额/售价金额
		/// </summary>
		public decimal? ipprice { get; set; }

		/// <summary>
		/// 本币金额
		/// </summary>
		public decimal? iprice { get; set; }

		/// <summary>
		/// 加工费单价
		/// </summary>
		public decimal? iprocesscost { get; set; }

		/// <summary>
		/// 加工费
		/// </summary>
		public decimal? iprocessfee { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty]
		public int iproducttype { get; set; }

		/// <summary>
		/// 计划单价/售价
		/// </summary>
		public decimal? ipunitcost { get; set; }

		/// <summary>
		/// 数量
		/// </summary>
		public decimal? iquantity { get; set; }

		/// <summary>
		/// 不良品处理单id
		/// </summary>
		[JsonProperty]
		public long? irejectids { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty]
		public int? ireworkmodetailsid { get; set; }

		/// <summary>
		/// 行号
		/// </summary>
		[JsonProperty]
		public int? irowno { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal? isharematerialfee { get; set; }

		/// <summary>
		/// 累计结算材料费
		/// </summary>
		public decimal? ismaterialfee { get; set; }

		/// <summary>
		/// 累计结算件数
		/// </summary>
		public decimal? isnum { get; set; }

		/// <summary>
		/// 销售订单子表ID
		/// </summary>
		public string isodid { get; set; } = string.Empty;

		/// <summary>
		/// 需求跟踪行号
		/// </summary>
		[JsonProperty]
		public int? isoseq { get; set; }

		/// <summary>
		/// 需求跟踪方式
		/// </summary>
		[JsonProperty]
		public byte isotype { get; set; }

		/// <summary>
		/// 累计出库件数
		/// </summary>
		public decimal? isoutnum { get; set; }

		/// <summary>
		/// 累计出库数量
		/// </summary>
		public decimal? isoutquantity { get; set; }

		/// <summary>
		/// 累计结算加工费
		/// </summary>
		public decimal? isprocessfee { get; set; }

		/// <summary>
		/// 累计结算数量
		/// </summary>
		public decimal? isquantity { get; set; }

		[JsonProperty]
		public int IsRecount { get; set; }

		/// <summary>
		/// 累计结算税额
		/// </summary>
		public decimal? isTax { get; set; }

		/// <summary>
		/// 本币价税合计
		/// </summary>
		public decimal? isum { get; set; }

		/// <summary>
		/// 累计开票数量
		/// </summary>
		public decimal? isumbillquantity { get; set; }

		/// <summary>
		/// 税额
		/// </summary>
		public decimal? itax { get; set; }

		/// <summary>
		/// 本币税额
		/// </summary>
		public decimal? itaxprice { get; set; }

		/// <summary>
		/// 税率
		/// </summary>
		public decimal? itaxrate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal? iuninvsncount { get; set; }

		/// <summary>
		/// 本币单价
		/// </summary>
		public decimal? iunitcost { get; set; }

		/// <summary>
		/// 代管挂账确认单件数
		/// </summary>
		public decimal? ivmisettlenum { get; set; }

		/// <summary>
		/// 代管挂账确认单数量
		/// </summary>
		public decimal? ivmisettlequantity { get; set; }

		/// <summary>
		/// 不合格品时间戳
		/// </summary>
		public string scrapufts { get; set; } = string.Empty;

		/// <summary>
		/// 合同标的编码
		/// </summary>
		public string strcode { get; set; } = string.Empty;

		/// <summary>
		/// 合同号
		/// </summary>
		public string strcontractid { get; set; } = string.Empty;

		/// <summary>
		/// rowguid
		/// </summary>
		[JsonProperty]
		public Guid? strowguid { get; set; }
        public double? avaInQuantity { get; set; }
		public double? avaInNum { get; set; }
        public string taskguid { get; set; }
    }

}
