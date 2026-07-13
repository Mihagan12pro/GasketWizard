using GasketWizard.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace GasketWizard.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PartParameterAttribute : LocalizableAttribute
    {
        public readonly SizeTypes SizeType;

        public PartParameterAttribute(
            string title, 
            SizeTypes sizeType = SizeTypes.Standart)
        {
            Title = title;

            SizeType = sizeType;

            localizedTitles = new Dictionary<CultureInfo, string>();
            localizedTitles.Add(new CultureInfo("en-US"), title);
        }

        public PartParameterAttribute(
            string title, 
            SizeTypes sizeType = SizeTypes.Standart,
            params string[] localizations)
        {
            Title = title;

            localizedTitles = new Dictionary<CultureInfo, string>();
            localizedTitles.Add(new CultureInfo("en-US"), title);

            foreach(string localization in localizations)
            {
                var nameLocal = localization.Split(':');

                CultureInfo culture = new CultureInfo(nameLocal[0]);

                localizedTitles[culture] = nameLocal[1];
            }

            SizeType = sizeType;
        }
    }
}
