using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootstrapIntro.Models
{
    public class QueryOptions
    {
        public string SortField { get; set; }
        public SortOrder SortOrder { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public QueryOptions()
        {
            SortField = "Id";
            SortOrder = SortOrder.ASC;

            CurrentPage = 1;
            PageSize = 5;
        }

        public string Sort
        {
            get
            {
                return string.Format("{0} {1}", SortField, SortOrder.ToString());
            }
        }
    }
}