using GasketWizard.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace GasketWizard.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SizeAttribute : Attribute
    {
        public readonly string Title;

        public readonly SizeTypes SizeType;

        private readonly Dictionary<CultureInfo, string> _titleLocalized;

        public SizeAttribute(
            string title, 
            SizeTypes sizeType = SizeTypes.Standart)
        {
            Title = title;

            SizeType = sizeType;

            _titleLocalized = new Dictionary<CultureInfo, string>();
            _titleLocalized.Add(new CultureInfo("en-US"), title);
        }

        public SizeAttribute(
            string title, 
            SizeTypes sizeType = SizeTypes.Standart,
            params string[] localizations)
        {
            Title = title;

            _titleLocalized = new Dictionary<CultureInfo, string>();
            _titleLocalized.Add(new CultureInfo("en-US"), title);

            foreach(string localization in localizations)
            {
                var nameLocal = localization.Split(':');

                CultureInfo culture = new CultureInfo(nameLocal[0]);

                _titleLocalized[culture] = nameLocal[1];
            }

            SizeType = sizeType;
        }
    }
}
