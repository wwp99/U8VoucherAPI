using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.U8API.Model
{
    public class rd11
    {
        /// <summary>
        /// 出库单号
        /// </summary>
        public string ccode { get; set; }

        /// <summary>
        /// 出库日期
        /// </summary>
        public string ddate { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary>
        public string cbustype { get; set; }


        /// <summary>
        /// 出库类别
        /// </summary>
        public string crdcode { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string cmemo { get; set; }


        /// <summary>
        /// 制单人
        /// </summary>
        public string cmaker { get; set; }


        /// <summary>
        /// 单据来源
        /// </summary>
        public string csource { get; set; }

        /// <summary>
        /// 收发标志
        /// </summary>
        public int brdflag { get; set; } = 0;

        /// <summary>
        /// 委外商编码
        /// </summary>
        public string cvencode { get; set; }

        /// <summary>
        /// 单据类型
        /// </summary>
        public string cvouchtype { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public string cwhcode { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string cdepcode { get; set; }

        /// <summary>
        /// 业务员
        /// </summary>
        public string cpersoncode { get; set; }

        /// <summary>
        /// 单据模板号
        /// </summary>
        public int vt_id { get; set; }

    }
}
