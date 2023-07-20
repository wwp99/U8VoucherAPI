using ADODB;
using MSXML2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U8Login;
using U8VoucherAPI.Models;
using USERPCO;
using ZR.U8API;
using ZR.U8API.Model;

namespace ZR.WMS.Business
{
    /// <summary>
    /// 盘点单业务
    /// </summary>
    public class CheckService
    {
        public string AddVouche(object data, LogHelp l)
        {
            try
            {
                
                

                Dictionary<string, object> di = (Dictionary<string, object>)data;
                CheckVoucher c = new CheckVoucher();
                c.ccvcode = di["ccvcode"].ToString();
                c.dcvdate = di["dcvdate"].ToString();
                c.cdepcode = di["cdepcode"].ToString();
                //c.cpersoncode = di["cpersoncode"].ToString();
                c.cirdcode = di["cirdcode"].ToString();
                c.cordcode = di["cordcode"].ToString();
                c.cwhcode = di["cwhcode"].ToString();
                c.ccvmemo = di["ccvmemo"].ToString();
                c.dacdate = di["dacdate"].ToString();
                c.cmaker = di["cmaker"].ToString();
                c.vt_id = "29";
                c.csource = "1";
                c.ccvtype = "普通仓库盘点";

                List<Dictionary<string, object>> bodys = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(di["bodys"].ToString());

                //List<Dictionary<string, object>> bodys = (List<Dictionary<string, object>>)di["bodys"];
                List<Checks> list = new List<Checks>();
                foreach (Dictionary<string, object> body in bodys)
                {
                    Checks ts = new Checks();
                    ts.ccvcode = di["ccvcode"].ToString();
                    ts.cinvcode = body["cinvcode"].ToString();
                    //ts.icvquantity = Convert.ToDecimal(body["icvquantity"]);
                    ts.icvcquantity = Convert.ToDecimal(body["icvcquantity"]);
                    ts.ijhdj = Convert.ToDecimal(body["ijhdj"]);
                    ts.isjje = Convert.ToDecimal(body["isjje"]);
                    ts.iadinquantity = Convert.ToDecimal(body["iadinquantity"]);
                    ts.iadoutquantity = Convert.ToDecimal(body["iadoutquantity"]);
                    ts.cposition = (body["cposition"]).ToString();
                    ts.ccvbatch = (body["ccvbatch"]).ToString();
                    ts.iActualWaste = (body["iActualWaste"]).ToString();

                    list.Add(ts);
                }

                c.Detail = list;

                string accNum = di["accNum"].ToString();
                string msg = Add(c, accNum);
                if (!string.IsNullOrEmpty(msg))
                    return msg;
                else
                    return "";
            }
            catch (Exception ex)
            {
                l.Error("新增失败：" + ex.Message + ex.StackTrace, ex);
                return "新增失败：" + ex.Message + ex.StackTrace;
            }
        }


        public string Add(CheckVoucher data, string accNum)
        {
            try
            {
                clsLogin u8login = new clsLogin();

                    u8login.Login(U8LoginInfo.SubId, accNum, "2015", U8LoginInfo.UserId, U8LoginInfo.Password, Convert.ToDateTime("2015-12-12").ToString());



                Connection conn = new Connection();
                conn.Open(u8login.UfDbName);

                VoucherCO StCo = new USERPCO.VoucherCO();
                string errmsg = "";
                StCo.IniLogin(u8login, ref errmsg);


                IXMLDOMDocument2 head = new DOMDocument();
                IXMLDOMDocument2 body = new DOMDocument();
                IXMLDOMDocument2 pos = new DOMDocument();

                //盘点单单据模板
                StCo.GetDefaultVoucherDom("18", "0307", ref head, ref body, ref pos, ref errmsg);
                //组装表头DOM
                IXMLDOMNode node = head.selectNodes("//rs:data")[0];
                Check c = data;
                for (int i = node.childNodes.length - 1; i >= 0; i--)
                {
                    node.removeChild(node.childNodes[i]);
                }
                IXMLDOMElement element = head.createElement("z:row");
                element.setAttribute("ccvcode", c.ccvcode);
                element.setAttribute("dcvdate", c.dcvdate);
                element.setAttribute("cdepcode", c.cdepcode);
                element.setAttribute("cpersoncode", c.cpersoncode);
                element.setAttribute("cirdcode", c.cirdcode);
                element.setAttribute("cordcode", c.cordcode);
                element.setAttribute("cwhcode", c.cwhcode);
                element.setAttribute("ccvmemo", c.ccvmemo);
                element.setAttribute("dacdate", c.dacdate);
                element.setAttribute("cmaker", c.cmaker);
                element.setAttribute("vt_id", c.vt_id);
                element.setAttribute("csource", c.csource);
                element.setAttribute("ccvtype", c.ccvtype);

                //element.setAttribute("fornet", "1");
                node.appendChild(element);

                node = body.selectNodes("//rs:data")[0];
                for (int i = node.childNodes.length - 1; i >= 0; i--)
                {
                    node.removeChild(node.childNodes[i]);
                }
                element = body.createElement("z:row");
                foreach (Checks cs in data.Detail)
                {
                    element.setAttribute("ccvcode", cs.ccvcode);
                    element.setAttribute("cinvcode", cs.cinvcode);
                    //element.setAttribute("icvquantity", cs.icvquantity);
                    element.setAttribute("icvcquantity", cs.icvcquantity);
                    element.setAttribute("ijhdj", cs.ijhdj);
                    element.setAttribute("isjje", cs.isjje);
                    element.setAttribute("iadinquantity", cs.iadinquantity);
                    element.setAttribute("iadoutquantity", cs.iadoutquantity);
                    element.setAttribute("cposition", cs.cposition);
                    element.setAttribute("ccvbatch", cs.ccvbatch);
                    element.setAttribute("iactualwaste", cs.iActualWaste);

                    element.setAttribute("editprop", "A");
                    node.appendChild(element);
                }

                string ss = body.xml;
                string Id = "";
                pos = new DOMDocument();

                try
                {
                    //if (StCo.Insert("18", head, body, pos, ref errmsg, ref conn, ref Id))
                    //{
                    //    if (StCo.Verify("18", Id, ref errmsg))
                    //    {
                    //        return "";
                    //    }
                    //    else
                    //    {
                    //        string msg = errmsg;
                    //        return "审核错误：" + msg;
                    //    }
                    //}
                    //else
                    //{

                    //    return "保存错误：" + errmsg;
                    //}
                    return "";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
    }
}
