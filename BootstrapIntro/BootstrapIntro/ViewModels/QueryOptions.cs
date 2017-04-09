using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BootstrapIntro.ViewModels
{
    public class QueryOptions
    {
        public QueryOptions()
        {
            SortField = "Id";
            SortOrder = SortOrder.ASC;

            CurrentPage = 1;
            PageSize = 5;
        }


        [JsonProperty(PropertyName ="sortField")]
        public string SortField { get; set; }

        [JsonProperty(PropertyName = "sortOrder")]
        public SortOrder SortOrder { get; set; }

        [JsonProperty(PropertyName = "currentPage")]
        public int CurrentPage { get; set; }

        [JsonProperty(PropertyName = "pageSize")]
        public int PageSize { get; set; }

        [JsonProperty(PropertyName = "totalPages")]
        public int TotalPages { get; set; }

        public string Sort
        {
            get
            {
                return string.Format("{0} {1}", SortField, SortOrder.ToString());
            }
        }
    }
}