﻿/**
* @file CBComUdtMemberItemController
* @brief Common API for a MemberItem update on MemberItems table. \n
* Set parameter null or remove json property for no change on column data.
* @author Dae Woo Kim
* @param MemberItem object
* @return string "1" - affected rows
* @see uspComUdtMemberItem SP, BehaviorID : B054
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Config;

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
    [MobileAppController]
    public class CBComUdtMemberItemController : ApiController
    {
        public class InputParams
        {
            public string MemberItemID { get; set; }
            public string MemberID { get; set; }
            public string ItemListID { get; set; }
            public string ItemCount { get; set; }
            public string ItemStatus { get; set; }
            public string sCol1 { get; set; }
            public string sCol2 { get; set; }
            public string sCol3 { get; set; }
            public string sCol4 { get; set; }
            public string sCol5 { get; set; }
            public string sCol6 { get; set; }
            public string sCol7 { get; set; }
            public string sCol8 { get; set; }
            public string sCol9 { get; set; }
            public string sCol10 { get; set; }
        }

        public string Post(InputParams p)
        {
            string result = "";
            
            Logging.CBLoggers logMessage = new Logging.CBLoggers();
            string jsonParam = JsonConvert.SerializeObject(p);

            try
            {
                // task start log
                //logMessage.memberID = p.MemberID;
                //logMessage.Level = "INFO";
                //logMessage.Logger = "CBComUdtMemberItemController";
                //logMessage.Message = jsonParam;
                //Logging.RunLog(logMessage);

                using (SqlConnection connection = new SqlConnection(globalVal.DBConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("CloudBread.uspComUdtMemberItem", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@MemberItemID ", SqlDbType.NVarChar, -1).Value = p.MemberItemID;
                        command.Parameters.Add("@MemberID ", SqlDbType.NVarChar, -1).Value = p.MemberID;
                        command.Parameters.Add("@ItemListID ", SqlDbType.NVarChar, -1).Value = p.ItemListID;
                        command.Parameters.Add("@ItemCount ", SqlDbType.NVarChar, -1).Value = p.ItemCount;
                        command.Parameters.Add("@ItemStatus ", SqlDbType.NVarChar, -1).Value = p.ItemStatus;
                        command.Parameters.Add("@sCol1 ", SqlDbType.NVarChar, -1).Value = p.sCol1;
                        command.Parameters.Add("@sCol2 ", SqlDbType.NVarChar, -1).Value = p.sCol2;
                        command.Parameters.Add("@sCol3 ", SqlDbType.NVarChar, -1).Value = p.sCol3;
                        command.Parameters.Add("@sCol4 ", SqlDbType.NVarChar, -1).Value = p.sCol4;
                        command.Parameters.Add("@sCol5 ", SqlDbType.NVarChar, -1).Value = p.sCol5;
                        command.Parameters.Add("@sCol6 ", SqlDbType.NVarChar, -1).Value = p.sCol6;
                        command.Parameters.Add("@sCol7 ", SqlDbType.NVarChar, -1).Value = p.sCol7;
                        command.Parameters.Add("@sCol8 ", SqlDbType.NVarChar, -1).Value = p.sCol8;
                        command.Parameters.Add("@sCol9 ", SqlDbType.NVarChar, -1).Value = p.sCol9;
                        command.Parameters.Add("@sCol10 ", SqlDbType.NVarChar, -1).Value = p.sCol10;

                        connection.Open();
                        using (SqlDataReader dreader = command.ExecuteReader())
                        {
                            while (dreader.Read())
                            {
                                result = dreader[0].ToString();
                            }
                            dreader.Close();
                        }
                        connection.Close();

                        // task end log
                        logMessage.memberID = p.MemberID;
                        logMessage.Level = "INFO";
                        logMessage.Logger = "CBComUdtMemberItemController";
                        logMessage.Message = jsonParam;
                        Logging.RunLog(logMessage);

                        return result;
                    }

                }
            }

            catch (Exception ex)
            {
                //에러로그
                logMessage.memberID = p.MemberID;
                logMessage.Level = "ERROR";
                logMessage.Logger = "CBComUdtMemberItemController";
                logMessage.Message = jsonParam;
                logMessage.Exception = ex.ToString();
                Logging.RunLog(logMessage);

                throw;
            }
        }

    }
}
