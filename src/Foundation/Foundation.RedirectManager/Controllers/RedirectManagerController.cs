using Foundation.RedirectManager.Services.RedirectManager.Factories;
using Foundation.RedirectManager.Services.RedirectManager.Models;
using Foundation.RedirectManager.Services.RedirectManager.Repositories;
using Sitecore.Mvc.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace Foundation.RedirectManager.Controllers
{
    public class RedirectManagerController : SitecoreController
    {
        private IRedirectRepository _redirectRepository;
        public RedirectManagerController()
        {
            _redirectRepository = RedirectRepositoryFactory.Build();
        }

        [HttpGet]
        public ActionResult GetRedirects()
        {
            var redirectSearchResults = _redirectRepository.GetRedirects();
            var redirects = redirectSearchResults.Select(r => new RedirectJsonModel
            {
                Type = r.RedirectType,
                OldUrl = r.OldUrl,
                NewUrl = r.NewUrl,
                KeepParams = r.KeepParams
            }).ToList();
            return Json(redirects, JsonRequestBehavior.AllowGet);

        }
    }
}
