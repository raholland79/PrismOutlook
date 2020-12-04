using Prism.Regions;
using Telerik.Windows.Controls;

namespace PrismOutlook.Core.Regions
{
    public class RadOutlookBarRegionAdapter : RegionAdapterBase<RadOutlookBar>
    {
        public RadOutlookBarRegionAdapter(IRegionBehaviorFactory factory) : base(factory)
        {

        }

        protected override void Adapt(IRegion region, RadOutlookBar regionTarget)
        {
           region.Views.CollectionChanged += ((s,e) =>
           {
               switch (e.Action)
               {
                   case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                       {
                           foreach  (var group in e.NewItems)
                           {
                               regionTarget.Items.Add(group);

                               // manually select the first group
                               if (regionTarget.Items[0] == group)
                               {
                                   regionTarget.SelectedItem = group;
                               }
                           }
                           break;
                       }
                   case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                       {
                           foreach (var group in e.NewItems)
                           {
                               regionTarget.Items.Remove(group);
                           }
                           break;

                       }
               }
           });
        }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }
    }
}
