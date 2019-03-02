using Foundation.RedirectManager.Services.RedirectManager.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.Data;
using System.Collections.Generic;
using System.Linq;

namespace Foundation.RedirectManager.Services.RedirectManager.Repositories
{
    public class RedirectRepository : IRedirectRepository
    {
        public List<RedirectResultItem> GetRedirects()
        {
            var redirectTemplateId = new ID(Sitecore.Configuration.Settings.GetSetting(Constants.RedirectTemplateId));
            var index = ContentSearchManager.GetIndex("sitecore_web_index");
            using (var context = index.CreateSearchContext())
            {
                var search = context.GetQueryable<RedirectResultItem>()
                    .Where(x => x.TemplateId == redirectTemplateId)
                    .Where(x => x.Path.Contains(Sitecore.Constants.ContentPath));
                var redirectResults = search.GetResults();
                return redirectResults.Select(r => r.Document).ToList();
            }
        }
    }
}
