using Sitecore.Data.Items;
using Sitecore.Resources.Media;

namespace Foundation.RedirectManager.Extensions
{
    public class CustomMediaProvider : MediaProvider
    {
        public override string GetMediaUrl(MediaItem item, MediaUrlOptions options)
        {
            options.AlwaysIncludeServerUrl = false;

            options.AbsolutePath = false;

            var mediaUrl = base.GetMediaUrl(item, options);

            return mediaUrl;
        }
    }
}
