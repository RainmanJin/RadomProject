using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PublicRandomData.Units
{
    public class LoggerTool
    {
        private static ILog logger;
        static LoggerTool()
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile));
            logger = LogManager.GetLogger(typeof(LoggerTool));
        }
        //private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static string buildMessage(string msg)
        {
            StackTrace trace = new StackTrace();
            StringBuilder sb = new StringBuilder();
            MethodBase methodName = null;
            if (trace.FrameCount > 1)
            {
                methodName = trace.GetFrame(2).GetMethod();
            }
            else
            {
                methodName = trace.GetFrame(1).GetMethod();
            }

            sb.Append("[").Append(methodName.ReflectedType.Name).Append(".").Append(methodName.Name).Append("]");
            sb.Append(msg);

            return sb.ToString();
        }

        private static string buildMessage(string tag, string msg)
        {
            StackTrace trace = new StackTrace();
            StringBuilder sb = new StringBuilder();
            MethodBase methodName = null;
            if (trace.FrameCount > 1)
            {
                methodName = trace.GetFrame(2).GetMethod();
            }
            else
            {
                methodName = trace.GetFrame(1).GetMethod();
            }

            sb.Append("[").Append(tag).Append("]");
            sb.Append("[");
            sb.Append("[").Append(methodName.ReflectedType.Name).Append(".").Append(methodName.Name).Append("]");

            sb.Append(msg);

            return sb.ToString();
        }

        public static void Debug(string tag, string msg)
        {
            logger.Debug(buildMessage(msg));
        }

        public static void Info(string tag, string msg)
        {
            logger.Info(buildMessage(msg));
        }

        public static void Warn(string tag, string msg)
        {
            logger.Warn(buildMessage(msg));
        }

        public static void Error(string tag, string msg)
        {
            logger.Error(buildMessage(msg));
        }
        public static void Debug(string format, params object[]args)
        {
            logger.DebugFormat(format,args);
        }

        public static void Info(string format, params object[] args)
        {
            logger.InfoFormat(format, args);
        }

        public static void Warn(string format, params object[] args)
        {
            logger.WarnFormat(format, args);
        }

        public static void Error(string format, params object[] args)
        {
            logger.ErrorFormat(format, args);
        }
        public static void Info(string msg)
        {
            logger.Info(buildMessage(msg));
        }

        public static void Warn(string msg)
        {
            logger.Warn(buildMessage(msg));
        }

        public static void Debug(string msg)
        {
            logger.Debug(buildMessage(msg));
        }

        public static void Error(string msg)
        {
            logger.Error(buildMessage(msg));
        }
    }
}
