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
        public static int SYS_ERR_JUDGMENT_TIME = 0;

        /// <summary>
        /// Waiting time to resend request when system error occurs
        /// </summary>
        public static int SYS_ERR_RETRY_WAIT_TIME = 0;

        /// <summary>
        /// Waiting time to resend request start inspection
        /// </summary>
        public static int EXAM_RETRY_WAIT_TIME = 0;

        /// <summary>
        /// Screen scrolling timeout
        /// </summary>
        public static int SCREEN_TRANSITION_WAITING_TIME = 0;

        /// <summary>
        /// Url of YuKu_API
        /// </summary>
        public static string YUKU_API_URL = "";
        /// <summary>
        /// Default Facetory name
        /// </summary>
        public static string DEFAULT_FACTORY_NAME = "";
        public static bool InitData()
        {
            try
            {
                if (ConfigurationManager.AppSettings["APP_DEFAULT"] != null)
                    APP_DEFAULT = ConfigurationManager.AppSettings["APP_DEFAULT"].ToString();

                if (ConfigurationManager.AppSettings["SYS_ERR_JUDGMENT_TIME"] != null)
                    SYS_ERR_JUDGMENT_TIME = int.Parse(ConfigurationManager.AppSettings["SYS_ERR_JUDGMENT_TIME"].ToString());

                if (ConfigurationManager.AppSettings["SYS_ERR_RETRY_WAIT_TIME"] != null)
                    SYS_ERR_RETRY_WAIT_TIME = int.Parse(ConfigurationManager.AppSettings["SYS_ERR_RETRY_WAIT_TIME"].ToString());

                if (ConfigurationManager.AppSettings["EXAM_RETRY_WAIT_TIME"] != null)
                    EXAM_RETRY_WAIT_TIME = int.Parse(ConfigurationManager.AppSettings["EXAM_RETRY_WAIT_TIME"].ToString());

                if (ConfigurationManager.AppSettings["SCREEN_TRANSITION_WAITING_TIME"] != null)
                    SCREEN_TRANSITION_WAITING_TIME = int.Parse(ConfigurationManager.AppSettings["SCREEN_TRANSITION_WAITING_TIME"].ToString());

                if (ConfigurationManager.AppSettings["YUKU_API_URL"] != null)
                    YUKU_API_URL = ConfigurationManager.AppSettings["YUKU_API_URL"].ToString();
                if (ConfigurationManager.AppSettings["DEFAULT_FACTORY_NAME"] != null)
                    DEFAULT_FACTORY_NAME = ConfigurationManager.AppSettings["DEFAULT_FACTORY_NAME"].ToString();

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
