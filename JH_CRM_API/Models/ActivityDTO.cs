using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JH_CRM_API.Models
{
    public class ActivityDTO
    {

        public string businessUnit { get; set; }
        public decimal? score { get; set; }
        public int count { get; set; }
        public string customerName { get; set; }

        public string salesRepName { get; set; }

        public string repId { get; set; }

        public string productId { get; set; }
        public string productName { get; set; }
    }
}