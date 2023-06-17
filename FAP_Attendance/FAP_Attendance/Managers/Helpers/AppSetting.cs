using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP_Attendance.Helpers
{
    public static class AppSetting
    {
        /// <summary>
        /// Config app run default
        /// </summary>
        public static string APP_DEFAULT = "";

        /// <summary>
        /// Timeout no response from the system
        /// </summary>
        public static string SYS_ERR_JUDGMENT_TIME = "";

        /// <summary>
        /// Waiting time to resend request when system error occurs
        /// </summary>
        public static string SYS_ERR_RETRY_WAIT_TIME = "";

        /// <summary>
        /// Waiting time to resend request start inspection
        /// </summary>
        public static string EXAM_RETRY_WAIT_TIME = "";

        /// <summary>
        /// Screen scrolling timeout
        /// </summary>
        public static string SCREEN_TRANSITION_WAITING_TIME = "";

        public static bool InitData()
        {
            try
            {
                if (ConfigurationManager.AppSettings["APP_DEFAULT"] != null)
                    APP_DEFAULT = ConfigurationManager.AppSettings["APP_DEFAULT"].ToString();

                if (ConfigurationManager.AppSettings["SYS_ERR_JUDGMENT_TIME"] != null)
                    SYS_ERR_JUDGMENT_TIME = ConfigurationManager.AppSettings["SYS_ERR_JUDGMENT_TIME"].ToString();

                if (ConfigurationManager.AppSettings["SYS_ERR_RETRY_WAIT_TIME"] != null)
                    SYS_ERR_RETRY_WAIT_TIME = ConfigurationManager.AppSettings["SYS_ERR_RETRY_WAIT_TIME"].ToString();

                if (ConfigurationManager.AppSettings["EXAM_RETRY_WAIT_TIME"] != null)
                    EXAM_RETRY_WAIT_TIME = ConfigurationManager.AppSettings["EXAM_RETRY_WAIT_TIME"].ToString();

                if (ConfigurationManager.AppSettings["SCREEN_TRANSITION_WAITING_TIME"] != null)
                    SCREEN_TRANSITION_WAITING_TIME = ConfigurationManager.AppSettings["SCREEN_TRANSITION_WAITING_TIME"].ToString();

                return true;
            }
            catch (System.Exception ex)
            {
                Logger.log.Error(ex.ToString());
                return false;
            }
        }
    }
}
