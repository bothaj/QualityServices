using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace QualityServices.Managers
{
    public class VariableManager
    {
        /// <summary>
        /// Accessor to the Content Storage application config setting. 
        /// Enables easy access.
        /// </summary>
        public static string ContentStoragePath
        {
            get
            {
                return (string)ConfigurationSettings.AppSettings["ContentStoragePath"];
            }
        }

        /// <summary>
        /// Accessor to the Content Storage application config setting. 
        /// Enables easy access.
        /// </summary>
        public static string WebStoragePath
        {
            get
            {
                return (string)ConfigurationSettings.AppSettings["WebStoragePath"];
            }
        }

        /// <summary>
        /// Accessor to the Content Storage application config setting. 
        /// Enables easy access.
        /// </summary>
        public static bool HasGolfFeed
        {
            get
            {
                return ConfigurationSettings.AppSettings["HasGolfFeed"] == "true";
            }
        }

        public static bool DBPics
        {
            get
            {
                return ConfigurationSettings.AppSettings["DBPics"] == "true";
            }
        }
    }
}