using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;

namespace Foundation.RedirectManager.Services.RedirectManager.Models
{
    [Serializable]
    public class RedirectJsonModel
    {
        public string OldUrl { get; set; }
        
        public string NewUrl { get; set; }
        
        public bool KeepParams { get; set; }
        
        public string Type { get; set; }

    }
}
