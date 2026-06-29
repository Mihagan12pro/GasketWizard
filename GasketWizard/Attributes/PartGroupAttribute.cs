using System;
using System.Collections.Generic;
using System.Globalization;

namespace GasketWizard.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PartGroupAttribute : Attribute
    {
        private readonly Dictionary<CultureInfo, string> _partGroupsLocalized;

        public string Group {  get; set; }

        public string LocalizedGroup
        {
            get
            {
                if (_partGroupsLocalized.TryGetValue(CultureInfo.CurrentCulture, out string value))
                    return value;

                return Group;
            }
        }

        public PartGroupAttribute(string group)
        {
            Group = group;

            _partGroupsLocalized = new Dictionary<CultureInfo, string>();
            _partGroupsLocalized[new CultureInfo("en-US")] = group;
        }

        public PartGroupAttribute(
            string group,
            params string[] localizations)
        {
            Group = group;

            _partGroupsLocalized = new Dictionary<CultureInfo, string>();

            foreach(string localization in localizations)
            {
                var nameLocal = localization.Split(':');

                CultureInfo culture = new CultureInfo(nameLocal[0]);

                _partGroupsLocalized[culture] = nameLocal[1];
            }

            _partGroupsLocalized[new CultureInfo("en-US")] = group;
        }
    }
}
