using System;

using R5T.T0132;
using R5T.T0221;


namespace R5T.L0056
{
    [FunctionalityMarker]
    public partial interface IDateTimeOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public L0053.IDateTimeOperator _Platform => L0053.DateTimeOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public WasFound<DateTime> Is_YYYYMMDD(string possible_YYYYMMDD)
        {
            var isYYYYMMDD_HHMMSS = _Platform.TryParseExact(
                possible_YYYYMMDD,
                Instances.DateTimeFormats.YYYYMMDD,
                out var dateTime);

            var output = WasFound.From(isYYYYMMDD_HHMMSS, dateTime);
            return output;
        }

        public WasFound<DateTime> Is_YYYYMMDD_HHMMSS(string possible_YYYYMMDD_HHMMSS)
        {
            var isYYYYMMDD_HHMMSS = _Platform.TryParseExact(
                possible_YYYYMMDD_HHMMSS,
                Instances.DateTimeFormats.YYYYMMDD_HHMMSS,
                out var dateTime);

            var output = WasFound.From(isYYYYMMDD_HHMMSS, dateTime);
            return output;
        }
    }
}
