using System;
using System.Globalization;

namespace CaseMaker.Entities.Testdata
{
    public interface ITestDataFormat : IEquatable<ITestDataFormat>, IComparable<ITestDataFormat>
    {
        string Locale { get; set; }
        string Pattern { get; set; }

        CultureInfo TestDataCultureInfo { get; set; }
    }
}