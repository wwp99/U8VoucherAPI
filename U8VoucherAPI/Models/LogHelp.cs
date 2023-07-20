using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;

namespace U8VoucherAPI.Models
{
    /// <summary>
    /// Log帮助类
    /// </summary>
    public class LogHelp
    {
        /// <summary>
        /// Log对象
        /// </summary>
        public Logger logger = null;

        /// <summary>
        /// 客户端ip
        /// </summary>
        public string ClientIp { get; set; }
        /// <summary>
        /// 客户端标识
        /// </summary>
        public string UserAgent { get; set; }
        /// <summary>
        /// 单据名称
        /// </summary>
        public string VouchName { get; set; }
        /// <summary>
        /// Json
        /// </summary>
        public string Json { get; set; }
        /// <summary>
        /// 账套号
        /// </summary>
        public string cAccId { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        public LogHelp()
        {
            DatabaseTarget db_target = new DatabaseTarget();
            db_target.ConnectionString = DB.connectionString;
            db_target.CommandText = @"  insert into KK_U8VoucherAPILog ([CreateDate], [Origin], [LogLevel], [Message], [StackTrace],[exception],[ClientIp],[UserAgent],[VouchName],[U8ID],[Json],[cAcc_Id]) 
                                        values (GETDATE(), @origin, @logLevel, @message, @stackTrace,@exception,@ClientIp,@UserAgent,@VouchName,@U8ID,@Json,@cAccId); ";
            db_target.CommandType = System.Data.CommandType.Text;
            db_target.Parameters.Add(new DatabaseParameterInfo() { Name= "@origin", Layout= "${callsite}" });
            db_target.Parameters.Add(new DatabaseParameterInfo() { Name = "@logLevel", Layout = "${level}" });
            db_target.Parameters.Add(new DatabaseParameterInfo() { Name = "@message", Layout = "${message}" });
            db_target.Parameters.Add(new DatabaseParameterInfo() { Name = "@exception", Layout = "${exception}" });
            db_target.Parameters.Add(new DatabaseParameterInfo() { Name = "@stackTrace", Layout = "${stacktrace}" });
            db_target.Parameters.Add(new DatabaseParameterInfo() { Name = "@ClientIp", Layout = "${event-context:item=ClientIp}" });
            db_target.Parameters.Add(new DatabaseParameterInfo() { Name = "@UserAgent", Layout = "${event-context:item=UserAgent}" });
            db_target.Parameters.Add(new DatabaseParameterInfo() { Name = "@VouchName", Layout = "${event-context:item=VouchName}" });
            db_target.Parameters.Add(new DatabaseParameterInfo() { Name = "@U8ID", Layout = "${event-context:item=U8ID}" });
            db_target.Parameters.Add(new DatabaseParameterInfo() { Name = "@Json", Layout = "${event-context:item=Json}" });
            db_target.Parameters.Add(new DatabaseParameterInfo() { Name = "@cAccId", Layout = "${event-context:item=cAccId}" });
            db_target.Name = "db_target";

            //NLog 5变化
            LogFactory lf = new LogFactory();
            lf.ReconfigExistingLoggers();
            LoggingConfiguration config = new LoggingConfiguration();
            config.AddTarget(db_target);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, db_target);
            lf.Configuration = config;
            logger = lf.GetCurrentClassLogger();
        }

        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        public void Info(string msg, params object[] args)
        {
            Log(LogLevel.Info, msg, null);
        }
        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="U8ID"></param>
        /// <param name="args"></param>
        public void Info(string msg,string U8ID, params object[] args)
        {
            LogEventInfo info = new LogEventInfo();
            info.Level = LogLevel.Info;
            info.Message = msg;
            info.Properties["ClientIp"] = ClientIp;
            info.Properties["UserAgent"] = UserAgent;
            info.Properties["VouchName"] = VouchName;
            info.Properties["Json"] = Json;
            info.Properties["cAccId"] = cAccId;
            info.Properties["U8ID"] = U8ID;
            logger.Log(info);
        }

        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        public void Warn(string msg, params object[] args)
        {
            Log(LogLevel.Warn, msg, null);
        }
        
        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        public void Error(string msg, Exception ex)
        {
            Log(LogLevel.Error, msg, ex);
        }

        public void Log(LogLevel level,string msg, Exception ex)
        {
            LogEventInfo info = new LogEventInfo();
            info.Level = level;
            info.Message = msg;
            info.Exception = ex;
            info.Properties["ClientIp"] = ClientIp;
            info.Properties["UserAgent"] = UserAgent;
            info.Properties["VouchName"] = VouchName;
            info.Properties["Json"] = Json;
            info.Properties["cAccId"] = cAccId;
            logger.Log(info);
        }
    }
}
