using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.U8API.Model
{
    /// <summary>
    /// 盘点单主表
    /// </summary>
    public class Check
    {
        /// <summary>
        /// 盘点单号
        /// </summary>
        public string ccvcode { get; set; }

        /// <summary>
        /// 盘点日期
        /// </summary>
        public string dcvdate { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string  cdepcode { get; set; }

        /// <summary>
        /// 业务员
        /// </summary>
        public string cpersoncode { get; set; }

        /// <summary>
        /// 入库类别
        /// </summary>
        public string cirdcode { get; set; }

        /// <summary>
        /// 出库类别
        /// </summary>
        public string cordcode { get; set; }

        /// <summary>
        /// 盘点仓库
        /// </summary>
        public string cwhcode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string ccvmemo { get; set; }

        /// <summary>
        /// 制单人
        /// </summary>
        public string cmaker { get; set; }

        /// <summary>
        /// 账面日期
        /// </summary>
        public string dacdate { get; set; }

        /// <summary>
        /// 单据模板号
        /// </summary>
        public string vt_id { get; set; }

        /// <summary>
        /// 盘点类型
        /// </summary>
        public string ccvtype { get; set; }

        /// <summary>
        /// csource   1
        /// </summary>
        public string csource { get; set; }

    }
}
