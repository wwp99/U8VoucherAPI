using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZR.U8API.Model
{
    /// <summary>
    /// 其他出库
    /// </summary>
    public class kcotherout : kcotherouth
    {
        public List<kcotheroutb> Detail { get; set; }
    }
}
