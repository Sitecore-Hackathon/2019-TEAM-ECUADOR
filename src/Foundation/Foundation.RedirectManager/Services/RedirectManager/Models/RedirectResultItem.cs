using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;

namespace Foundation.RedirectManager.Services.RedirectManager.Models
{
    public class RedirectResultItem : SearchResultItem
    {
        [IndexField("old_url_t")]
        public string OldUrl { get; set; }

        [IndexField("new_url_t")]
        public string NewUrl { get; set; }

        [IndexField("preserve_query_string_b")] 
        public bool KeepParams { get; set; }

        [IndexField("redirectType")]
        public string RedirectType { get; set; }
    }
}
