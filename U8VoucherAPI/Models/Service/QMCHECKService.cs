using MSXML2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U8Login;
using U8VoucherAPI.Models;
using ZR.U8API;
using ZR.U8API.Model;

namespace ZR.WMS.Business
{
    /// <summary>
    /// 检验单业务
    /// </summary>
    public class QMCHECKService
    {

        /// <summary>
        /// WPS上传
        /// </summary>
        /// <param name="data"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public string AddVouche1(object data, LogHelp l)
        {
            try
            {
                Dictionary<string, object> di = (Dictionary<string, object>)data;
                string accNum = di["accNum"].ToString();

                string database = "UFDATA_998_2014";

                string sql = $" select a.ID 报检单主表ID,b.AUTOID 报检单子表ID,a.CSOURCECODE 来源单号,a.CSOURCEID 来源主表ID,b.SOURCEAUTOID 来源子表ID,a.CSOURCE 来源单据类型,c.cpocode 采购订单号,c.dDate 到货日期,a.CMAKER 报检人,c.cVenCode 供应商编码,b.CINVCODE 存货编码,b.FQUANTITY 报检数量,a.CDEPCODE 报检部门,i.iTestStyle 检验方式,i.cInvName 存货名称,v.cVenName 供应商名称 from {database}..QMINSPECTVOUCHER a inner join {database}..QMINSPECTVOUCHERS b on b.ID=a.ID inner join {database}..PU_ArrivalVouch c on c.cCode=a.CSOURCECODE inner join {database}..Inventory i on i.cInvCode=b.CINVCODE inner join {database}..Vendor v on v.cVenCode=a.CVENCODE where a.CINSPECTCODE='{di["cinspectcode"]}' ";
                DataTable dt = null;
                DB.RunProcDataTable(sql, ref dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        QMCheckVoucher qc = new QMCheckVoucher();
                        qc.ccheckcode = di["ccheckcode"].ToString();
                        //qc.cdepcode = di["cdepcode"].ToString();
                        qc.cinspectcode = di["cinspectcode"].ToString();
                        qc.ddate = di["ddate"].ToString();
                        qc.checkguid = Guid.NewGuid().ToString();
                        qc.cvouchtype = "QM03";
                        qc.inspectid = dt.Rows[i]["报检单主表ID"].ToString();
                        qc.inspectautoid = dt.Rows[i]["报检单子表ID"].ToString();
                        qc.sourcecode = dt.Rows[i]["来源单号"].ToString();
                        qc.sourceid = dt.Rows[i]["来源子表ID"].ToString();
                        qc.sourceautoid = dt.Rows[i]["来源主表ID"].ToString();
                        qc.csource = dt.Rows[i]["来源子表ID"].ToString();
                        qc.cpocode = dt.Rows[i]["采购订单号"].ToString();
                        qc.cinspectdepcode = dt.Rows[i]["报检部门"].ToString();
                        qc.darrivaldate = dt.Rows[i]["到货日期"].ToString();
                        qc.cinspectperson = dt.Rows[i]["报检人"].ToString();
                        qc.ctime = DateTime.Now.ToString("HH:mm:ss");
                        qc.cvencode = dt.Rows[i]["供应商编码"].ToString();
                        qc.cvenname = dt.Rows[i]["供应商名称"].ToString();
                        qc.cinvcode = dt.Rows[i]["存货编码"].ToString();
                        qc.cinvname = dt.Rows[i]["存货名称"].ToString();
                        qc.ivtid = 353;
                        qc.cchecktypecode = "ARR";
                        qc.projectid = "0000000002";
                        qc.fquantity = Convert.ToDecimal(dt.Rows[i]["报检数量"]);
                        qc.cmaker = "吴伟鹏";
                        qc.iteststyle= dt.Rows[i]["检验方式"].ToString();


                        List<Dictionary<string, object>> bodys = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(di["bodys"].ToString());
                        foreach (Dictionary<string, object> body in bodys)
                        {
                            foreach (var key in body)
                            {
                                if (key.Key == qc.cinvcode)
                                {
                                    qc.fregquantity = Convert.ToDecimal(key.Value);
                                }
                                break;
                            }
                        }

                        sql = $" select a.CDEPCODE 检验部门编码,a.CCHECKPERSONCODE 检验员编码,d.cDepName 检验部门名称,p.cPersonName 检验员,b.CCHKGUIDECODE 检验指标编码,b.CCHKITEMCODE 检验项目编码,b.BGUIDETYPE 标准值类型,b.CSTANDARD 标准值,b.IUPPERLIMIT 上限值,b.ILOWERLIMIT 下限值,b.CBUGGRADE 检验缺陷等级,b.FUPPERWARP 上偏差,b.FLOWERWARP 下偏差 from {database}..QMCHECKPROJECT a inner join {database}..QMCHECKPROJECTS b on b.ID=a.ID left join {database}..Department d on d.cDepCode=a.CDEPCODE left join {database}..Person p on p.cPersonCode=a.CCHECKPERSONCODE where a.CPROJECTCODE='{qc.projectid}' ";
                        DataTable dt1 = null;
                        DB.RunProcDataTable(sql, ref dt1);
                        if (dt1.Rows.Count > 0)
                        {
                            qc.cdepcode = dt1.Rows[0]["检验部门编码"].ToString();
                            qc.cdepname = dt1.Rows[0]["检验部门名称"].ToString();
                            qc.ccheckpersoncode = dt1.Rows[0]["检验员编码"].ToString();                        
                            qc.ccheckpersonname = dt1.Rows[0]["检验员"].ToString();                        
                        }

                        List<QMChecks> qclist = new List<QMChecks>();
                        for (int j = 0; j < dt1.Rows.Count; j++)
                        {
                            QMChecks qcs = new QMChecks();
                            qcs.cchkguidecode= dt1.Rows[i]["检验指标编码"].ToString();
                            qcs.cchkitemcode= dt1.Rows[i]["检验项目编码"].ToString();
                            qcs.cstandard = Convert.ToDecimal(dt1.Rows[i]["标准值"]);
                            qcs.fupperlimit = Convert.ToDecimal(dt1.Rows[i]["上限值"]);
                            qcs.flowerlimit = Convert.ToDecimal(dt1.Rows[i]["下限值"]);
                            qcs.fquideregquantity = Convert.ToDecimal(qc.fregquantity);
                            qcs.ccheckvalue = Convert.ToDecimal(dt1.Rows[i]["标准值"]);
                            qcs.fupperwarp = Convert.ToDecimal(dt1.Rows[i]["上偏差"]);
                            qcs.flowerwarp = Convert.ToDecimal(dt1.Rows[i]["下偏差"]);
                            qcs.ftargetqty = Convert.ToDecimal(qc.fquantity);
                            qcs.cbuggrade = dt1.Rows[i]["检验缺陷等级"].ToString();
                            qcs.fgquantity = Convert.ToDecimal(qc.fquantity);
                            qclist.Add(qcs);
                        }
                        qc.Detail = qclist;

                        string msg = Add(accNum,qc);
                        if (string.IsNullOrEmpty(msg))
                            continue;
                    }
                }
                else
                {
                    return "检验单不存在！";
                }

                return "";
            }
            catch (Exception ex)
            {
                l.Error("生成失败：" + ex.Message + ex.StackTrace, ex);
                return "生成失败：" + ex.Message;
            }
        }


