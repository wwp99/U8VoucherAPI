using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.U8API.Model
{
    /// <summary>
    /// 检验单子表
    /// </summary>
    public  class QMChecks
    {
        /// <summary>
        /// 标准值类型
        /// </summary>
        public int bguidetype { get; set; }

        /// <summary>
        /// 检验项目编码
        /// </summary>
        public string cchkitemcode { get; set; }

        /// <summary>
        /// 检验指标编码
        /// </summary>
        public string cchkguidecode { get; set; }

        /// <summary>
        /// 标准值
        /// </summary>
        public decimal cstandard { get; set; }

        /// <summary>
        /// 上限值
        /// </summary>
        public decimal fupperlimit { get; set; }

        /// <summary>
        /// 下限值
        /// </summary>
        public decimal flowerlimit { get; set; }

        /// <summary>
        /// 检验指标单位
        /// </summary>
        public string cguideunit { get; set; }

        /// <summary>
        /// 检验合格数量
        /// </summary>
        public decimal fquideregquantity { get; set; }

        /// <summary>
        /// 检验不合格数量
        /// </summary>
        public decimal fquidedisquantity { get; set; }


        /// <summary>
        /// 检验日期
        /// </summary>
        public string dcheckdate { get; set; }

        /// <summary>
        /// 检验时间
        /// </summary>
        public string cchecktime { get; set; }

        /// <summary>
        /// 检验值 （标准值一致）
        /// </summary>
        public decimal ccheckvalue { get; set; }

        /// <summary>
        /// 指标检验数量 （与检验数量一致）
        /// </summary>
        public decimal ftargetqty { get; set; }

        /// <summary>
        /// 检验缺陷等级 (0-严重,1-重要,2-一般 )
        /// </summary>
        public string cbuggrade { get; set; }

        /// <summary>
        /// 指标质量判定
        /// </summary>
        public string ctargetqjug { get; set; }

        /// <summary>
        /// 上偏差
        /// </summary>
        public decimal fupperwarp { get; set; }

        /// <summary>
        /// 下偏差
        /// </summary>
        public decimal flowerwarp { get; set; }

        /// <summary>
        /// 指标检验组编码
        /// </summary>
        public string cgroupcode { get; set; }

        /// <summary>
        /// 指标计量单位编码
        /// </summary>
        public string cgcomunitcode { get; set; }

        /// <summary>
        /// 指标报检量 （与数量一致）
        /// </summary>
        public decimal fgquantity { get; set; }

        /// <summary>
        /// 指标换算率
        /// </summary>
        public decimal fgchangerate { get; set; }

        /// <summary>
        /// 指标单位抽检量 （与数量一致）
        /// </summary>
        public decimal fchkquantity { get; set; }

        /// <summary>
        /// 检验合格数 （与检验合格数量一致）
        /// </summary>
        public decimal fchkvalidqty { get; set; }

        /// <summary>
        /// 检验不合格数 （与检验不合格数量一致）
        /// </summary>
        public decimal fchkinvalidqty { get; set; }

        public int bmustcheck { get; set; } = 1;
    }
}
