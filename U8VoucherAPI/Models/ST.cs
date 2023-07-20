using ADODB;
using MSXML2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PublicVatti.Model;
using U8Login;
using ZR.U8API;

namespace U8VoucherAPI.Models
{
    public class ST
    {
        /// <summary>
        /// 连接对象
        /// </summary>
        Connection conn = null;
        USERPCO.VoucherCO StCo = null;
        public clsLogin u8login = null;

        public ST()
        {
            //初始化
            if (Util.u8login == null)
                Util.InitLogin();
            conn = new Connection();
            conn.Open(U8LoginInfo.ConnectionStringVB);

            StCo = new USERPCO.VoucherCO();
            string errMsg = "";
            StCo.IniLogin(Util.u8login, ref errMsg);
            if (!string.IsNullOrEmpty(errMsg))
                throw new Exception("初始化库存模块失败：" + errMsg);
        }

        public ST(object login)
        {
            ////初始化
            //if (Util.u8login == null)
            //    Util.InitLogin();
            u8login = login as clsLogin;

            conn = new Connection();
            conn.Open(u8login.UfDbName);

            StCo = new USERPCO.VoucherCO();
            string errMsg = "";
            StCo.IniLogin(u8login, ref errMsg);
            if (!string.IsNullOrEmpty(errMsg))
                throw new Exception("初始化库存模块失败：" + errMsg);
        }

        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="VouchType"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public string VerifyVoucher(string VouchType, int id, Connection conn1 = null)
        {
            try
            {
                string msg = "";
                StCo.Verify(VouchType, id, ref msg, ref conn1);
                return msg;
            }
            catch (Exception ex)
            {
                return "审核单据失败：" + ex.Message;
            }
        }

        public string DeleteVoucher(string VouchType, int id)
        {
            string msg = "";
            Connection conn1 = new Connection();
            conn1.Open(u8login.UfDbName);
            conn1.BeginTrans();

            try
            {
                bool flat = StCo.Delete(VouchType, id, ref msg, ref conn1);
                if (flat)
                {
                    conn1.CommitTrans();
                    return "";
                }
                else
                {
                    conn1.RollbackTrans();
                    return msg;
                }
            }
            catch (Exception ex)
            {
                conn1.RollbackTrans();
                return ex.Message;
            }

        }



        /// <summary>
        /// 弃审单据
        /// </summary>
        /// <param name="VouchType"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public string UnVerifyVoucher(string VouchType, int id)
        {
            try
            {
                string msg = "";
                StCo.UnVerify(VouchType, id, ref msg);
                return msg;
            }
            catch (Exception ex)
            {
                return "弃审单据失败：" + ex.Message;
            }
        }
        /// <summary>
        /// 保存订单
        /// </summary>
        /// <param name="VouchType"></param>
        /// <param name="domHead">单据头</param>
        /// <param name="domBody">单据体</param>
        /// <returns></returns>
        public string SaveVoucher(string VouchType, IXMLDOMDocument2 domHead, IXMLDOMDocument2 domBody, IXMLDOMDocument2 domPosition, out string Id, out IXMLDOMDocument2 DomConfig, Action action = null)
        {
            Id = "-1";
            DomConfig = null;
            try
            {
                string msg = "";

                Connection conn1 = new Connection();
                conn1.Open(u8login.UfDbName);
                conn1.BeginTrans();
                if (!StCo.Insert(VouchType, domHead, domBody, domPosition, ref msg, ref conn1, ref Id, ref DomConfig))
                {
                    if (string.IsNullOrEmpty(msg))
                    {
                        conn1.RollbackTrans();
                        return DomConfig.xml;
                    }
                    conn1.RollbackTrans();
                }

                if (string.IsNullOrEmpty(msg))
                {
                    try
                    {
                        if (action != null)
                            action();
                        conn1.CommitTrans();
                    }
                    catch (Exception ex)
                    {
                        conn1.RollbackTrans();
                        return ex.Message;
                    }
                    //成功处理方法
                    return "";
                }
                else
                    return msg;
            }
            catch (Exception ex)
            {
                return "保存单据失败：" + ex.Message;
            }
        }

