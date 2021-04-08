using System;
using System.Globalization;

namespace CaseMaker.Entities.Testdata
{
    internal class CMTestDataNumberFormat : ITestDataFormat
    {
        private string locale;
        private string pattern;
        private CultureInfo cultureInfo;
        private NumberFormatInfo formatter;


        public CMTestDataNumberFormat(string p_locale, string p_pattern)
        {
            locale = p_locale;
            pattern = p_pattern;

            createCultureInfo(p_locale);
        }

        private void createCultureInfo(string p_locale)
        {
            cultureInfo = new CultureInfo(p_locale);
            formatter = cultureInfo.NumberFormat;
        }


        public virtual string Locale
        {
            get { return locale; }
            set { locale = value; }
        }

        public virtual string Pattern
        {
            get { return pattern; }
            set { pattern = value; }
        }

        public CultureInfo TestDataCultureInfo
        {
            get
            {
                if (cultureInfo == null)
                    createCultureInfo(locale);
                return cultureInfo;
            }
            set { cultureInfo = value; }
        }

        public NumberFormatInfo Formatter
        {
            get { return formatter; }
        }


        public bool Equals(ITestDataFormat other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(ITestDataFormat other)
        {
            throw new NotImplementedException();
        }
    }
}