
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ZR.U8API.Model
{ 


	/// <summary>
	/// 其它出库单主表
	/// </summary>
	public partial class kcotherouth {
         
		/// <summary>
		/// 存货期初
		/// </summary>
		public bool? biafirst { get; set; }

		/// <summary>
		/// 库存期初
		/// </summary>
		public bool bisstqc { get; set; }

		/// <summary>
		/// 委外期初
		/// </summary>
		public int bomfirst { get; set; }

		/// <summary>
		/// 采购期初
		/// </summary>
		public bool? bpufirst { get; set; }

		/// <summary>
		/// 收发标志
		/// </summary>
		public byte brdflag { get; set; }

		/// <summary>
		/// 记账人
		/// </summary>
		public string caccounter { get; set; } = string.Empty;

		/// <summary>
		/// 发货地址编码
		/// </summary>
		public string caddcode { get; set; } = string.Empty;

		/// <summary>
		/// 预算审批人
		/// </summary>
		public string cbg_auditor { get; set; } = string.Empty;

		/// <summary>
		/// 预算审批时间
		/// </summary>
		public string cbg_audittime { get; set; } = string.Empty;

		/// <summary>
		/// 业务号
		/// </summary>
		public string cbuscode { get; set; } = string.Empty;

		/// <summary>
		/// 业务类型
		/// </summary>
		public string cbustype { get; set; } = string.Empty;

		public string cchecksignflag { get; set; } = string.Empty;

		/// <summary>
		/// 检验单号
		/// </summary>
		public string cchkcode { get; set; } = string.Empty;

		/// <summary>
		/// 检验员
		/// </summary>
		public string cchkperson { get; set; } = string.Empty;

		/// <summary>
		/// 出库单号
		/// </summary>
		public string ccode { get; set; } = string.Empty;

		/// <summary>
		/// 收货单位联系人
		/// </summary>
		public string ccontactname { get; set; } = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public string ccurrentauditor { get; set; } = string.Empty;

		/// <summary>
		/// 客户
		/// </summary>
		public string ccusabbname { get; set; } = string.Empty;

		/// <summary>
		/// 客户地址
		/// </summary>
		public string ccusaddress { get; set; } = string.Empty;

		/// <summary>
		/// 客户编码
		/// </summary>
		public string ccuscode { get; set; } = string.Empty;

		/// <summary>
		/// 客户手机
		/// </summary>
		public string ccushand { get; set; } = string.Empty;

		/// <summary>
		/// 客户联系人
		/// </summary>
		public string ccusperson { get; set; } = string.Empty;

		/// <summary>
		/// 客户电话
		/// </summary>
		public string ccusphone { get; set; } = string.Empty;

		/// <summary>
		/// 表头自定义项1
		/// </summary>
		public string cdefine1 { get; set; } = string.Empty;

		/// <summary>
		/// 表头自定义项10
		/// </summary>
		public string cdefine10 { get; set; } = string.Empty;

		/// <summary>
		/// 表头自定义项11
		/// </summary>
		public string cdefine11 { get; set; } = string.Empty;

		/// <summary>
		/// 表头自定义项12
		/// </summary>
		public string cdefine12 { get; set; } = string.Empty;

		/// <summary>
		/// 表头自定义项13
		/// </summary>
		public string cdefine13 { get; set; } = string.Empty;

		/// <summary>
		/// 表头自定义项14
		/// </summary>
		public string cdefine14 { get; set; } = string.Empty;

		/// <summary>
		/// 表头自定义项15
		/// </summary>
		public int? cdefine15 { get; set; }

		/// <summary>
		/// 表头自定义项16
		/// </summary>
		public double? cdefine16 { get; set; }

		/// <summary>
		/// 表头自定义项2
		/// </summary>
		public string cdefine2 { get; set; } = string.Empty;

		/// <summary>
		/// 表头自定义项3
		/// </summary>
		public string cdefine3 { get; set; } = string.Empty;

		/// <summary>
		/// 表头自定义项4
		/// </summary>
		public DateTime? cdefine4 { get; set; }

		/// <summary>
		/// 表头自定义项5
		/// </summary>
		public int? cdefine5 { get; set; }

		/// <summary>
		/// 表头自定义项6
		/// </summary>
		public DateTime? cdefine6 { get; set; }

		/// <summary>
		/// 表头自定义项7
		/// </summary>
		public double? cdefine7 { get; set; }

		/// <summary>
		/// 表头自定义项8
		/// </summary>
		public string cdefine8 { get; set; } = string.Empty;

		/// <summary>
		/// 表头自定义项9
		/// </summary>
		public string cdefine9 { get; set; } = string.Empty;

		/// <summary>
		/// 收货单位
		/// </summary>
		public string cdeliverunit { get; set; } = string.Empty;

		/// <summary>
		/// 部门编码
		/// </summary>
		public string cdepcode { get; set; } = string.Empty;

		/// <summary>
		/// 部门
		/// </summary>
		public string cdepname { get; set; } = string.Empty;

		public string cfactorycode { get; set; } = string.Empty;

		public string cfactoryname { get; set; } = string.Empty;

		/// <summary>
		/// 审核人
		/// </summary>
		public string chandler { get; set; } = string.Empty;

		/// <summary>
		/// 序列号
		/// </summary>
		public string chinvsn { get; set; } = string.Empty;

		/// <summary>
		/// 制单人
		/// </summary>
		public string cmaker { get; set; } = string.Empty;

		/// <summary>
		/// 备注
		/// </summary>
		public string cmemo { get; set; } = string.Empty;

		/// <summary>
		/// 收货单位联系人手机
		/// </summary>
		public string cmobilephone { get; set; } = string.Empty;

		/// <summary>
		/// 修改人
		/// </summary>
		public string cmodifyperson { get; set; } = string.Empty;

		/// <summary>
		/// 收货单位联系人电话
		/// </summary>
		public string cofficephone { get; set; } = string.Empty;

		/// <summary>
		/// 客户联系人手机
		/// </summary>
		public string contactmobile { get; set; } = string.Empty;

		/// <summary>
		/// 客户联系人电话
		/// </summary>
		public string contactphone { get; set; } = string.Empty;

		/// <summary>
		/// controlresult
		/// </summary>
		public short? controlresult { get; set; }

		/// <summary>
		/// 业务员编码
		/// </summary>
		public string cpersoncode { get; set; } = string.Empty;

		/// <summary>
		/// 业务员
		/// </summary>
		public string cpersonname { get; set; } = string.Empty;

		/// <summary>
		/// 业务员手机
		/// </summary>
		public string cpsnmobilephone { get; set; } = string.Empty;

		/// <summary>
		/// 业务员电话
		/// </summary>
		public string cpsnophone { get; set; } = string.Empty;

		/// <summary>
		/// 出库类别编码
		/// </summary>
		public string crdcode { get; set; } = string.Empty;

		/// <summary>
		/// 出库类别
		/// </summary>
		public string crdname { get; set; } = string.Empty;

		/// <summary>
		/// 发货地址
		/// </summary>
		public string cshipaddress { get; set; } = string.Empty;

		/// <summary>
		/// 单据来源
		/// </summary>
		public string csource { get; set; } = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public string csourcecodels { get; set; } = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public string csourcels { get; set; } = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public string csysbarcode { get; set; } = string.Empty;

		public string csyssource { get; set; } = string.Empty;

		public string csyssourceid { get; set; } = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public string ctransflag { get; set; } = string.Empty;

		/// <summary>
		/// 客户权限id
		/// </summary>
		public string CusiId { get; set; } = string.Empty;

		/// <summary>
		/// 单据类型
		/// </summary>
		public string cvouchname { get; set; } = string.Empty;

		/// <summary>
		/// 单据类型编码
		/// </summary>
		public string cvouchtype { get; set; } = string.Empty;

		/// <summary>
		/// 仓库编码
		/// </summary>
		public string cwhcode { get; set; } = string.Empty;

		/// <summary>
		/// 仓库
		/// </summary>
		public string cwhname { get; set; } = string.Empty;

		/// <summary>
		/// 到货日期
		/// </summary>
		public DateTime? darvdate { get; set; }

		/// <summary>
		/// 检验日期
		/// </summary>
		public DateTime? dchkdate { get; set; }

		/// <summary>
		/// 出库日期
		/// </summary>
		public string ddate { get; set; }

		/// <summary>
		/// 修改日期
		/// </summary>
		public DateTime? dmodifydate { get; set; }

		/// <summary>
		/// 制单时间
		/// </summary>
		public DateTime? dnmaketime { get; set; }

		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime? dnmodifytime { get; set; }

		/// <summary>
		/// 审核时间
		/// </summary>
		public DateTime? dnverifytime { get; set; }

		/// <summary>
		/// 审核日期
		/// </summary>
		public DateTime? dveridate { get; set; }

		/// <summary>
		/// 预算审批状态
		/// </summary>
		public short? ibg_overflag { get; set; }

		/// <summary>
		/// ID
		/// </summary>
		public long id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public double? imquantity { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? iPrintCount { get; set; }

		/// <summary>
		/// ireturncount
		/// </summary>
		public int? ireturncount { get; set; }

		/// <summary>
		/// iswfcontrolled
		/// </summary>
		public int? iswfcontrolled { get; set; }

		/// <summary>
		/// iverifystate
		/// </summary>
		public int? iverifystate { get; set; }

		/// <summary>
		/// 时间戳
		/// </summary>
		public string ufts { get; set; } = string.Empty;

		/// <summary>
		/// 模版号
		/// </summary>
		public int? vt_id { get; set; }

	}

}
