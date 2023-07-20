using ADODB;
using MSXML2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using U8Login;
using ZR.U8API;

namespace U8VoucherAPI.Models
{
    /// <summary>
    /// 产成品入库单业务
    /// </summary>
    public class Rd10VoucherService
    {
        /// <summary>
        /// 新增产成品入库单
        /// </summary>
        /// <param name="ds_sequence">账套号</param>
        /// <param name="momordercode">生产订单号</param>
        /// <returns></returns>
        public string Save(string ds_sequence, string momordercode, Rd10Voucher rd10)
        {
            return "";
            //try
            //{

            //    string sql = $" select cDatabase from UA_AccountDatabase where cAcc_Id='{ds_sequence}' ";
            //    string u8zt = DB.RunProcScalar(sql);
            //    if (string.IsNullOrEmpty(u8zt))
            //        return "账套不存在！";

            //    string selectmd = $" select MoID from mom_order where MoCode ='{momordercode}'  ";
            //    string moid = DB.RunProcScalar(selectmd);//生产订单主表ID
            //    if (string.IsNullOrEmpty(moid))
            //        return "生产订单不存在！";

            //    //测试数据 赋值
            //    //表头
            //    rd10.cVouchType = "10";
            //    rd10.cBusType = "成品入库";
            //    rd10.cSource = "生产订单";
            //    rd10.cWhCode = "36";
            //    rd10.dDate = DateTime.Now.ToString("yyyy-MM-dd");
            //    //rd10.cCode = "0000000012";//自动编号
            //    rd10.cRdCode = "12";
            //    rd10.cDepCode = "0502";
            //    rd10.cMaker = "demo";
            //    rd10.VT_ID = 63;
            //    rd10.cMPoCode = momordercode;
            //    rd10.iproorderid = moid;
            //    rd10.dnmaketime = DateTime.Now.ToString();




            //    //表体
            //    List<rds10> rdslist = new List<rds10>();
            //    //查询生产订单明细
            //    string selectorder = $" select * from mom_orderdetail where MoId ='{moid}' ";
            //    DataTable dt = null;
            //    DB.RunProcDataTable(sql, ref dt);

            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        rds10 rds = new rds10();
            //        rds.cInvCode = dt.Rows[i]["InvCode"].ToString();
            //        rds.iQuantity = decimal.Parse(dt.Rows[i]["Qty"].ToString());
            //        rds.iNQuantity = decimal.Parse(dt.Rows[i]["Qty"].ToString());
            //        rds.iMPoIds = int.Parse(dt.Rows[i]["MoDId"].ToString());
            //        rds.cbaccounter = U8LoginInfo.UserId;
            //        rds.dbKeepDate = DateTime.Now.ToString("yyyy-MM-dd");
            //        rds.cmocode = momordercode;
            //        rds.imoseq = int.Parse(dt.Rows[i]["SortSeq"].ToString());
            //        rds.irowno = i + 1;

            //        //货位管理
            //        //if (string.IsNullOrEmpty(rds.cPosition))
            //        //{
            //        //    string sqlps = $" select bWhPos from Warehouse where cWhCode='{rd10.cWhCode}' ";
            //        //    if (DB.RunProcScalar(sqlps) == "True")
            //        //        return "仓库有货位管理，货位不能为空！";
            //        //}

            //        //批次管理
            //        //if (string.IsNullOrEmpty(rds.cBatch))
            //        //{
            //        //    string sqlps = $" select bInvBatch from Inventory where cInvCode='{rds.cInvCode}' ";
            //        //    if (DB.RunProcScalar(sqlps) == "True")

            //        //        return "存货有批次管理，批次不能为空！";
            //        //}
            //        rdslist.Add(rds);
            //    }

            //    rd10.Detail = rdslist;



            //    U8LoginInfo.AccId = ds_sequence;
            //    U8LoginInfo.UserId = "demo";
            //    U8LoginInfo.Password = "DEMO";

            //    //登录 测试账套年份2015年 
            //    object login = null;
            //    login = Util.U8Login(ds_sequence, Convert.ToDateTime("2015-12-12"));
            //    //login = Util.U8Login(ds_sequence, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));

            //    #region 组装数据
            //    ST st = new ST(login);

            //    IXMLDOMDocument2 defpos = new DOMDocument();

            //    IXMLDOMDocument2 head = new DOMDocument();
            //    IXMLDOMDocument2 body = new DOMDocument();

            //    st.GetDefaultDOM("10", "0411", ref head, ref body, ref defpos);

            //    IXMLDOMDocument2 bodycheck = new DOMDocument();
            //    bodycheck.loadXML(body.xml);
            //    if (rd10.Detail == null || rd10.Detail.Count == 0)
            //        return "产成品入库单保存失败：表体数据不能为空";

            //    //string guid = Guid.NewGuid().ToString().Replace("-", "");
            //    //组装表头DOM
            //    rd10 rd = rd10;
            //    //inq.cmemo = guid;
            //    IXMLDOMNode node = head.selectNodes("//rs:data")[0];
            //    for (int i = node.childNodes.length - 1; i >= 0; i--)
            //    {
            //        node.removeChild(node.childNodes[i]);
            //    }
            //    IXMLDOMElement element = head.createElement("z:row");
            //    foreach (PropertyInfo item in typeof(rd10).GetProperties())
            //    {
            //        element.setAttribute(item.Name, item.GetValue(rd, null));
            //    }
            //    element.setAttribute("bWireless", "1");
            //    node.appendChild(element);
            //    //组装表体DOM

            //    node = body.selectNodes("//rs:data")[0];
            //    for (int i = node.childNodes.length - 1; i >= 0; i--)
            //    {
            //        node.removeChild(node.childNodes[i]);
            //    }
            //    foreach (rds10 s in rd10.Detail)
            //    {
            //        //bodycheck.selectSingleNode("//rs:data").removeChild(bodycheck.selectSingleNode("//z:row"));
            //        element = bodycheck.createElement("z:row");
            //        foreach (PropertyInfo item in typeof(rds10).GetProperties())
            //        {
            //            element.setAttribute(item.Name, item.GetValue(s, null));
            //        }
            //        bodycheck.selectSingleNode("//rs:data").appendChild(element);



            //        element.setAttribute("editprop", "A");
            //        //element.setAttribute("cbatch", s.cbatch);

            //        node.appendChild(element);
            //    }
            //    defpos = new DOMDocument();
            //    #endregion
            //    string xml = body.xml;
            //    string ss = st.SaveVoucher("10", head, body, defpos, out string Id, out IXMLDOMDocument2 DomConfig);
            //    if (!string.IsNullOrEmpty(ss))
            //    {
            //        return ss;
            //    }
            //    else
            //    {
            //        return "";
            //    }



            //}
            //catch (Exception ex)
            //{
            //    return ex.Message;
            //}

        }

        public string Delete(string ds_sequence, string code)
        {
            return "";
            //try
            //{
            //    string sql = $" select ID from rdrecord10 where cCode='{code}' ";
            //    int id = int.Parse(DB.RunProcScalar(sql));

            //    object login = null;
            //    login = Util.U8Login(ds_sequence, Convert.ToDateTime("2015-12-12"));
            //    //login = Util.U8Login(ds_sequence, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));

            //    ST st = new ST(login);

            //    string msg = st.DeleteVoucher("10", id);
            //    if (string.IsNullOrEmpty(msg))
            //    {

            //        return "";
            //    }
            //    else
            //    {
            //        return msg;
            //    }

            //}
            //catch(Exception ex)
            //{
                
            //    return ex.Message;
            //}
        }

    }
}