﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JH_CRM_API.Utility
{
    public class Constants
    {
        public static string SALES_DB_CONNECTION_STR_NAME = "SalesDBConnString";
        public const string ACTION_CHECK_CLIENT_PERFORMANCE = "Check Client Performance";
        public const string ACTION_CHECK_SALESREP_PERFORMANCE = "Check SalesRep Performance";
        public const string ACTION_PERFORMANCE_BY_BU = "Performance by Business Unit";
        public const string ACTION_PERFORMANCE_BY_PRODUCTS = "Performance by Products";
        public const string ACTION_INVESTING_GUIDE = "JH Investing Guide";
        public const string ACTION_TOP_CLIENTS = "Top Performing Clients";
        public const string ACTION_CLIENTS_TO_FOCUS = "Clients to Focus";
        public const string ACTION_SCHEDULE_MEETING = "SetUp Meeting";


        public const string ACTION_TOP_SALES_REP = "Top Performing sales reps";
        public const string ACTION_SALESREP_NEEDS_TRAINING = "Sales Reps - Need Training";

        public static List<SendGrid.Helpers.Mail.EmailAddress> EMAILS = new List<SendGrid.Helpers.Mail.EmailAddress>
                    {
                        new SendGrid.Helpers.Mail.EmailAddress("paul.algreen@janushenderson.com","Paul Algreen"),
                        new SendGrid.Helpers.Mail.EmailAddress("cyril.obot@janushenderson.com", "Cyril Obot")
                    };
        public static List<String> ACTION_CHECK_SCORE_OPTIONS = new List<string> { "Customer", "Agent", "Business Unit","Product" };
        public static List<String> CONFIRMATION_OPTIONS = new List<string> { "Yes", "No" };
        public const string ACTION_CHECK_SCORE_OPTION_CUSTOMER = "Customer";
        public const string ACTION_CHECK_SCORE_OPTION_AGENT = "Agent";
        public const string ACTION_CHECK_SCORE_OPTION_BU = "Business Unit";
        public const string ACTION_CHECK_SCORE_OPTION_PRODUCT = "Product";
        public const string CONFIRMATION_YES = "yes";
        public const string CONFIRMATION_NO = "no";


        public const string INTENT_GREETING = "Greeting";
        public const string INTENT_CHECK_CLIENT_PERFORMANCE = "CheckClientPerformance";
        public const string INTENT_THANK = "Thank";
        public const string INTENT_BYE = "Bye";
        public const string INTENT_NONE = "None";

        public const string INTENT_CHECK_SALESREP_PERFORMANCE = "CheckSalesRepPerformance";
        public const string INTENT_PERFORMANCE_BY_BU = "PerformanceByBU";
        public const string INTENT_PERFORMANCE_BY_PRODUCTS = "PerformanceByProducts";
        public const string INTENT_INVESTING_GUIDE = "JHInvestingGuide";
        public const string INTENT_MARKET_INSIGHTS = "MarketInsights";
        public const string INTENT_TOP_CLIENTS = "TopClients";
        public const string INTENT_CLIENTS_TO_FOCUS = "ClientsToFocus";
        public const string INTENT_TOP_SALESREP = "TopSalesRep";
        public const string INTENT_SALESREP_NEEDS_TRAINING = "NeedTraining";
        public const string INTENT_SCHEDULE_MEETING = "ScheduleMeeting";

        //CRP BOT Constants
        public static string DB_CONNECTION_STR_NAME = "DBConnString";
        public static string JH_LOGO = "https://callcenterfunct82f0.blob.core.windows.net/logo/jh-logo.png";

        public static List<String> ACTIONS = new List<string> { "Get Performance", "Get MorningStar Ratings",
            "Get Pricing", "Get Factsheet", "Get Portfolio Commentary", "Get Annual Report", "Get Fund Holdings" };

        public static List<String> FUNDS = new List<string> { "High Yield Fund", "Global Equity Income Fund",
                                                              "Flexible Bond Fund", "Multi Sector Income Fund",
                                                              "Strategic Income Fund"};

        public const string ACTION_GET_PERFORMANCE = "Get Performance";
        public const string ACTION_GET_RATING = "Get MorningStar Ratings";
        public const string ACTION_GET_PRICING = "Get Pricing";
        public const string ACTION_GET_FACTSHEET = "Get Factsheet";
        public const string ACTION_GET_PORTFOLIO = "Get Portfolio Commentary";
        public const string ACTION_GET_REPORT = "Get Annual Report";
        public const string ACTION_GET_HOLDING = "Get Fund Holdings";
        public const string ACTION_GET_MARKET_INSIGHTS = "Market Insights";

        public const string FACTSHEET = "FACTSHEET";
        public const string PORTFOLIO = "PORTFOLIO";
        public const string ANNUALREPORT = "ANNUALREPORT";
        public const string FUNDHOLDING = "FUNDHOLDING";

        public const string FUND_HIGH_YIELD = "High Yield Fund";
        public const string FUND_GLOBAL_EQUITY = "Global Equity Income Fund";
        public const string FUND_FLEXIBLE_BOND = "Flexible Bond Fund";
        public const string FUND_MULTISECTOR = "Multi Sector Income Fund";
        public const string FUND_STRATEGIC = "Strategic Income Fund";



        public const string REMEMBER_MEETING_TITLE = "meeting_title";
        public const string REMEMBER_MEETING_TIMES = "meeting_time";
    }
}