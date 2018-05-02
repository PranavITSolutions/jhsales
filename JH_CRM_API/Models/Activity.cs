using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JH_CRM_API.Models
{
    public class Activity
    {
        public string id { get; set; }
        public List<string> keywords { get; set; }

        public string MDH_MSTR_PRODUCT_ID { get; set; }
        public string STRATEGY_ID { get; set; }
        public string STRATEGY_NM { get; set; }
        public string STRATEGY_DESC { get; set; }

    }
}