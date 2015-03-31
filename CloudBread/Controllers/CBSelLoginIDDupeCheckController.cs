﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;

using System.Threading.Tasks;
using System.Diagnostics;
using Logger.Logging;
using CloudBread.globals;
using CloudBreadLib.BAL.Crypto;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace CloudBread.Controllers
{
    public class CBSelLoginIDDupeCheckController : ApiController
    {
        public ApiServices Services { get; set; }

        public class InputParams { public string memberID;}

        public string Post(InputParams p)
        {
            string result = "";
            
            Logging.CBLoggers logMessage = new Logging.CBLoggers();
            string jsonParam = JsonConvert.SerializeObject(p);

            try 
	        {	        
		        using(SqlConnection connection = new SqlConnection(globalVal.DBConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("CloudBread.uspSelLoginIDDupeCheck", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@MemberID", SqlDbType.NVarChar, -1).Value = p.memberID;
                        connection.Open();
                        using(SqlDataReader dreader = command.ExecuteReader())
                        { 
                            while(dreader.Read())
                            {
                                result = dreader[0].ToString();
                            }
                            dreader.Close();
                        }
                        connection.Close();

                        return result;
                    }
	            }
            }
        
	        catch (Exception ex)
	        {
                //에러로그
                logMessage.memberID = p.memberID;
                logMessage.Level = "ERROR";
                logMessage.Logger = "CBSelLoginIDDupeCheckController";
                logMessage.Message = jsonParam;
                logMessage.Exception = ex.ToString();
                Logging.RunLog(logMessage);

                throw;
	        }
        }
    }
}
