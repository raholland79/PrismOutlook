using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace PrismOutlook.Core.Regions
{
    public class DependentViewRegionBehavior : RegionBehavior
    {

        // Region behavior uses a unique key
        // This is how register a region behavior with Prism
        // You can override something and register with an adapter or do it in app.xaml.cs using
        // this key globally - so all regions get the behavior.
        public const string BehaviorKey = "DependentViewRegionBehavior";
        private readonly IContainerExtension _container;

        Dictionary<object, List<DependentViewInfo>> _dependentViewCache = new Dictionary<object, List<DependentViewInfo>>();

        public DependentViewRegionBehavior(IContainerExtension container)        
        {
            _container = container;
        }

        protected override void OnAttach()
        {
            // ActiveViews because the Region puts views in like a stack, adding on top but they stay there in the stack
            // unless we explicitly remove - otherwise you activate the view when changing which pulls the view from stack and pushes 
            // to the top.  This is active views.
            Region.ActiveViews.CollectionChanged += ActiveViews_CollectionChanged;
        }

        private void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var newView in e.NewItems)
                {
                    var dependentViews = new List<DependentViewInfo>();

                    //check if view already has dependents
                    //use or create 
                    if (_dependentViewCache.ContainsKey(newView))
                    {
                        dependentViews = _dependentViewCache[newView];
                    }
                    else
                    {
                        //get the attributes
                        var atts = GetCustomAttributes<DependantViewAttribute>(newView.GetType());
                        foreach (var att in atts)
                        {
                            //create the view
                            var info = CreateDependentViewInfo(att);

                            if (info.View is ISupportDataContext infoDC && newView is ISupportDataContext viewDC)
                            {
                                infoDC.DataContext = viewDC.DataContext;
                            }
                                

                            dependentViews.Add(info);
                        }

                        _dependentViewCache.Add(newView, dependentViews);
                    }


                    dependentViews.ForEach(item => Region.RegionManager.Regions[item.Region].Add(item.View));

                }
                
                //for each att we need to create the view, find the region, then inject<view> into region.
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var oldView in e.OldItems)
                {
                    if (_dependentViewCache.ContainsKey(oldView))
                    {

                        var dependentViews = _dependentViewCache[oldView];
                        dependentViews.ForEach(item => Region.RegionManager.Regions[item.Region].Remove(item.View));
                        if (!ShouldKeepAlive(oldView))
                            _dependentViewCache.Remove(oldView);
                    }
                }
            }
        }

        private bool ShouldKeepAlive(object oldView)
        {
            var regionLifetime = GetViewOrDataContextLifeTime(oldView);
            if (regionLifetime != null)
                return regionLifetime.KeepAlive;
            
            return true;
        }

        IRegionMemberLifetime GetViewOrDataContextLifeTime(object view)
        {
            if (view is IRegionMemberLifetime regionLifeTime)
            {
                return regionLifeTime;
            } else 
            if (view is FrameworkElement frameworkElement)
            {
                return frameworkElement.DataContext as IRegionMemberLifetime;
            }

            return null;
            
        }

        private static IEnumerable<T> GetCustomAttributes<T>(Type type)
        {
            return type.GetCustomAttributes(typeof(T), true).OfType<T>();
        }

        DependentViewInfo CreateDependentViewInfo(DependantViewAttribute attribute)
        {
            return new DependentViewInfo
            {
                Region = attribute.Region,
                View = _container.Resolve(attribute.Type)
            };
        }
    }
}
