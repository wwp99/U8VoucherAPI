using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZR.U8API;

using ZR.U8API.Model;
using Newtonsoft.Json;
using MSXML2;
using U8VoucherAPI.Models;

namespace ZR.WMS.Business
{
    public class PUArrivalService
    {
        /// <summary>
        /// WMS上传
        /// </summary>
        /// <param name="AccId"></param>
        /// <param name="data"></param>
        /// <param name="l"></param>
        /// <param name="username"></param>
        /// <param name="DocNo"></param>
        /// <param name="IsDev"></param>
        /// <returns></returns>
        public string AddVouche2(object data,out string code)
        {
            code = "";
            try
            {
                Dictionary<string, object> di = (Dictionary<string, object>)data;

                //string accNum = di["accNum"].ToString();
                //string U8DataBase = 

                //PUArrivalVouch p = new PUArrivalVouch();
                //p.ccode = di["cCode"].ToString();
                //p.cvencode = di["cVenCode"].ToString();
                //p.cdepcode = di["cDepCode"].ToString();
                //p.cpersoncode = di["cPersonCode"].ToString();
                //p.cpocode = di["cpocode"].ToString();
                //p.ddate = Convert.ToDateTime(di["dDate"]);


                List<Dictionary<string, object>> bodys = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(di["bodys"].ToString());
                //List<pu_ArrBody> list = new List<pu_ArrBody>();
                //foreach (var body in bodys)
                //{
                //    pu_ArrBody ps = new pu_ArrBody();
                //    ps.cinvcode = body["cInvCode"].ToString();
                //    ps.itaxrate = Convert.ToDecimal(body["iTaxRate"].ToString());
                //    ps.iquantity = Convert.ToDecimal(body["iQuantity"].ToString());
                //    ps.ioritaxcost = Convert.ToDecimal(body["iOriTaxCost"].ToString());
                //    ps.ioricost = Convert.ToDecimal(body["iOriCost"].ToString());
                //    ps.ioritaxprice = Convert.ToDecimal(body["iOriTaxPrice"].ToString());
                //    ps.iorimoney = Convert.ToDecimal(body["iOriMoney"].ToString());
                //    ps.iorisum = Convert.ToDecimal(body["iOriSum"].ToString());
                //    ps.iposid = Convert.ToInt32(body["iPOsID"]);
                //    ps.cbatch = body["cBatch"].ToString();
                //    ps.bgsp = body["bGsp"].ToString() == "是" ? 1 : 0;
                //    list.Add(ps);
                //}
                //p.Detail = list;

                string msg = SaveVouch1(di,bodys,out code);
                if (!string.IsNullOrEmpty(msg))
                    return msg;
                else
                    return "";

            }
            catch (Exception ex)
            {
                return "新增失败：" + ex.Message;
            }
        }


