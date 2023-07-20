using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.U8API.Model
{
    /// <summary>
    /// 调拨单主表
    /// </summary>
    public class TransVouch
    {
        /// <summary>
        /// 调拨单单号
        /// </summary>
        public string cTVCode { get; set; }

        /// <summary>
        /// 单据日期
        /// </summary>
        public string dTVDate { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary>
        public string cbustype { get; set; }

        /// <summary>
        /// 转出仓库编码
        /// </summary>
        public string cOWhCode { get; set; }

        /// <summary>
        /// 转入仓库编码
        /// </summary>
        public string cIWhCode { get; set; }

        /// <summary>
        /// 转出部门编码
        /// </summary>
        public string cODepCode { get; set; }

        /// <summary>
        /// 转入部门编码
        /// </summary>
        public string cIDepCode { get; set; }

        /// <summary>
        /// 制单人
        /// </summary>
        public string cMaker { get; set; }

        /// <summary>
        /// 制单日期
        /// </summary>
        public DateTime dnmaketime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string cModifyPerson { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime dModifyDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string cTVMemo { get; set; }
    }
}