        /// <summary>
        /// 保存订单
        /// </summary>
        /// <param name="VouchType"></param>
        /// <param name="domHead">单据头</param>
        /// <param name="domBody">单据体</param>
        /// <returns></returns>
        public string SaveVerifyVoucher(string VouchType, IXMLDOMDocument2 domHead, IXMLDOMDocument2 domBody, IXMLDOMDocument2 domPosition, out string Id, out IXMLDOMDocument2 DomConfig, Action<int> action = null)
        {
            Id = "-1";
            DomConfig = null;
            try
            {
                string msg = "";

                Connection conn1 = new Connection();
                conn1.Open(u8login.UfDbName);
                conn1.BeginTrans();
                if (!StCo.Insert(VouchType, domHead, domBody, domPosition, ref msg, ref conn1, ref Id, ref DomConfig))
                {
                    if (string.IsNullOrEmpty(msg))
                    {
                        conn1.RollbackTrans();
                        msg = "";
                        foreach (IXMLDOMElement node in DomConfig.selectNodes("//z:row"))
                        {
                            msg += $"存货编码：{node.getAttribute("cinvcode")};批次：{node.getAttribute("cbatch")};现存数量：{node.getAttribute("icurquantity")};现存件数：{node.getAttribute("icurnum")};可用数量：{node.getAttribute("iavaquantity")};可用件数：{node.getAttribute("iavanum")};预计可用数量：{node.getAttribute("iforquantity")};预计可用件数：{node.getAttribute("ifornum")};\n";
                        }
                        return msg;
                    }
                    conn1.RollbackTrans();
                }
                string aa = DomConfig.xml;

                if (string.IsNullOrEmpty(msg))
                {
                    try
                    {
                        ////通过备注获取ID
                        //string sql = "SELECT ID FROM " + U8DataBase + "..rdrecord"+ VouchType + " WITH(NOLOCK) WHERE cMemo='" + guid + "'";
                        //string ID = DB.RunProcScalar(sql);

                        //if (string.IsNullOrEmpty(ID))
                        //    throw new Exception("获取ID失败！");
                        //Id = ID;
                        //sql = " UPDATE  " + U8DataBase + "..rdrecord" + VouchType + " SET cMemo='" + Memo+"' WHERE ID=" + ID + " ";
                        ////dataAcc.ExecuteNotQuery(sql);

                        //ADODB.Command command = new ADODB.Command();
                        //command.ActiveConnection = conn1;
                        //command.CommandText = sql;
                        //command.CommandType = CommandTypeEnum.adCmdText;
                        //object nRecordsAffected = Type.Missing;
                        //object oParams = Type.Missing;
                        //command.Execute(out nRecordsAffected, ref oParams,
                        //    (int)ADODB.ExecuteOptionEnum.adExecuteNoRecords);

                        StCo.Verify(VouchType, int.Parse(Id), ref msg, ref conn1);
                        if (!string.IsNullOrEmpty(msg))
                            throw new Exception(msg);
                        if (action != null)
                            action(int.Parse(Id));
                        conn1.CommitTrans();
                    }
                    catch (Exception ex)
                    {
                        conn1.RollbackTrans();
                        return ex.Message;
                    }
                    //成功处理方法
                    return "";
                }
                else
                    return msg;
            }
            catch (Exception ex)
            {
                return "保存单据失败：" + ex.Message;
            }
        }

