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
	/// 其它入库单主表
	/// </summary>
	public partial class kcotherinh {
         
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty]
		public bool? biafirst { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty]
		public bool? bislsquery { get; set; }

		/// <summary>
		/// 库存期初标记
		/// </summary>
		[JsonProperty]
		public bool bisstqc { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty]
		public int bomfirst { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty]
		public bool? bpufirst { get; set; }

		/// <summary>
		/// 收发标志
		/// </summary>
		[JsonProperty]
		public byte brdflag { get; set; }

		/// <summary>
		/// 记账人
		/// </summary>
		public string caccounter { get; set; } = string.Empty;

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
		/// 入库单号
		/// </summary>
		public string ccode { get; set; } = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public string ccurrentauditor { get; set; } = string.Empty;

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
		[JsonProperty]
		public int? cdefine15 { get; set; }

		/// <summary>
		/// 表头自定义项16
		/// </summary>
		[JsonProperty]
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
		[JsonProperty]
		public DateTime? cdefine4 { get; set; }

		/// <summary>
		/// 表头自定义项5
		/// </summary>
		[JsonProperty]
		public int? cdefine5 { get; set; }

		/// <summary>
		/// 表头自定义项6
		/// </summary>
		[JsonProperty]
		public DateTime? cdefine6 { get; set; }

		/// <summary>
		/// 表头自定义项7
		/// </summary>
		[JsonProperty]
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
		/// 部门编码
		/// </summary>
		public string cdepcode { get; set; } = string.Empty;

		/// <summary>
		/// 部门
		/// </summary>
		[JsonProperty]
		public string cdepname { get; set; } = string.Empty;

		public string cfactorycode { get; set; } = string.Empty;

		[JsonProperty]
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
		[JsonProperty]
		public string cmemo { get; set; } = string.Empty;

		/// <summary>
		/// 修改人
		/// </summary>
		public string cmodifyperson { get; set; } = string.Empty;

		/// <summary>
		/// 业务员编码
		/// </summary>
		public string cpersoncode { get; set; } = string.Empty;

		/// <summary>
		/// 业务员
		/// </summary>
		public string cpersonname { get; set; } = string.Empty;

		/// <summary>
		/// 入库类别编码
		/// </summary>
		public string crdcode { get; set; } = string.Empty;

		/// <summary>
		/// 入库类别
		/// </summary>
		public string crdname { get; set; } = string.Empty;

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
		/// 供应商
		/// </summary>
		public string cvenabbname { get; set; } = string.Empty;

		/// <summary>
		/// 供应商编码
		/// </summary>
		public string cvencode { get; set; } = string.Empty;

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
		/// 
		/// </summary>
		[JsonProperty]
		public DateTime? darvdate { get; set; }

		/// <summary>
		/// 检验日期
		/// </summary>
		[JsonProperty]
		public DateTime? dchkdate { get; set; }

		/// <summary>
		/// 入库日期
		/// </summary>
		[JsonProperty]
		public string ddate { get; set; }

		/// <summary>
		/// 修改日期
		/// </summary>
		[JsonProperty]
		public DateTime? dmodifydate { get; set; }

		/// <summary>
		/// 制单时间
		/// </summary>
		[JsonProperty]
		public DateTime? dnmaketime { get; set; }

		/// <summary>
		/// 修改时间
		/// </summary>
		[JsonProperty]
		public DateTime? dnmodifytime { get; set; }

		/// <summary>
		/// 审核时间
		/// </summary>
		[JsonProperty]
		public DateTime? dnverifytime { get; set; }

		/// <summary>
		/// 审核日期
		/// </summary>
		[JsonProperty]
		public DateTime? dveridate { get; set; }

		/// <summary>
		/// ID
		/// </summary>
		[JsonProperty]
		public long id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty]
		public double? imquantity { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty]
		public int? iPrintCount { get; set; }

		/// <summary>
		/// ireturncount
		/// </summary>
		[JsonProperty]
		public int? ireturncount { get; set; }

		/// <summary>
		/// iswfcontrolled
		/// </summary>
		[JsonProperty]
		public int? iswfcontrolled { get; set; }

		/// <summary>
		/// iverifystate
		/// </summary>
		[JsonProperty]
		public int? iverifystate { get; set; }

		/// <summary>
		/// 时间戳
		/// </summary>
		public string ufts { get; set; } = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty]
		public int? vendoriid { get; set; }

		/// <summary>
		/// 模版号
		/// </summary>
		[JsonProperty]
		public int? vt_id { get; set; }

	}

}
