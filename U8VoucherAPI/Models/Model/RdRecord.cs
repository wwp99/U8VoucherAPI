using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZR.U8API.Model
{
    /// <summary>
    /// 采购/委外入库
    /// </summary>
    public class RdRecord : RdRecord01
    {
        public List<rdrecords01> Detail { get; set; }
    }
}
