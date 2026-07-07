using System;
using System.Collections.Generic;
using System.Globalization;

namespace GasketWizard.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PartGroupAttribute : LocalizableAttribute
    {
        public PartGroupAttribute(string group)
        {
            Title = group;

            localizedTitles = new Dictionary<CultureInfo, string>();
            localizedTitles[new CultureInfo("en-US")] = group;
        }

        public PartGroupAttribute(
            string group,
            params string[] localizations)
        {
            Title = group;

            localizedTitles = new Dictionary<CultureInfo, string>();

            foreach (string localization in localizations)
            {
                var nameLocal = localization.Split(':');

                CultureInfo culture = new CultureInfo(nameLocal[0]);

                localizedTitles[culture] = nameLocal[1];
            }

            localizedTitles[new CultureInfo("en-US")] = group;
        }
    }
}
