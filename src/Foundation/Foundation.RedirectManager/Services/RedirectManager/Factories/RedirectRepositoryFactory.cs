using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation.RedirectManager.Services.RedirectManager.Repositories;

namespace Foundation.RedirectManager.Services.RedirectManager.Factories
{

    class RedirectRepositoryFactory
    {
        /// <summary>
        /// Instance of IRedirectRepository.
        /// </summary>
        private static IRedirectRepository _redirectRepository;

        /// <summary>
        /// Static constructor for the RedirectRepositoryFactory class that instantiates the instance of IRedirectRepository.
        /// </summary>
        static RedirectRepositoryFactory()
        {
            _redirectRepository = new RedirectRepository();
        }

        /// <summary>
        /// Returns a instance of class that implements the IRedirectRepository interface.
        /// </summary>
        public static IRedirectRepository Build()
        {
            return _redirectRepository;
        }
    }
}
