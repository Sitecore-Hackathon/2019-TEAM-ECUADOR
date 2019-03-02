using Foundation.RedirectManager.Services.RedirectManager.Models;
using System.Collections.Generic;

namespace Foundation.RedirectManager.Services.RedirectManager.Repositories
{
    public interface IRedirectRepository
    {
        /// <summary>
        /// Gets the redirects inside sitecore/content that use the redirect template
        /// </summary>
        List<RedirectResultItem> GetRedirects();
    }
}
