using MSXML2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using U8VoucherAPI.Models;
using ZR.U8API.Model;

namespace ZR.WMS.Business
{
    /// <summary>
    /// 材料出库单业务
    /// </summary>
    public class Rd11VoucherService
    {
        /// <summary>
        /// WMS上传
        /// </summary>
        /// <param name="data"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public string AddVouche(object data, LogHelp l)
        {
            try
            {
                Dictionary<string, object> di = (Dictionary<string, object>)data;
                Rd11Voucher r = new Rd11Voucher();
                r.ccode = di["ccode"].ToString();
                r.ddate = Convert.ToDateTime(di["ddate"]).ToString("yyyy-MM-dd");
                r.cwhcode = di["cwhcode"].ToString();
                r.crdcode = di["crdcode"].ToString();
                r.cdepcode = di["cdepcode"].ToString();
                r.cmaker = di["cmaker"].ToString();
                r.vt_id = 65;
                r.cvouchtype = "11";


                List<Dictionary<string, object>> bodys = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(di["bodys"].ToString());

                List<rds11> rslist = new List<rds11>();
                foreach (Dictionary<string, object> body in bodys)
                {
                    rds11 rs = new rds11();
                    rs.cinvcode = body["cinvcode"].ToString();//存货编码
                    if (!string.IsNullOrEmpty(body["iunitcost"].ToString()))
                    {
                        rs.iunitcost = Convert.ToDecimal(body["iunitcost"]);//单价
                    }
                    if (!string.IsNullOrEmpty(body["iprice"].ToString()))
                    {
                        rs.iprice = Convert.ToDecimal(body["iprice"]);//金额
                    }
                    rs.iquantity = Convert.ToDecimal(body["iquantity"]);//数量
                    rs.cbatch = body["cbatch"].ToString();//批次
                    rs.cposition = body["cposition"].ToString();//货位
                    rs.imaids= body["imaids"].ToString();//领料申请子表ID
                    rslist.Add(rs);
                }
                r.Detail = rslist;

                string accNum = di["accNum"].ToString();
                string msg = Rd11_Add(accNum, r);
                if (!string.IsNullOrEmpty(msg))
                    return msg;
                else
                    return "";
            }
            catch(Exception ex)
            {
                l.Error("生成失败：" + ex.Message + ex.StackTrace, ex);
                return "生成失败：" + ex.Message;
            }
        }

