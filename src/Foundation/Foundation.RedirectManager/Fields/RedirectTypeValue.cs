using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace Foundation.RedirectManager.Fields
{
    public class RedirectTypeValue : IComputedIndexField
    {
        public object ComputeFieldValue(IIndexable indexable)
        {
            Assert.ArgumentNotNull(indexable, "indexable");

            if (!(indexable is SitecoreIndexableItem scIndexableItem))
            {
                Log.Warn($"Unsupported IIndexable type : {indexable.GetType()}" , this);

                return null;
            }

            Item item = scIndexableItem;

            if (!item.TemplateID.ToString()
                .Contains(Sitecore.Configuration.Settings.GetSetting(Constants.RedirectTemplateId)))
                return null;

            // Get the alt field from the sitecore item.
            var redirectTypeId = item.Fields["redirect type"]?.Value;
            if (string.IsNullOrWhiteSpace(redirectTypeId))
            {
                return null;
                
            }
            var redirectItem = item.Database.GetItem(redirectTypeId);
            if (redirectItem == null)
            {
                return null;
                
            }
            var redirectItemValue = redirectItem.Fields["Value"]?.Value;
            return !string.IsNullOrWhiteSpace(redirectItemValue) ? redirectItemValue.ToLowerInvariant().Trim() : null;
        }

        public string FieldName { get; set; }
        public string ReturnType { get; set; }
    }
}
