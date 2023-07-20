using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.U8API.Model
{
    /// <summary>
    /// 检验单
    /// </summary>
    public class QMCheckVoucher : QMCheck
    {
        public List<QMChecks> Detail { get; set; }
    }
}
