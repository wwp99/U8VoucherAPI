using ADODB;
using MSXML2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZR.U8API;

namespace U8VoucherAPI.Models
{
    public class PU
    {
        VoucherCO_PU.clsVoucherCO_PU PuCo = null;
        Connection conn = null;

        public PU()
        {
            //初始化
            if (Util.u8login == null)
                Util.InitLogin();
            conn = new Connection();
            conn.Open(U8LoginInfo.ConnectionStringVB);
        }
        public void Init(VoucherTypePU voucherType)
        {
            if (PuCo == null)
            {
                VoucherVerify.UseMode usMode = VoucherVerify.UseMode.CS;
                PuCo = new VoucherCO_PU.clsVoucherCO_PU();
                Info_PU.ClsS_Infor infor = new Info_PU.ClsS_Infor();
                infor.Init(Util.u8login);
                PuCo.bOutTrans = true;
                switch (voucherType)
                {
                    case VoucherTypePU.采购请购单:
                        PuCo.Init(VoucherCO_PU.vouchertype.采购请购单, Util.u8login, conn, infor);
                        break;
                    case VoucherTypePU.采购订单:
                        PuCo.Init(VoucherCO_PU.vouchertype.采购订单, Util.u8login, conn, infor);
                        break;
                    case VoucherTypePU.采购到货单:
                        PuCo.Init(VoucherCO_PU.vouchertype.采购到货单, Util.u8login, conn, infor,true,"0","普通采购", usMode,"","");
                        break;
                    case VoucherTypePU.采购入库单:
                        break;
                    case VoucherTypePU.采购发票:
                        break;
                    case VoucherTypePU.采购结算单:
                        break;
                    case VoucherTypePU.PU_STSettle:
                        break;
                    case VoucherTypePU.PU_ManSettle:
                        break;
                    case VoucherTypePU.VMIUsedVouch:
                        break;
                    case VoucherTypePU.供应商资格审批:
                        break;
                    case VoucherTypePU.供应商供货审批:
                        break;
                    case VoucherTypePU.PU_FYSettle:
                        break;
                    case VoucherTypePU.PU_AutoSettle:
                        break;
                    case VoucherTypePU.OM_ManSettle:
                        break;
                    case VoucherTypePU.OM_FYSettle:
                        break;
                    case VoucherTypePU.供应商存货调价单:
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 获取单据默认模板
        /// </summary>
        /// <param name="CardNum">单据模板号</param>
        /// <param name="domHead">表头</param>
        /// <param name="domBody">表体</param>
        public void GetDefaultDOM( ref IXMLDOMDocument2 domHead, ref IXMLDOMDocument2 domBody)
        {
            PuCo.GetVoucherData(ref domHead, ref domBody, "", "-1");
        }

        /// <summary>
        /// 获取单据数据
        /// </summary>
        /// <param name="ID">单据ID</param>
        /// <param name="domHead">表头</param>
        /// <param name="domBody">表体</param>
        public void GetVoucherData(string ID,ref IXMLDOMDocument2 domHead, ref IXMLDOMDocument2 domBody)
        {
            PuCo.GetVoucherData(ref domHead, ref domBody, "", ID);
        }

        public string HeadCheck(string sKey, ref IXMLDOMDocument2 domHead, ref IXMLDOMDocument2 domBody)
        {
            return PuCo.HeadCheck(sKey, ref domHead, ref domBody);
        }

        public string BodyCheck(string sKey, ref IXMLDOMDocument2 domBody, ref IXMLDOMDocument2 domHead, int R = -1)
        {
            if (R == -1)
                return PuCo.BodyCheck(sKey, ref domBody, ref domHead);
            else
                return PuCo.BodyCheck(sKey, ref domBody, ref domHead, R);
        }

        /// <summary>
        /// 保存并审核订单
        /// </summary>
        /// <param name="domHead">单据头</param>
        /// <param name="domBody">单据体</param>
        /// <returns></returns>
        public string SaveVerifyVoucher(IXMLDOMDocument2 domHead, IXMLDOMDocument2 domBody, out string Id,out string cCode, out IXMLDOMDocument2 DomConfig, Action<int> action = null)
        {
            Id = "-1";
            cCode = "";
            DomConfig = null;
            try
            {
                IXMLDOMDocument2 head = domHead;
                IXMLDOMDocument2 body = domBody;

                object NewId = "-1";

                string msg = "";
                conn.BeginTrans();
                msg = PuCo.VoucherSave(head, body, 2, ref NewId, ref DomConfig);

                Id = NewId == null ? "-1" : NewId.ToString();

                if (string.IsNullOrEmpty(msg))
                {
                    //成功处理方法
                    try
                    {
                        //msg = GetVoucherData(ref domHead, ref domBody, Id);
                        //if (!string.IsNullOrEmpty(msg) || domHead == null)
                        //    throw new Exception("未找到订单；" + msg);

                        msg = VerifyVouch(ref domHead);
                        if (!string.IsNullOrEmpty(msg))
                            throw new Exception("审核订单失败：" + msg);

                        string sql = "SELECT cCode FROM dbo.PU_ArrivalVouch WHERE ID="+Id;
                        ADODB.Command command = new ADODB.Command();
                        command.ActiveConnection = conn;
                        command.CommandText = sql;
                        command.CommandType = CommandTypeEnum.adCmdText;
                        Recordset recordset = command.Execute(out object affect);
                        if (!recordset.EOF && !recordset.BOF)
                        {
                            recordset.MoveFirst();
                            cCode = recordset.Fields["cCode"].Value;
                        }

                        if (action != null)
                            action(int.Parse(Id));
                        conn.CommitTrans();
                        return "";
                    }
                    catch (Exception ex)
                    {
                        conn.RollbackTrans();
                        return ex.Message;
                    }

                }
                else
                {
                    conn.RollbackTrans();
                    return msg;
                }
            }
            catch (Exception ex)
            {
                return "保存单据失败：" + ex.Message;
            }
        }
       
        /// <summary>
        /// 审核订单
        /// </summary>
        /// <param name="domHead">表头DOM</param>
        /// <returns></returns>
        public string VerifyVouch(ref IXMLDOMDocument2 domHead)
        {
            try
            {
                //Init(VoucherTypeSA.SODetails);
                string msg = "";
                msg = PuCo.ConfirmArr(domHead);
                if (string.IsNullOrEmpty(msg))
                {
                    //成功处理方法
                    return "";
                }
                else
                    return msg;
            }
            catch (Exception ex)
            {
                return "审核单据失败：" + ex.Message;
            }
        }

        /// <summary>
        /// 审核订单
        /// </summary>
        /// <param name="domHead">表头DOM</param>
        /// <returns></returns>
        public string UnVerifyVouchPo(ref IXMLDOMDocument2 domHead)
        {
            try
            {
                string msg = "";
                msg = PuCo.CancelconfirmPO(domHead);
                if (string.IsNullOrEmpty(msg))
                {
                    //成功处理方法
                    return "";
                }
                else
                    return msg;
            }
            catch (Exception ex)
            {
                return "审核单据失败：" + ex.Message;
            }
        }
    }
}
