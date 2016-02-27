﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CloudBread.globals
{
    public static class globalVal
    {
        public static string DBConnectionString = WebConfigurationManager.ConnectionStrings["CloudBreadDBConString"].ConnectionString;

        public static string StorageConnectionString = WebConfigurationManager.AppSettings["CloudBreadStorageConString"];

        public static string CloudBreadLoggerSetting = WebConfigurationManager.AppSettings["CloudBreadLoggerSetting"].ToString();
        public static string CloudBreadCryptSetting = WebConfigurationManager.AppSettings["CloudBreadCryptSetting"].ToString();
        public static int conRetryCount = int.Parse(WebConfigurationManager.AppSettings["CloudBreadconRetryCount"]);    /// adding v2.0.0
        public static int conRetryFromSeconds = int.Parse(WebConfigurationManager.AppSettings["CloudBreadconRetryFromSeconds"]);     /// adding v2.0.0
        public static string CloudBreadSocketKeyText = WebConfigurationManager.AppSettings["CloudBreadSocketKeyText"];     /// adding v2.0.0
        public static string CloudBreadSocketKeyIV = WebConfigurationManager.AppSettings["CloudBreadSocketKeyIV"];     /// adding v2.0.0

        public static string CloudBreadSocketRedisServer = WebConfigurationManager.AppSettings["CloudBreadSocketRedisServer"];     /// adding v2.0.0
        public static string CloudBreadSocketRedisPassword = WebConfigurationManager.AppSettings["CloudBreadSocketRedisPassword"];     /// adding v2.0.0
        public static int CloudBreadSocketAuthTokenTTL = int.Parse(WebConfigurationManager.AppSettings["CloudBreadSocketAuthTokenTTL"]);     /// adding v2.0.0

        public static string CloudBreadRankRedisServer = WebConfigurationManager.AppSettings["CloudBreadSocketKeyText"];     /// adding v2.0.0
        public static string CloudBreadRankRedisPassword = WebConfigurationManager.AppSettings["CloudBreadRankRedisPassword"];     /// adding v2.0.0

        public static string CloudBreadGameLogRedisServer = WebConfigurationManager.AppSettings["CloudBreadGameLogRedisServer"];     /// adding v2.0.0
        public static string CloudBreadGameLogRedisPassword = WebConfigurationManager.AppSettings["CloudBreadGameLogRedisPassword"];     /// adding v2.0.0

    }
}