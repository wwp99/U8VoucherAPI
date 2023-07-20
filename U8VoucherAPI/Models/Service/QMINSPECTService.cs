using ADODB;
using MSXML2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using U8Login;
using U8VoucherAPI.Models;
using ZR.U8API;
using ZR.U8API.Model;

namespace ZR.WMS.Business
{
    public class QMINSPECTService
    {

        /// <summary>
        /// WMS上传
        /// </summary>
        /// <param name="data"></param>
        /// <param name="l"></param>
        /// <param name="DocNo"></param>
        /// <returns></returns>
        public string AddVouche1(object data, LogHelp l)
        {
            try
            {
                Dictionary<string, object> di = (Dictionary<string, object>)data;
                QMInspectVoucher qi = new QMInspectVoucher();
                //qi.inspectguid = di["inspectguid"].ToString();
                qi.inspectguid = Guid.NewGuid().ToString();
                qi.cinspectcode = di["cinspectcode"].ToString();
                qi.cvouchtype = di["cvouchtype"].ToString();
                qi.csourcecode = di["csourcecode"].ToString();
                qi.csourceid = di["csourceid"].ToString();
                qi.darrivaldate = di["darrivaldate"].ToString();
                qi.ddate = di["ddate"].ToString();
                qi.cdepcode = di["cdepcode"].ToString();
                qi.cinspectdepcode = di["cinspectdepcode"].ToString();
                qi.cvencode = di["cvencode"].ToString();
                //qi.ctime = di["ctime"].ToString();
                qi.ctime = DateTime.Now.ToString("HH:mm:ss");
                qi.csource = di["csource"].ToString();
                qi.ivtid = di["ivtid"].ToString();
                qi.cchecktypecode = di["cchecktypecode"].ToString();
                qi.cmaker = di["cmaker"].ToString();


                List<Dictionary<string, object>> bodys = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(di["bodys"].ToString());
                List<QMInspects> list = new List<QMInspects>();
                foreach (Dictionary<string, object> body in bodys)
                {
                    QMInspects qis = new QMInspects();
                    qis.cinvcode = body["cinvcode"].ToString();
                    qis.iteststyle = body["iteststyle"].ToString();
                    qis.sourceautoid = body["sourceautoid"].ToString();
                    qis.fquantity = Convert.ToDecimal(body["fquantity"]);
                    qis.cpocode = body["cpocode"].ToString();
                    list.Add(qis);
                }
                qi.Detail = list;

                string accNum = di["accNum"].ToString();
                string msg = Add(accNum, qi);
                if (!string.IsNullOrEmpty(msg))
                    return msg;
                else
                    return "";
            }
            catch (Exception ex)
            {
                l.Error("生成失败：" + ex.Message + ex.StackTrace, ex);
                return "生成失败：" + ex.Message;
            }
        }