        public string SaveVouch1(Dictionary<string,object> di, List<Dictionary<string, object>> bodys,out string cCode) 
        {
            cCode = "";
            string U8DataBase = "UFDATA_998_2014";

            try
            {
                string sql = "";
                    U8LoginInfo.Date = "2015-" + DateTime.Now.ToString("MM-dd");
                    U8LoginInfo.YearId = "2015";


                U8LoginInfo.AccId = di["accNum"].ToString(); ;
                PU pu = new PU();
                pu.Init(VoucherTypePU.采购到货单);

                IXMLDOMDocument2 defpos = new DOMDocument();

                IXMLDOMDocument2 head = new DOMDocument();
                IXMLDOMDocument2 body = new DOMDocument();
                IXMLDOMDocument2 body1 = new DOMDocument();

                pu.GetDefaultDOM(ref head, ref body);
                //pu.GetVoucherData("1000000028", ref head, ref body1);
                //string hxml = head.xml;
                //string bxml = body.xml;

                if (bodys == null || bodys.Count == 0)
                    return "采购到货单保存失败：表体数据不能为空";

                IXMLDOMDocument2 bodycheck = new DOMDocument();
                bodycheck.loadXML(body.xml);

                //pu_ArrHead hdto = data;
                IXMLDOMNode node = head.selectNodes("//rs:data")[0];
                for (int i = node.childNodes.length - 1; i >= 0; i--)
                {
                    node.removeChild(node.childNodes[i]);
                }
                IXMLDOMElement element = head.createElement("z:row");
                //foreach (PropertyInfo item in typeof(pu_ArrHead).GetProperties())
                //{
                //    object o = item.GetValue(hdto, null);
                //    if (o != null && item.Name.Contains("cdefine"))
                //        element.setAttribute(item.Name, o);
                //}
                element.setAttribute("ivtid", "8169");
                //element.setAttribute("ufts", "");
                element.setAttribute("ddate", di["ddate"]);
                //element.setAttribute("id", "");
                element.setAttribute("ccode", di["ccode"]);
                element.setAttribute("cptcode", di["cptcode"]);
                //element.setAttribute("cptname", "普通采购");
                element.setAttribute("cvencode", di["cvencode"]);
                //element.setAttribute("cvenname", "华帝");
                //element.setAttribute("cvenabbname", "华帝股份有限公司");
                element.setAttribute("cdepcode", di["cdepcode"]);
                //element.setAttribute("cdepname", "采购部");
                //element.setAttribute("cexch_code", "RMB");
                element.setAttribute("cexch_name", di["cexch_name"]);
                element.setAttribute("itaxrate", di["itaxrate"]);
                element.setAttribute("editprop", "");
                element.setAttribute("iswfcontrolled", 0);
                element.setAttribute("bstoragearrivalorder", 0);
                element.setAttribute("iexchrate", di["iexchrate"]);
                element.setAttribute("cbustype", di["cbustype"]);
                element.setAttribute("cmaker", di["cmaker"]);
                element.setAttribute("bnegative", "0");
                element.setAttribute("idiscounttaxtype", "0");
                element.setAttribute("ibilltype", "0");
                element.setAttribute("iverifystateex", "0");
                element.setAttribute("iflowid", "0");
                element.setAttribute("iprintcount", "0");
                element.setAttribute("cpocode", di["cpocode"]);
                
                node.appendChild(element);

                node = body.selectNodes("//rs:data")[0];
                for (int i = node.childNodes.length - 1; i >= 0; i--)
                {
                    node.removeChild(node.childNodes[i]);
                }
                foreach (var dis in bodys)
                {
                    element = bodycheck.createElement("z:row");
                    //foreach (PropertyInfo item in typeof(pu_ArrBody).GetProperties())
                    //{
                    //    element.setAttribute(item.Name, item.GetValue(s, null));
                    //}
                    bodycheck.selectSingleNode("//rs:data").appendChild(element);

                    //st.BodyCheckInsert("01", "iorisum", ref bodycheck, ref head);
                    //string aaaa = bodycheck.xml;
                    sql = "  exec " + U8DataBase + "..ST_GetInventoryVO  N'" + dis["cinvcode"].ToString() + "',N'',1 ";
                    DataTable dt = null;
                    DB.RunProcDataTable(sql, ref dt);
                    if (dt.Rows.Count == 0)
                    {
                        //l.Warn("存货：" + s.cinvcode + "不存在");
                        return "存货：" + dis["cinvcode"].ToString() + "不存在";
                    }
                    element.setAttribute("cinvcode", dis["cinvcode"]);
                    element.setAttribute("iposid", dis["iposid"]);
                    element.setAttribute("itaxrate", dis["itaxrate"]);
                    element.setAttribute("bgsp", dis["bgsp"]);
                    element.setAttribute("iquantity", dis["iquantity"]);

                    element.setAttribute("cunitid", dt.Rows[0]["cProductUnit"].ToString());
                    element.setAttribute("cinvname", dt.Rows[0]["cinvname"].ToString());
                    element.setAttribute("cinvstd", dt.Rows[0]["cinvstd"].ToString());
                    element.setAttribute("iinvexchrate", dt.Rows[0]["iChangRate"].ToString());
                    if (dt.Rows[0]["iChangRate"] != DBNull.Value)
                        element.setAttribute("inum", Convert.ToDecimal(dis["iquantity"]) / Convert.ToDecimal(dt.Rows[0]["iChangRate"]));

                    element.setAttribute("cbatch", dis["cbatch"]);
                    element.setAttribute("editprop", "A");


                    node.appendChild(element);
                }

                //foreach (IXMLDOMElement item in head.selectNodes("//z:row"))
                //{
                //    item.setAttribute("id", "");
                //    item.setAttribute("ccode", "111111");
                //}

                string hxml = head.xml;
                string bxml = body.xml;


                return pu.SaveVerifyVoucher(head, body, out string Id, out cCode, out IXMLDOMDocument2 DomConfig);

            }
            catch (Exception ex)
            {
                return "保存到货单失败：" + ex.Message;
            }
        }

        public string AuditVouche(string code)
        {
            throw new NotImplementedException();
        }

        public string AuditVouche(int ID)
        {
            throw new NotImplementedException();
        }

        public string DeleteVouche(string code)
        {
            throw new NotImplementedException();
        }

        public string DeleteVouche(int ID)
        {
            throw new NotImplementedException();
        }

        public string UnAuditVouche(string code)
        {
            throw new NotImplementedException();
        }

        public string UnAuditVouche(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
