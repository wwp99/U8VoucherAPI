using Newtonsoft.Json;
using PublicVatti.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using U8VoucherAPI.Models;
using ZR.WMS.Business;

namespace U8VoucherAPI.Controllers
{
    public class U8BaseController : ApiController
    {


        /// <summary>
        /// 新增供应商档案
        /// </summary>
        /// <returns></returns>
        [Route("api/vendor/add")]
        [HttpPost]
        public FeedbackResult VendorAdd(string ds_sequence, Vendor vendor)
        {
            LogHelp l = new LogHelp();
            l.VouchName = "供应商档案";
            l.UserAgent = Request.Headers.UserAgent.ToString();
            l.ClientIp = "";
            l.cAccId = ds_sequence;
            try
            {
                if (string.IsNullOrEmpty(ds_sequence))
                {
                    l.Warn("账套号不能为空：");
                    return new FeedbackResult { errcode = "1", errmsg = "账套号不能为空" };
                }
                if (vendor == null)
                {
                    l.Warn("JSON传入格式错误解析失败：");
                    return new FeedbackResult { errcode = "1", errmsg = "JSON传入格式错误解析失败" };
                }
                l.Json = JsonConvert.SerializeObject(vendor);
                //string odd = data.CCusCode;
                string msg = new VendorService().Add(ds_sequence, vendor,out string odd);
                if (string.IsNullOrEmpty(msg))
                {
                    return new FeedbackResult { errcode = "0", id = odd, errmsg = "供应商创建成功！" };
                }
                else
                    return new FeedbackResult { errcode = "1", errmsg = msg };

            }
            catch (Exception e)
            {
                l.Error("内部服务器发生错误：" + e.Message + e.StackTrace + "；", e);
                return new FeedbackResult { errcode = "1", errmsg = e.Message };
            }
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [Route("api/vendor/add")]
        [HttpPost]
        public FeedbackResult RdAdd(string corporationid, Vendor data)
        {
            LogHelp l = new LogHelp();
            l.VouchName = "WMS";
            l.UserAgent = Request.Headers.UserAgent.ToString();
            l.ClientIp = "";
            try
            {
                //if (string.IsNullOrEmpty(ds_sequence))
                //{
                //    l.Warn("数据源名称不能为空：");
                //    return new FeedbackResult { Success = false, Msg = "数据源名称不能为空", date = DateTime.Now.ToString() };
                //}
                if (data == null)
                {
                    l.Warn("JSON传入格式错误解析失败：");
                    return new FeedbackResult { errcode = "1", errmsg = "JSON传入格式错误解析失败" };
                }
                l.Json = JsonConvert.SerializeObject(data);
                string code = "";
                string msg = new VendorService().Add(corporationid,data, out code);
                if (string.IsNullOrEmpty(msg))
                {
                    return new FeedbackResult { errcode = "1", id = code, errmsg = "创建成功！" };
                }
                else
                    return new FeedbackResult { errcode = "0", id = "0", errmsg = "创建失败！"+msg };
                //return null;
            }
            catch (Exception e)
            {
                l.Error("内部服务器发生错误：" + e.Message + e.StackTrace + "；", e);
                return new FeedbackResult { errcode = "1", errmsg = e.Message };
            }
        }

    }
}