﻿using FAP_Attendance.Models;
using System.Collections.ObjectModel;

namespace PCS_APP
{
    /// <summary>
    /// Config data global
    /// </summary>
    public class SessionData
    {
        #region Fields

        /// <summary>
        /// Information of the active user on the system
        /// </summary>
        public static User _User { get; set; }

        
        
        #endregion

        /// <summary>
        /// Add data in to session
        /// </summary>
        public static bool InitSessionData<T>(T data)
        {
            if(data != null) 
            {
                if (typeof(User) == typeof(T))
                {
                    _User = data as User;
                    return true;
                }
                else
                    return false;
            }
            return false;
        }

        /// <summary>
        /// Clear data in session
        /// </summary>
        public static void ClearSession()
        {
            _User = new User();
        }
    }
}