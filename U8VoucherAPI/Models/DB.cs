using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace U8VoucherAPI.Models
{
    public class DB
    {
        public static string connectionString= ConfigurationManager.AppSettings["connectionString"];
        private static LogHelp l = new LogHelp();

        public static SqlConnection CreateConnection()
        {
            SqlConnection connection = null;
            if (!string.IsNullOrEmpty(connectionString))
            {
                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }
                catch (Exception exception)
                {
                    l.Error("连接数据库出错：" + exception.Message + exception.StackTrace, exception);
                    return null;
                }
            }
            return connection;
        }

        public static bool Login(string userName, string passWord, out string roles)
        {
            roles = "";
            try
            {
                SHA1 sha1 = SHA1.Create();
                byte[] bytResult = sha1.ComputeHash(Encoding.UTF8.GetBytes(passWord));
                passWord = Convert.ToBase64String(bytResult);

                string sql = "SELECT COUNT(1) FROM UFSystem..UA_User WHERE cUser_Id=@cUser_Id and LEFT(cPassword,LEN(cPassword)-1)=@cPassword";
                List<SqlParameter> parameters = new List<SqlParameter>() { new SqlParameter("@cUser_Id", userName),new SqlParameter("@cPassword", passWord)};
                if (int.Parse(DB.RunProcScalar(sql, parameters)) == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                l.Error(ex.Message,ex);
                return false;
            }

        }

        private static SqlCommand CreateSqlCommand(string Sqlstring)
        {
            SqlConnection connection = CreateConnection();
            if (connection == null)
            {
                return null;
            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return new SqlCommand(Sqlstring, connection) { CommandTimeout = 300, CommandType = CommandType.Text };
        }

        private static SqlDataAdapter CreateSqlDataAdapter(string Sqlstring)
        {
            SqlConnection selectConnection = CreateConnection();
            if (selectConnection == null)
            {
                return null;
            }
            if (selectConnection.State == ConnectionState.Closed)
            {
                selectConnection.Open();
            }
            return new SqlDataAdapter(Sqlstring, selectConnection);
        }

        public static void RunProcDataSet(string Sqlstring, ref DataSet ds, string tableName)
        {
            if (ds == null)
            {
                ds = new DataSet();
            }
            SqlDataAdapter adapter = CreateSqlDataAdapter(Sqlstring);
            if (adapter != null)
            {
                try
                {
                    adapter.Fill(ds, tableName);
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message, exception);
                }
                finally
                {
                    if (adapter.SelectCommand.Connection.State == ConnectionState.Open)
                    {
                        adapter.SelectCommand.Connection.Close();
                    }
                }
            }
        }

        public static void RunProcDataTable(string Sqlstring, ref DataTable dt)
        {
            if (dt == null)
            {
                dt = new DataTable();
            }
            SqlDataAdapter adapter = CreateSqlDataAdapter(Sqlstring);
            if (adapter != null)
            {
                DataSet dataSet = new DataSet();
                try
                {
                    adapter.Fill(dataSet);
                    dt = dataSet.Tables[0];
                }
                catch (Exception exception)
                {
                    l.Error("查询数据失败：" + exception.Message + exception.StackTrace, exception);
                }
                finally
                {
                    if (adapter.SelectCommand.Connection.State == ConnectionState.Open)
                    {
                        adapter.SelectCommand.Connection.Close();
                    }
                }
                
            }
        }

        public static void RunProcDataTable(string Sqlstring, ref DataTable dt, List<SqlParameter> parameters)
        {
            if (dt == null)
            {
                dt = new DataTable();
            }
            SqlDataAdapter adapter = CreateSqlDataAdapter(Sqlstring);
            adapter.SelectCommand.Parameters.AddRange(parameters.ToArray());
            if (adapter != null)
            {
                DataSet dataSet = new DataSet();
                try
                {
                    adapter.Fill(dataSet);
                    dt = dataSet.Tables[0];
                }
                catch (Exception exception)
                {
                    l.Error("查询数据失败：" + exception.Message + exception.StackTrace, exception);
                }
                finally
                {
                    if (adapter.SelectCommand.Connection.State == ConnectionState.Open)
                    {
                        adapter.SelectCommand.Connection.Close();
                    }
                }

            }
        }

        public static SqlCommandBuilder RunProcDataTable(string sqlString, ref SqlDataAdapter da, ref DataTable dt)
        {
            SqlConnection selectConnection = CreateConnection();
            if (selectConnection.State == ConnectionState.Closed)
            {
                selectConnection.Open();
            }
            da = new SqlDataAdapter(sqlString, selectConnection);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            DataSet dataSet = new DataSet();
            da.Fill(dataSet);
            dt = dataSet.Tables[0];
            return builder;
        }

        public static void RunProcDataTable(string Sqlstring, string tableName, DataSet ds)
        {
            SqlDataAdapter adapter = CreateSqlDataAdapter(Sqlstring);
            if (adapter != null)
            {
                try
                {
                    adapter.Fill(ds, tableName);
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message, exception);
                }
                finally
                {
                    if (adapter.SelectCommand.Connection.State == ConnectionState.Open)
                    {
                        adapter.SelectCommand.Connection.Close();
                    }
                }
            }
        }

        public static void RunProcDataTable(string Sqlstring, ref DataTable dt, int start, int max)
        {
            if (dt == null)
            {
                dt = new DataTable();
            }
            SqlDataAdapter adapter = CreateSqlDataAdapter(Sqlstring);
            if (adapter != null)
            {
                DataSet dataSet = new DataSet();
                try
                {
                    adapter.Fill(dataSet, start, max, "DataTable");
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message, exception);
                }
                finally
                {
                    if (adapter.SelectCommand.Connection.State == ConnectionState.Open)
                    {
                        adapter.SelectCommand.Connection.Close();
                    }
                }
                dt = dataSet.Tables["DataTable"];
            }
        }

        public static int RunProcNonQuery(string Sqlstring)
        {
            int num;
            SqlCommand command = CreateSqlCommand(Sqlstring);
            if (command == null)
            {
                return -1;
            }
            try
            {
                num = command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                l.Error("执行Sql失败：" + exception.Message + exception.StackTrace, exception);
                return 0;
                //throw new Exception(exception.Message, exception);

            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
            return num;
        }

        public static int RunProcNonQuery(string Sqlstring, SqlParameter[] parameters)
        {
            int num;
            SqlCommand command = CreateSqlCommand(Sqlstring);
            if (command == null)
            {
                return -1;
            }
            try
            {
                command.CommandType = CommandType.Text;
                if (parameters != null)
                {
                    foreach (SqlParameter p in parameters)
                    {
                        command.Parameters.Add(p);
                    }
                }
                num = command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                l.Error("执行Sql失败：" + exception.Message + exception.StackTrace, exception);
                return 0;
                //throw new Exception(exception.Message, exception);

            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
            return num;
        }

        public static void RunProcReader(string Sqlstring, out SqlDataReader dr)
        {
            SqlCommand command = CreateSqlCommand(Sqlstring);
            if (command == null)
            {
                dr = null;
            }
            else
            {
                try
                {
                    dr = command.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception exception)
                {
                    dr = null;
                    throw new Exception(exception.Message, exception);
                }
            }
        }

        //返回单个列
        public static string RunProcScalar(string Sqlstring)
        {
            string str;
            SqlCommand command = CreateSqlCommand(Sqlstring);
            if (command == null)
            {
                return string.Empty;
            }
            try
            {
                if (command.ExecuteScalar() == null)
                {
                    return "";
                }
                str = command.ExecuteScalar().ToString();
            }
            catch (Exception exception)
            {
                str = "";
                l.Error("查询单个数据失败：" + exception.Message + exception.StackTrace, exception);
            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
            return str;
        }

        public static string RunProcScalar(string Sqlstring,List<SqlParameter> parameters)
        {
            string str;
            SqlCommand command = CreateSqlCommand(Sqlstring);
            if (command == null)
            {
                return string.Empty;
            }
            try
            {
                command.Parameters.AddRange(parameters.ToArray());
                if (command.ExecuteScalar() == null)
                {
                    return "";
                }
                str = command.ExecuteScalar().ToString();
            }
            catch (Exception exception)
            {
                str = "";
                l.Error("查询单个数据失败：" + exception.Message + exception.StackTrace, exception);
            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
            return str;
        }

        public static bool RunProcTransaction(params string[] sqlString)
        {
            SqlConnection connection = CreateConnection();
            SqlTransaction transaction = connection.BeginTransaction();
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                Transaction = transaction
            };
            try
            {
                foreach (string str in sqlString)
                {
                    command.CommandText = str;
                    command.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                l.Error("执行事务失败：" + exception.Message + exception.StackTrace, exception);
                return false;
            }
            return true;
        }

        public static bool RunProcTransaction(ArrayList sqlArray)
        {
            SqlConnection connection = CreateConnection();
            SqlTransaction transaction = connection.BeginTransaction();
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                Transaction = transaction,
                CommandTimeout = 0x5dc
            };
            try
            {
                foreach (string str in sqlArray)
                {
                    command.CommandText = str;
                    command.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                l.Error("执行事务失败：" + exception.Message + exception.StackTrace, exception);
                return false;
            }
            return true;
        }

        //public static string RunProcTransaction(List<SqlP> lisqlp)
        //{
        //    SqlConnection connection = CreateConnection();
        //    SqlTransaction transaction = connection.BeginTransaction();
        //    SqlCommand command = new SqlCommand
        //    {
        //        Connection = connection,
        //        Transaction = transaction,
        //        CommandTimeout = 0x5dc
        //    };
        //    try
        //    {
        //        foreach (SqlP sqlp in lisqlp)
        //        {
        //            command.CommandText = sqlp.sql;
        //            command.Parameters.Clear();
        //            if (sqlp.parameter != null)
        //            {
        //                command.Parameters.AddRange(sqlp.parameter);
        //            }
        //            command.ExecuteNonQuery();
        //        }
        //        transaction.Commit();
        //        return "";
        //    }
        //    catch (Exception exception)
        //    {
        //        transaction.Rollback();
        //        //MessageBox.Show(exception.Message,"提示");
        //        return exception.Message+exception.StackTrace;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //        command.Dispose();
        //        transaction.Dispose();
        //    }
        //}

        //static SqlConnection conn = null;
        public static bool RunProcTransaction1(ref SqlConnection conn, ArrayList sqlArray)
        {
            if (conn==null)
            {
                conn = new SqlConnection(DB.connectionString);
                conn.Open();
            }
            if (conn.State==ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlTransaction transaction = conn.BeginTransaction();
            SqlCommand command = new SqlCommand
            {
                Connection = conn,
                Transaction = transaction,
                CommandTimeout = 0x5dc
            };
            try
            {
                foreach (string str in sqlArray)
                {
                    command.CommandText = str;
                    command.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                l.Error("执行事务失败：" + exception.Message + exception.StackTrace, exception);
                return false;
            }
            return true;
        }

        public static void CloseConn()
        {
            //if (conn != null)
            //{
            //    if (conn.State == ConnectionState.Closed)
            //    {
            //        conn.Close();
            //    }
            //}
        }

        public static void ShowDialog(string messgae)
        {
            //MessageBox.Show(messgae, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        //public static string ConncetionString
        //{
        //    get
        //    {
        //        return connectionString;
        //    }
        //    set
        //    {
        //        connectionString = value;
        //    }
        //}
        public static int RunProcNonQueryprocedu(string Sqlstring, SqlCommand cmd, out SqlCommand cmdout)
        {
            int num;
            SqlCommand command = DB.CreateSqlCommand(Sqlstring);
            if (command == null)
            {
                cmdout = new SqlCommand();
                return -1;
            }
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < cmd.Parameters.Count; i++)
                {
                    command.Parameters.Add(cmd.Parameters[i].ParameterName, cmd.Parameters[i].SqlDbType, cmd.Parameters[i].Size);
                }
                for (int i = 0; i < command.Parameters.Count; i++)
                {
                    command.Parameters[i].Value = cmd.Parameters[i].Value;
                    command.Parameters[i].Direction = cmd.Parameters[i].Direction;
                }
                num = command.ExecuteNonQuery();
                cmdout = command;
            }
            catch (Exception exception)
            {
                cmdout = new SqlCommand();
                //MessageBox.Show(exception.Message + exception.StackTrace);
                return 0;
                //throw new Exception(exception.Message, exception);

            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
            return num;
        }

        /// <summary>
        /// 获取指定参数
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static string GetInterfaceParam(string Key)
        {
            string value = DB.RunProcScalar($"SELECT ParaValue FROM dbo.BD_InterfaceParam where ParaCode='{Key}'");
            return value;
        }

        /// <summary>
        /// 执行销售订单存储工程
        /// </summary>
        /// <param name="DsName"></param>
        /// <param name="OrderType"></param>
        /// <param name="MasterName"></param>
        /// <param name="DetailName"></param>
        /// <param name="ReturnCode"></param>
        /// <param name="ReturnMessage"></param>
        /// <returns></returns>
        public static bool RunProcSaleOrder(string DsName, int OrderType, string MasterName, string DetailName, out int ReturnCode, out string ReturnMessage)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand MyCommand = new SqlCommand($"{DsName}.dbo.BDPR_SaleOrder_AddUpdate", conn);
                    MyCommand.CommandType = CommandType.StoredProcedure;
                    MyCommand.Parameters.AddWithValue("@IM_OrderType", OrderType);
                    MyCommand.Parameters.AddWithValue("@IM_MasterTempTableName", MasterName);
                    MyCommand.Parameters.AddWithValue("@IM_DetailTempTableName", DetailName);
                    MyCommand.Parameters.Add("@EX_ReturnCode", SqlDbType.Int).Direction = ParameterDirection.Output;
                    MyCommand.Parameters.Add("@EX_ReturnMessage", SqlDbType.NVarChar, 400).Direction = ParameterDirection.Output;
                    conn.Open();
                    MyCommand.ExecuteNonQuery();
                    ReturnCode = (int)MyCommand.Parameters["@EX_ReturnCode"].Value;
                    ReturnMessage = (string)MyCommand.Parameters["@EX_ReturnMessage"].Value;
                    conn.Close();
                    return true;
                }
            }
            catch (Exception exception)
            {
                ReturnCode = -1;
                ReturnMessage = $"{DsName}.dbo.BDPR_SaleOrder_AddUpdate调用存储过程失败：";
                l.Error($"{DsName}.dbo.BDPR_SaleOrder_AddUpdate调用存储过程失败：" + exception.Message + exception.StackTrace, exception);
                return false;
            }
        }

        /// <summary>
        /// 执行存储工程
        /// </summary>
        /// <param name="ProName">存储过程名称</param>
        /// <param name="DsName"></param>
        /// <param name="OrderType"></param>
        /// <param name="MasterName"></param>
        /// <param name="DetailName"></param>
        /// <param name="ReturnCode"></param>
        /// <param name="ReturnMessage"></param>
        /// <returns></returns>
        public static string RunProc(string ProName,string DsName, int OrderType, string MasterName, string DetailName, out int ReturnCode, out string ReturnMessage)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand MyCommand = new SqlCommand($"{DsName}.dbo.{ProName}", conn);
                    MyCommand.CommandType = CommandType.StoredProcedure;
                    MyCommand.Parameters.AddWithValue("@IM_OrderType", OrderType);
                    MyCommand.Parameters.AddWithValue("@IM_MasterTempTableName", MasterName);
                    MyCommand.Parameters.AddWithValue("@IM_DetailTempTableName", DetailName);
                    MyCommand.Parameters.Add("@EX_ReturnCode", SqlDbType.Int).Direction = ParameterDirection.Output;
                    MyCommand.Parameters.Add("@EX_ReturnMessage", SqlDbType.NVarChar, 400).Direction = ParameterDirection.Output;
                    conn.Open();
                    MyCommand.ExecuteNonQuery();
                    ReturnCode = (int)MyCommand.Parameters["@EX_ReturnCode"].Value;
                    ReturnMessage = (string)MyCommand.Parameters["@EX_ReturnMessage"].Value;
                    conn.Close();
                    return "";
                }
                
            }
            catch (Exception exception)
            {
                ReturnCode = -1;
                ReturnMessage = $"调用存储过程失败：" + exception.Message + exception.StackTrace;
                //l.Error($"{DsName}.dbo.{ProName}调用存储过程失败：" + exception.Message + exception.StackTrace);
                return ReturnMessage;
            }
        }

        /// <summary>
        /// 执行存储工程
        /// </summary>
        /// <returns></returns>
        public static string RunProcVerify(string ProName, string DsName, string Voucher_code, string Person_code, string Person_name,string AuditDate,int Status, out int ReturnCode, out string ReturnMessage)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand MyCommand = new SqlCommand($"{DsName}.dbo.{ProName}", conn);
                    MyCommand.CommandType = CommandType.StoredProcedure;
                    MyCommand.Parameters.AddWithValue("@Voucher_code", Voucher_code==null?"":Voucher_code);
                    MyCommand.Parameters.AddWithValue("@Person_code", Person_code==null?"":Person_code);
                    MyCommand.Parameters.AddWithValue("@person_name", Person_name==null?"":Person_name);
                    MyCommand.Parameters.AddWithValue("@AuditDate", AuditDate==null?"":AuditDate);
                    MyCommand.Parameters.AddWithValue("@Status", Status);
                    MyCommand.Parameters.Add("@EX_ReturnCode", SqlDbType.Int).Direction = ParameterDirection.Output;
                    MyCommand.Parameters.Add("@EX_ReturnMessage", SqlDbType.NVarChar, 400).Direction = ParameterDirection.Output;
                    conn.Open();
                    MyCommand.ExecuteNonQuery();
                    ReturnCode = (int)MyCommand.Parameters["@EX_ReturnCode"].Value;
                    ReturnMessage = (string)MyCommand.Parameters["@EX_ReturnMessage"].Value;
                    conn.Close();
                    return "";
                }

            }
            catch (Exception exception)
            {
                ReturnCode = -1;
                ReturnMessage = $"调用存储过程失败：" + exception.Message + exception.StackTrace;
                //l.Error($"{DsName}.dbo.{ProName}调用存储过程失败：" + exception.Message + exception.StackTrace);
                return ReturnMessage;
            }
        }

        public static int[] RunProc(string acc_id, string tablename, int row)
        {

            SqlConnection conn = new SqlConnection(connectionString);

            //DB.ShowDialog(acc_id + "aaa" + tablename + "bbb" + row.ToString());
            SqlCommand MyCommand = new SqlCommand("sp_GetID", conn);
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.Parameters.AddWithValue("@RemoteId", "00");
            MyCommand.Parameters.AddWithValue("@cAcc_Id", acc_id);
            MyCommand.Parameters.AddWithValue("@cVouchType", tablename);
            MyCommand.Parameters.AddWithValue("@iAmount", row);
            MyCommand.Parameters.Add("@iFatherId", SqlDbType.Int).Direction = ParameterDirection.Output;
            MyCommand.Parameters.Add("@iChildId", SqlDbType.Int).Direction = ParameterDirection.Output;
            MyCommand.Parameters.AddWithValue("@bEnableNewRule", 1);
            conn.Open();
            MyCommand.ExecuteNonQuery();

            int iFatherId = (int)MyCommand.Parameters["@iFatherId"].Value;

            //DB.ShowDialog(iFatherId.ToString());
            int iChildId = (int)MyCommand.Parameters["@iChildId"].Value;
            int[] ret = new int[200];
            ret[0] = iFatherId;
            ret[1] = iChildId;
            //DB.ShowDialog(iChildId.ToString());
            return ret;
        }

        public static string GetLogPath()
        {
            string path = "${basedir}/logs";
            try
            {
                string spath = DB.GetInterfaceParam("100101");
                if (spath != "")
                {
                    if (System.IO.Directory.Exists(spath))
                    {
                        path = spath;
                    }
                }
            }
            catch
            {

            }
            return path;
        }
    }
}
