using System;
using System.Collections.Generic;
using System.Globalization;

namespace GasketWizard.Attributes
{
    public abstract class LocalizableAttribute : Attribute
    {
        protected Dictionary<CultureInfo, string> localizedTitles;

        /// <summary>
        /// For current ui culture
        /// </summary>
        public string LocalizedTitle 
        {
            get
            {
                if (localizedTitles.TryGetValue(CultureInfo.CurrentUICulture, out string value))
                    return value;

                return Title;
            }
        }

        /// <summary>
        /// en-US
        /// </summary>
        public string Title { get; protected set; }
    }
}