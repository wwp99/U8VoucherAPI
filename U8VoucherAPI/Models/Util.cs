using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using U8Login;
using PublicVatti.Model;
using ZR.U8API;

namespace U8VoucherAPI.Models
{
    public class Util
    {

        public static clsLogin u8login = null;
        /// <summary>
        /// 初始化登录
        /// </summary>
        public static void InitLogin()
        {
            try
            {
                u8login = new clsLogin();
                if (!u8login.Login(U8LoginInfo.SubId, U8LoginInfo.AccId,U8LoginInfo.YearId, U8LoginInfo.UserId, U8LoginInfo.Password, U8LoginInfo.Date))
                    throw new Exception("U8登录失败！");
                else
                {
                    U8LoginInfo.ConnectionStringVB = u8login.UfDbName;
                    U8LoginInfo.ConnectionStringNet = u8login.UfDbName.Replace("PROVIDER=SQLOLEDB;", "").Replace("Connect Timeout=30", "Connect Timeout=10000");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("构造Login对象失败："+ex.Message);
            }
            
        }

        public static object U8Login(string acc, DateTime date)
        {
            clsLogin u8login = null;
            U8LoginInfo.SubId = "DP";
            try
            {
                u8login = new clsLogin();
                if (!u8login.Login(U8LoginInfo.SubId, acc, date.Year.ToString(), U8LoginInfo.UserId, U8LoginInfo.Password, date.ToString("yyyy-MM-dd")))
                    throw new Exception("U8登录失败！");
                else
                {
                    U8LoginInfo.ConnectionStringVB = u8login.UfDbName;
                    U8LoginInfo.ConnectionStringNet = u8login.UfDbName.Replace("PROVIDER=SQLOLEDB;", "").Replace("Connect Timeout=30", "Connect Timeout=10000");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("构造Login对象失败：" + ex.Message);
            }
            return u8login;
        }
    }
}