        public string Add(string accNum, QMInspectVoucher data)
        {
            try
            {


                clsLogin u8login = new clsLogin();

                u8login.Login(U8LoginInfo.SubId, accNum, Convert.ToDateTime("2015-12-12").Year.ToString(), U8LoginInfo.UserId, U8LoginInfo.Password, Convert.ToDateTime("2015-12-12").ToString("yyyy-MM-dd"));

                //1、单据模板对象
                UFQMVOCom.clsVoucherVO qmvo = new UFQMVOCom.clsVoucherVO();

                //2、单据方法对象
                UFQMCo.clsArrInspectCO QMCo = new UFQMCo.clsArrInspectCO();//报检单
                //UFQMCo.clsArrCheckCO QMCo = new UFQMCo.clsArrCheckCO();//检验单               

                //3、获取模板
                QMCo.GetTheVoucher(u8login, ref qmvo, 16, 351);
                //QMCo.GetTheVoucher(u8login, ref qmvo, 15,351);
                //and CVOUCHTYPE='QM01'

                #region 组装数据

                //IXMLDOMDocument2 defpos = new DOMDocument();
                //4、获取单据头，单据体
                IXMLDOMDocument2 head = qmvo.domHead;
                IXMLDOMDocument2 body = qmvo.domBody;


                string c = head.xml;
                string d = body.xml;


                //5、head,body赋值过程
                IXMLDOMDocument2 bodycheck = new DOMDocument();
                bodycheck.loadXML(body.xml);
                if (data.Detail == null || data.Detail.Count == 0)
                    return "报检保存失败：表体数据不能为空";

                //组装表头DOM
                QMInspect qi = data;
                IXMLDOMNode node = head.selectNodes("//rs:data")[0];
                for (int i = node.childNodes.length - 1; i >= 0; i--)
                {
                    node.removeChild(node.childNodes[i]);
                }
                IXMLDOMElement element = head.createElement("z:row");
                //foreach (PropertyInfo item in typeof(QMInspect).GetProperties())
                //{
                //    element.setAttribute(item.Name, item.GetValue(qi, null));
                //}
                element.setAttribute("CINSPECTCODE", qi.cinspectcode);
                element.setAttribute("INSPECTGUID", qi.inspectguid);
                element.setAttribute("CVOUCHTYPE", qi.cvouchtype);
                element.setAttribute("CSOURCE", qi.csource);
                element.setAttribute("CSOURCEID", qi.csourceid);
                element.setAttribute("CSOURCECODE", qi.csourcecode);
                element.setAttribute("DARRIVALDATE", qi.darrivaldate);
                element.setAttribute("DDATE", qi.ddate);
                element.setAttribute("CDEPCODE", qi.cdepcode);
                element.setAttribute("CINSPECTDEPCODE", qi.cinspectdepcode);
                element.setAttribute("CVENCODE", qi.cvencode);
                element.setAttribute("CTIME", qi.ctime);
                element.setAttribute("IVTID", qi.ivtid);
                element.setAttribute("CCHECKTYPECODE", qi.cchecktypecode);
                element.setAttribute("CMAKER", qi.cmaker);
                element.setAttribute("UFTS", "                      784.8338");

                //UPDATE pu_arrivalvouch SET cmaker = cmaker WHERE ID = 1000000022 AND CONVERT(char,Convert(money,Ufts),2)=N''

                node.appendChild(element);

                //组装表体DOM

                node = body.selectNodes("//rs:data")[0];
                for (int i = node.childNodes.length - 1; i >= 0; i--)
                {
                    node.removeChild(node.childNodes[i]);
                }
                foreach (QMInspects s in data.Detail)
                {
                    //bodycheck.selectSingleNode("//rs:data").removeChild(bodycheck.selectSingleNode("//z:row"));
                    element = bodycheck.createElement("z:row");
                    //foreach (PropertyInfo item in typeof(QMInspects).GetProperties())
                    //{
                    //    element.setAttribute(item.Name, item.GetValue(s, null));
                    //}
                    element.setAttribute("CINVCODE", s.cinvcode);
                    element.setAttribute("ITESTSTYLE", s.iteststyle);
                    element.setAttribute("SOURCEAUTOID", s.sourceautoid);
                    element.setAttribute("FQUANTITY", s.fquantity);
                    element.setAttribute("CPOCODE", s.cpocode);
                    element.setAttribute("editprop", "A");
                    //bodycheck.selectSingleNode("//rs:data").appendChild(element);
                    node.appendChild(element);
                }

                string a = head.xml;
                string b = body.xml;

                //6、qmvo赋值
                qmvo.InitByXml(head, body);

                #endregion
                //7、调用方法
                //bool msg = QMCo.AddNewVoucher(u8login, qmvo);
                bool msg = QMCo.AddVoucher(u8login, qmvo);
                if (msg)
                {
                    return "";
                }
                else
                {
                    return "报检单新增失败";
                }
            }
            catch (Exception ex)
            {
                return "报检单出现错误！" + ex.Message;
            }
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
