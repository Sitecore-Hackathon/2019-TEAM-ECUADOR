using Sitecore.Diagnostics;
using Sitecore.Publishing.Pipelines.PublishItem;
using System;
using System.IO;
using System.Net;

namespace Foundation.RedirectManager.Extensions
{
    public class NodeCacheClearer : Sitecore.Publishing.RemotePublishingEventHandler
    {
        public void ItemProcessed(object sender, EventArgs args)
        {
            var itemProcessedEventArgs = args as ItemProcessedEventArgs;
            
            var context = itemProcessedEventArgs?.Context;
            
            if (context == null) return;
            
            var item = context.PublishHelper?.GetSourceItem(context.ItemId);
            
            if (item!=null && !item.TemplateID.ToString().Contains(Sitecore.Configuration.Settings.GetSetting(Constants.RedirectTemplateId))) return;
            
            var request = (HttpWebRequest)WebRequest.Create(Sitecore.Configuration.Settings.GetSetting(Constants.ClearNodeCacheUrl));
           
            request.Method = "GET";
            
            var webResponse = (HttpWebResponse) request.GetResponse();

            if (webResponse.StatusCode != HttpStatusCode.OK)
            {
                Log.Error("Error while deleting cache in the Node server. ReponseStream is null", this);
            }            
        }
    }
}
