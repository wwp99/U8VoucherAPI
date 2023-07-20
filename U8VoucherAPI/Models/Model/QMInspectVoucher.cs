using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.U8API.Model
{
    public class QMInspectVoucher: QMInspect
    {
        public List<QMInspects> Detail { get; set; }
    }
}
