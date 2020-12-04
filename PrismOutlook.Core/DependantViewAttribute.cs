using System;

namespace PrismOutlook.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DependantViewAttribute : Attribute
    {
        
        public string Region { get; set; }
        public Type Type { get; set; }

        public DependantViewAttribute(string region, Type type)
        {
            Region = region ?? throw new ArgumentNullException(nameof(region));
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }

    }
}