        public string Add(string accNum,QMCheckVoucher data)
        {
            try
            {
                string U8DataBase = "UFDATA_998_2014";

                clsLogin u8login = new clsLogin();

                u8login.Login(U8LoginInfo.SubId, accNum, Convert.ToDateTime("2015-12-12").Year.ToString(), U8LoginInfo.UserId, U8LoginInfo.Password, Convert.ToDateTime("2015-12-12").ToString("yyyy-MM-dd"));

                //1、单据模板对象
                UFQMVOCom.clsVoucherVO qmvo = new UFQMVOCom.clsVoucherVO();

                //2、单据方法对象
                //UFQMCo.clsArrInspectCO QMCo = new UFQMCo.clsArrInspectCO();//报检单
                UFQMCo.clsArrCheckCO QMCo = new UFQMCo.clsArrCheckCO();//检验单


                //3、获取模板
                QMCo.GetTheVoucher(u8login, ref qmvo, 2,353);


                #region 组装数据

                //IXMLDOMDocument2 defpos = new DOMDocument();
                //4、获取单据头，单据体
                IXMLDOMDocument2 head = qmvo.domHead;
                IXMLDOMDocument2 body = qmvo.domBody;

                string a = head.xml;
                string b = body.xml;

                //5、head,body赋值过程
                IXMLDOMDocument2 bodycheck = new DOMDocument();
                bodycheck.loadXML(body.xml);
                if (data.Detail == null || data.Detail.Count == 0)
                    return "检验单保存失败：表体数据不能为空";

                //组装表头DOM
                QMCheck qc = data;
                IXMLDOMNode node = head.selectNodes("//rs:data")[0];
                for (int i = node.childNodes.length - 1; i >= 0; i--)
                {
                    node.removeChild(node.childNodes[i]);
                }
                IXMLDOMElement element = head.createElement("z:row");
                //foreach (PropertyInfo item in typeof(QMCheck).GetProperties())
                //{
                //    element.setAttribute(item.Name, item.GetValue(qc, null));
                //}
                element.setAttribute("CCHECKCODE", qc.ccheckcode);
                element.setAttribute("CINSPECTCODE", qc.cinspectcode);
                element.setAttribute("DDATE", qc.ddate);
                element.setAttribute("CHECKGUID", qc.checkguid);
                element.setAttribute("CVOUCHTYPE", qc.cvouchtype);
                element.setAttribute("INSPECTAUTOID", qc.inspectautoid);
                element.setAttribute("SOURCECODE", qc.sourcecode);
                element.setAttribute("SOURCEAUTOID", qc.sourceid);
                element.setAttribute("SOURCEID", qc.sourceautoid);
                element.setAttribute("CSOURCE", qc.csource);
                element.setAttribute("CPOCODE", qc.cpocode);
                element.setAttribute("CINSPECTDEPCODE", qc.cinspectdepcode);
                element.setAttribute("DARRIVALDATE", qc.darrivaldate);
                element.setAttribute("CINSPECTPERSON", qc.cinspectperson);
                element.setAttribute("CTIME", qc.ctime);
                element.setAttribute("CVENCODE", qc.cvencode);
                element.setAttribute("CVENNAME", qc.cvenname);
                element.setAttribute("CINVCODE", qc.cinvcode);
                element.setAttribute("CINVNAME", qc.cinvname);
                element.setAttribute("IVTID", qc.ivtid);
                element.setAttribute("CCHECKTYPECODE", qc.cchecktypecode);
                element.setAttribute("PROJECTID", qc.projectid);
                element.setAttribute("CPROJECTCODE", qc.projectid);
                element.setAttribute("FQUANTITY", qc.fquantity);
                element.setAttribute("CDEPCODE", qc.cdepcode);
                element.setAttribute("CDEPNAME", qc.cdepname);
                element.setAttribute("CCHECKPERSONCODE", qc.ccheckpersoncode);
                element.setAttribute("CCHECKPERSONNAME", qc.ccheckpersonname);
                element.setAttribute("FREGQUANTITY", qc.fregquantity);
                element.setAttribute("CMAKER", qc.cmaker);
                element.setAttribute("ITESTSTYLE", qc.iteststyle);
                element.setAttribute("ISWFCONTROLLED", 0);

                node.appendChild(element);
                //组装表体DOM

                node = body.selectNodes("//rs:data")[0];
                for (int i = node.childNodes.length - 1; i >= 0; i--)
                {
                    node.removeChild(node.childNodes[i]);
                }
                foreach (QMChecks s in data.Detail)
                {
                    //bodycheck.selectSingleNode("//rs:data").removeChild(bodycheck.selectSingleNode("//z:row"));
                    element = bodycheck.createElement("z:row");
                    //foreach (PropertyInfo item in typeof(QMChecks).GetProperties())
                    //{
                    //    element.setAttribute(item.Name, item.GetValue(s, null));
                    //}
                    //bodycheck.selectSingleNode("//rs:data").appendChild(element);
                    element.setAttribute("CCHKGUIDECODE", s.cchkguidecode);
                    element.setAttribute("CCHKITEMCODE", s.cchkitemcode);
                    element.setAttribute("CSTANDARD", s.cstandard);
                    element.setAttribute("FUPPERLIMIT", s.fupperlimit);
                    element.setAttribute("FLOWERLIMIT", s.flowerlimit);
                    element.setAttribute("FQUIDEREGQUANTITY", s.fquideregquantity);
                    element.setAttribute("CCHECKVALUE", s.ccheckvalue);
                    element.setAttribute("FUPPERWARP", s.fupperwarp);
                    element.setAttribute("FLOWERWARP", s.flowerwarp);
                    element.setAttribute("FTARGETQTY", s.ftargetqty);
                    element.setAttribute("CBUGGRADE", s.cbuggrade);
                    element.setAttribute("FGQUANTITY", s.fgquantity);
                    element.setAttribute("BGUIDETYPE", 1);
                    element.setAttribute("editprop", "A");

                    node.appendChild(element);
                }

                string c = head.xml;
                string d = body.xml;

                //6、qmvo赋值
                qmvo.InitByXml(head, body);

                #endregion
                //7、调用方法
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
    }
}
