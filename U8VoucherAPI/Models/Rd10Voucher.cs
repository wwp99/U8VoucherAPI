using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U8VoucherAPI.Models
{
    /// <summary>
    /// 产成品入库单
    /// </summary>
    public class Rd10Voucher:rd10
    {
        public List<rds10> Detail { get; set; }
    }
}