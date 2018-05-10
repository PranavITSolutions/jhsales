
using Dapper;
using JH_CRM_API.Models;
using JH_CRM_API.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace JH_CRM_API.Repository
{
    public class BotRepo
    {
        public static FinanceModel GetFinanceByTicker(string ticker)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[Constants.DB_CONNECTION_STR_NAME].ConnectionString))
                {
                    string query = " SELECT * FROM finance WHERE ticker = @ticker";
                    return db.Query<FinanceModel>(query, new { ticker = ticker }).FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                throw exception;
            }
        }

        public static List<FinanceModel> GetFinanceList()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[Constants.DB_CONNECTION_STR_NAME].ConnectionString))
                {
                    string query = " SELECT * FROM finance";
                    return db.Query<FinanceModel>(query).ToList();
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                throw exception;
            }
        }



        public static FinanceModel GetFactsheet(string name)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[Constants.DB_CONNECTION_STR_NAME].ConnectionString))
                {
                    string query = " SELECT * FROM finance WHERE name like '%" + name + "%'";
                    return db.Query<FinanceModel>(query).FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                throw exception;
            }
        }

        public static List<ActivityDTO> GetTopClientList()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[Constants.SALES_DB_CONNECTION_STR_NAME].ConnectionString))
                {
                    string query = " SELECT TOP 10 [ContactName] AS customerName, AVG(Sentiment_Score) AS score,COUNT(*) AS count FROM [dbo].[Meetings] "
                            +" WHERE[Is_Processed] = 1  GROUP BY[ContactName]  HAVING AVG(Sentiment_Score) > 0.8  ORDER BY COUNT(*) DESC";
                    return db.Query<ActivityDTO>(query).ToList();
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                throw exception;
            }
        }


        public static List<ActivityDTO> GetClientsToFocusList()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[Constants.SALES_DB_CONNECTION_STR_NAME].ConnectionString))
                {
                    string query = " SELECT TOP 10 [ContactName] AS customerName, AVG(Sentiment_Score) AS score,COUNT(*) AS count FROM [dbo].[Meetings] "
                            + " WHERE[Is_Processed] = 1  GROUP BY [ContactName] HAVING AVG(Sentiment_Score) < 0.2  ORDER BY COUNT(*) DESC";
                    return db.Query<ActivityDTO>(query).ToList();
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                throw exception;
            }
        }


        public static ActivityDTO GetClientByName(string name)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[Constants.SALES_DB_CONNECTION_STR_NAME].ConnectionString))
                {
                    string query = " SELECT  [ContactName] AS customerName, AVG(Sentiment_Score) AS score,[BusinessUnit] AS businessUnit,Count(*) AS meetings FROM [dbo].[Meetings]"
                        +" WHERE [Is_Processed] = 1 AND[ContactName] like '%"+ name+"%'  GROUP BY[ContactName],[BusinessUnit] ";
                    return db.Query<ActivityDTO>(query).FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                throw exception;
            }
        }

        public static ActivityDTO GetAgentByID(string id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[Constants.SALES_DB_CONNECTION_STR_NAME].ConnectionString))
                {
                    string query = " SELECT  [DSTRepID] AS repId, AVG(Sentiment_Score) AS score,Count(*) AS count FROM [dbo].[Meetings] "
                        +" WHERE [Is_Processed] = 1 AND [DSTRepID] = @id  GROUP BY[DSTRepID] ";
                    return db.Query<ActivityDTO>(query, new { id = id}).FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                throw exception;
            }
        }


        public static List<ActivityDTO> GetPerformanceByBU()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[Constants.SALES_DB_CONNECTION_STR_NAME].ConnectionString))
                {
                    string query = " SELECT  AVG(Sentiment_Score) AS score,[BusinessUnit] AS businessUnit,Count(*) AS count FROM [dbo].[Meetings] WHERE [Is_Processed] = 1 AND [BusinessUnit] IS NOT NULL GROUP BY[BusinessUnit]  ORDER BY Count(*) DESC";
                    return db.Query<ActivityDTO>(query).ToList();
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                throw exception;
            }
        }


        public static List<ActivityDTO> GetSalesRepNeedsTraining()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[Constants.SALES_DB_CONNECTION_STR_NAME].ConnectionString))
                {
                    string query = " SELECT TOP 5 [DSTRepID] AS repId, AVG(Sentiment_Score) AS score,Count(*) AS count FROM [dbo].[Meetings] "
                        + " WHERE[Is_Processed] = 1 AND[DSTRepID] IS NOT NULL GROUP BY[DSTRepID] HAVING Count(*) > 8 AND AVG(Sentiment_Score) < 0.5 ORDER BY AVG(Sentiment_Score) ";
                    return db.Query<ActivityDTO>(query).ToList();
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                throw exception;
            }
        }


        public static List<ActivityDTO> GetTopPerformingSalesRep()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[Constants.SALES_DB_CONNECTION_STR_NAME].ConnectionString))
                {
                    string query = "SELECT TOP 5[DSTRepID] AS repId, AVG(Sentiment_Score)AS score, Count(*) AS count FROM[dbo].[Meetings] "
                        + " WHERE[Is_Processed] = 1 AND[DSTRepID] IS NOT NULL GROUP BY[DSTRepID] HAVING Count(*) > 5 AND AVG(Sentiment_Score) > 0.7 ORDER BY AVG(Sentiment_Score) DESC";
                    return db.Query<ActivityDTO>(query).ToList();
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                throw exception;
            }
        }



    }
}