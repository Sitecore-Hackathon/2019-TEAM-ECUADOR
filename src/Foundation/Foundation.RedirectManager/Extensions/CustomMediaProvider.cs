using Sitecore.Data.Items;
using Sitecore.Resources.Media;

namespace Foundation.RedirectManager.Extensions
{

    /// <summary>
    /// Set the AlwaysIncludeServerUrl to false so the relative path can be taken but the Node.js server.
    /// Otherwise Images will be pointing to the CD Sitecore instance
    /// </summary>
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
