using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace Backend.Helpers
{
    public static class Log
    {
        public static void WriteLog(string strLog)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            //string logFilePath = "E:/Sistemas/G.Operaciones/BACK_EPP_02/";
            //string logFilePath = "E:/Sistemas/G.Operaciones/BACK_EPP/";
            string logFilePath = ConfigurationManager.AppSettings["LogFilePath"].ToString();

            logFilePath = logFilePath + "/Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);
            log.WriteLine(strLog);
            log.Close();
        } 

        public static void WriteLogError(string strLog)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            //string logFilePath = "E:/Sistemas/G.Operaciones/BACK_EPP_02/";
            //string logFilePath = "E:/Sistemas/G.Operaciones/BACK_EPP/";
            string logFilePath = ConfigurationManager.AppSettings["LogFilePath"].ToString();

            logFilePath = logFilePath + "/Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);

            strLog = string.Format("ERROR : {0}", strLog);

            log.WriteLine(strLog);
            log.Close();
        } 
    }
}