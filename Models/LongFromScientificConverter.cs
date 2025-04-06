using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Globalization;

namespace RecommenderApp.Models
{
    public class LongFromScientificConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrEmpty(text))
                return 0L;

            if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
            {
                return Convert.ToInt64(value);
            }

            throw new TypeConverterException(this, memberMapData, text, row.Context, $"Cannot convert '{text}' to long.");
        }
    }
}