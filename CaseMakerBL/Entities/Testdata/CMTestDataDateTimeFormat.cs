using System;
using System.Globalization;

namespace CaseMaker.Entities.Testdata
{
    internal class CMTestDataDateTimeFormat : ITestDataFormat
    {
        private string locale;
        private string pattern;
        private CultureInfo testDataCultureInfo;

        public CMTestDataDateTimeFormat(string p_locale, string p_pattern)
        {
            locale = p_locale;
            pattern = p_pattern;

            createCultureInfo(locale);
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
                if (testDataCultureInfo == null)
                    createCultureInfo(pattern);
                return testDataCultureInfo;
            }
            set { testDataCultureInfo = value; }
        }

        private void createCultureInfo(string p_locale)
        {
            testDataCultureInfo = new CultureInfo(p_locale);
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