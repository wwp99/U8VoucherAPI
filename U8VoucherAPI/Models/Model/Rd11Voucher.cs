using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.U8API.Model
{
    public class Rd11Voucher:rd11
    {
        public List<rds11> Detail { get; set; }
    }
}