        /// <summary>
        /// 其他入库单/其他出库单 保存
        /// </summary>
        /// <param name="VouchType"></param>
        /// <param name="domHead">单据头</param>
        /// <param name="domBody">单据体</param>
        /// <returns></returns>
        public string SaveVerifyVoucher(string VouchType, IXMLDOMDocument2 domHead, IXMLDOMDocument2 domBody, IXMLDOMDocument2 domPosition, out string Id, out IXMLDOMDocument2 DomConfig)
        {
            Id = "-1";
            DomConfig = null;
            try
            {
                string msg = "";

                Connection conn1 = new Connection();
                conn1.Open(u8login.UfDbName);
                conn1.BeginTrans();
                if (!StCo.Insert(VouchType, domHead, domBody, domPosition, ref msg, ref conn1, ref Id, ref DomConfig))
                {
                    if (string.IsNullOrEmpty(msg))
                    {
                        conn1.RollbackTrans();
                        msg = "";
                        foreach (IXMLDOMElement node in DomConfig.selectNodes("//z:row"))
                        {
                            msg += $"存货编码：{node.getAttribute("cinvcode")};批次：{node.getAttribute("cbatch")};现存数量：{node.getAttribute("icurquantity")};现存件数：{node.getAttribute("icurnum")};可用数量：{node.getAttribute("iavaquantity")};可用件数：{node.getAttribute("iavanum")};预计可用数量：{node.getAttribute("iforquantity")};预计可用件数：{node.getAttribute("ifornum")};\n";
                        }
                        return msg;
                    }
                    conn1.RollbackTrans();
                }
                string aa = DomConfig.xml;

                if (string.IsNullOrEmpty(msg))
                {
                    try
                    {
                        ////通过备注获取ID
                        //string sql = "SELECT ID FROM " + U8DataBase + "..rdrecord"+ VouchType + " WITH(NOLOCK) WHERE cMemo='" + guid + "'";
                        //string ID = DB.RunProcScalar(sql);

                        //if (string.IsNullOrEmpty(ID))
                        //    throw new Exception("获取ID失败！");
                        //Id = ID;
                        //sql = " UPDATE  " + U8DataBase + "..rdrecord" + VouchType + " SET cMemo='" + Memo+"' WHERE ID=" + ID + " ";
                        ////dataAcc.ExecuteNotQuery(sql);

                        //ADODB.Command command = new ADODB.Command();
                        //command.ActiveConnection = conn1;
                        //command.CommandText = sql;
                        //command.CommandType = CommandTypeEnum.adCmdText;
                        //object nRecordsAffected = Type.Missing;
                        //object oParams = Type.Missing;
                        //command.Execute(out nRecordsAffected, ref oParams,
                        //    (int)ADODB.ExecuteOptionEnum.adExecuteNoRecords);

                        StCo.Verify(VouchType, int.Parse(Id), ref msg, ref conn1);
                        if (!string.IsNullOrEmpty(msg))
                            throw new Exception(msg);
                        conn1.CommitTrans();
                    }
                    catch (Exception ex)
                    {
                        conn1.RollbackTrans();
                        return ex.Message;
                    }
                    //成功处理方法
                    return "";
                }
                else
                    return msg;
            }
            catch (Exception ex)
            {
                return "保存单据失败：" + ex.Message;
            }
        }

        /// <summary>
        /// 获取单据默认模板
        /// </summary>
        /// <param name="CardNum">单据模板号</param>
        /// <param name="domHead">表头</param>
        /// <param name="domBody">表体</param>
        public void GetDefaultDOM(string VouchType, string CardNum, ref IXMLDOMDocument2 heda, ref IXMLDOMDocument2 body, ref IXMLDOMDocument2 pos)
        {
            string errmsg = "";
            StCo.GetDefaultVoucherDom(VouchType, CardNum, ref heda, ref body, ref pos, ref errmsg);
            if (!string.IsNullOrEmpty(errmsg))
                throw new Exception("获取库存单据模板失败：" + errmsg);

        }

        public string HeadCheckInsert(string VouchType, string sKey, ref IXMLDOMDocument2 domHead, ref IXMLDOMDocument2 domBody)
        {
            string msg = "";
            StCo.CheckHead(VouchType, USCOMMON.oVouchState.nInsert, sKey, ref domHead, ref msg, ref domBody);
            return msg;
        }

        public string BodyCheckInsert(string VouchType, string sKey, ref IXMLDOMDocument2 domBody, ref IXMLDOMDocument2 domHead, int R = -1)
        {
            string msg = "";
            StCo.CheckBody(VouchType, USCOMMON.oVouchState.nInsert, R, sKey, ref domBody, ref msg, domHead);
            return msg;
        }

        public string LoadData(string VouchType, string where, ref IXMLDOMDocument2 domHead, ref IXMLDOMDocument2 domBody, ref IXMLDOMDocument2 domPos)
        {
            string msg = "";
            StCo.Load(VouchType, where, ref domHead, ref domBody, ref domPos, ref msg);
            //msg = heda.xml;
            return msg;
        }
    }
}
