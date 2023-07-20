using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.U8API.Model
{
    /// <summary>
    /// 调拨单
    /// </summary>
    public class Tran:TransVouch
    {
        public List<TransVouchs> Detail { get; set; }
    }
}
