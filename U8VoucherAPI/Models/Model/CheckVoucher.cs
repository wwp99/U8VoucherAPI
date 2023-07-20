using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.U8API.Model
{
    /// <summary>
    /// 盘点单
    /// </summary>
    public class CheckVoucher : Check
    {
        /// <summary>
        /// 明细
        /// </summary>
        public List<Checks> Detail { get; set; }
    }
}
