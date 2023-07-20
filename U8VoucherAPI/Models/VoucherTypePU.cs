using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U8VoucherAPI.Models
{
    public enum VoucherTypePU
    {
        采购请购单 = 0,
        采购订单 = 1,
        采购到货单 = 2,
        采购入库单 = 3,
        采购发票 = 4,
        采购结算单 = 5,
        PU_STSettle = 6,
        PU_ManSettle = 7,
        VMIUsedVouch = 8,
        供应商资格审批 = 9,
        供应商供货审批 = 10,
        PU_FYSettle = 11,
        PU_AutoSettle = 12,
        OM_ManSettle = 13,
        OM_FYSettle = 14,
        供应商存货调价单 = 15
    }
}