        public string Rd11_Add(string accNum,Rd11Voucher data)
        {
            try
            {

                object login = null;


                login = Util.U8Login(accNum, Convert.ToDateTime("2015-12-12"));


                data.csource = "领料申请单";
                data.cbustype = "领料";
                data.brdflag = 0;

                #region 组装数据
                ST st = null;
                //if (!CacheHelper.Exists("test"))
                //{
                st = new ST(login);
                //CacheHelper.Set("test", st);
                //}
                //else
                //st = CacheHelper.Get<ST>("test");

                IXMLDOMDocument2 defpos = new DOMDocument();

                IXMLDOMDocument2 head = new DOMDocument();
                IXMLDOMDocument2 body = new DOMDocument();

                st.GetDefaultDOM("11", "0412", ref head, ref body, ref defpos);

                IXMLDOMDocument2 bodycheck = new DOMDocument();
                bodycheck.loadXML(body.xml);
                if (data.Detail == null || data.Detail.Count == 0)
                    return "材料出库单保存失败：表体数据不能为空";

                string guid = Guid.NewGuid().ToString().Replace("-", "");
                //组装表头DOM
                Rd11Voucher inq = data;
                //inq.cmemo = guid;
                IXMLDOMNode node = head.selectNodes("//rs:data")[0];
                for (int i = node.childNodes.length - 1; i >= 0; i--)
                {
                    node.removeChild(node.childNodes[i]);
                }
                IXMLDOMElement element = head.createElement("z:row");
                foreach (PropertyInfo item in typeof(rd11).GetProperties())
                {
                    element.setAttribute(item.Name, item.GetValue(inq, null));
                }
                //element.setAttribute("bWireless", "1");
                node.appendChild(element);
                //组装表体DOM

                node = body.selectNodes("//rs:data")[0];
                for (int i = node.childNodes.length - 1; i >= 0; i--)
                {
                    node.removeChild(node.childNodes[i]);
                }
                foreach (rds11 s in data.Detail)
                {
                    //bodycheck.selectSingleNode("//rs:data").removeChild(bodycheck.selectSingleNode("//z:row"));
                    element = bodycheck.createElement("z:row");
                    foreach (PropertyInfo item in typeof(rds11).GetProperties())
                    {
                        element.setAttribute(item.Name, item.GetValue(s, null));
                    }
                    bodycheck.selectSingleNode("//rs:data").appendChild(element);
                    //lisp.Clear();
                    //lisp.Add(new SqlParameter("@cinvcode", s.cinvcode));
                    //sql = "  exec " + U8DataBase + "..ST_GetInventoryVO  @cinvcode,N'',1 ";
                    //DataTable dt = null;
                    //DB.RunProcDataTable(sql, ref dt, lisp);
                    //if (dt.Rows.Count == 0)
                    //{
                    //    l.Warn("存货：" + s.cinvcode + "不存在");
                    //    return "存货：" + s.cinvcode + "不存在";
                    //}
                    //element.setAttribute("cassunit", dt.Rows[0]["cProductUnit"].ToString());
                    //element.setAttribute("cinvname", dt.Rows[0]["cinvname"].ToString());
                    //element.setAttribute("cinvstd", dt.Rows[0]["cinvstd"].ToString());
                    //element.setAttribute("iinvexchrate", dt.Rows[0]["iChangRate"].ToString());
                    //if (dt.Rows[0]["iChangRate"] != DBNull.Value)
                    //    element.setAttribute("inum", s.iquantity / Convert.ToDecimal(dt.Rows[0]["iChangRate"]));

                    //foreach (IXMLDOMNode item in element.attributes)
                    //{
                    //    if (item.nodeName == "iinvexchrate")
                    //    {
                    //        if (item.nodeValue != null && !string.IsNullOrEmpty(item.nodeValue))
                    //            element.setAttribute("inum", s.iquantity / Convert.ToDecimal(item.nodeValue));
                    //    }
                    //    if (dt.Columns.Contains(item.nodeName))
                    //        element.setAttribute(item.nodeName, dt.Rows[0][item.nodeName].ToString());
                    //    if (item.nodeName == "cassunit")
                    //        element.setAttribute(item.nodeName, dt.Rows[0]["cProductUnit"].ToString());
                    //}

                    //st.BodyCheckInsert("08", "cinvcode", ref bodycheck, ref head);
                    //IXMLDOMElement element1 = bodycheck.selectSingleNode("//z:row") as IXMLDOMElement;
                    //string aa = element1.xml;
                    //foreach (IXMLDOMNode item in element1.attributes)
                    //{
                    //    if (item.nodeName == "iinvexchrate")
                    //    {
                    //        if (item.nodeValue != null && !string.IsNullOrEmpty(item.nodeValue))
                    //            element.setAttribute("inum", s.iquantity / Convert.ToDecimal(item.nodeValue));
                    //    }
                    //    element.setAttribute(item.nodeName, item.nodeValue);
                    //}

                    element.setAttribute("editprop", "A");
                    element.setAttribute("cbatch", s.cbatch);

                    node.appendChild(element);
                }
                defpos = new DOMDocument();
                #endregion
                string xml = body.xml;
                string ss = st.SaveVerifyVoucher("11", head, body, defpos, out string Id, out IXMLDOMDocument2 DomConfig);
                if (!string.IsNullOrEmpty(ss))
                {
                    return ss;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return "材料出库单出现错误！" + ex.Message;
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
