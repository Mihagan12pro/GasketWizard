using System;
using System.Collections.Generic;
using System.Globalization;

namespace GasketWizard.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PartTitleAttribute : LocalizableAttribute
    {
        public PartTitleAttribute(string title)
        {
            Title = title;

            localizedTitles = new Dictionary<System.Globalization.CultureInfo, string> ();
            localizedTitles[new System.Globalization.CultureInfo("en-US")] = title;
        }

        public PartTitleAttribute(string title, params string[] localized)
        {
            Title = title;

            localizedTitles = new Dictionary<System.Globalization.CultureInfo, string>();
            localizedTitles[new System.Globalization.CultureInfo("en-US")] = title;

            foreach (string s in localized)
            {
                string[] strings = s.Split(':');

                CultureInfo cultureInfo = new CultureInfo(strings[0]);
                localizedTitles[cultureInfo] = strings[1];
            }
        }
    }
}
