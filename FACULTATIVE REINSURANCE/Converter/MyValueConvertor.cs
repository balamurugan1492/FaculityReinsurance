using FACULTATIVE_REINSURANCE.Util;
using System;
using System.Windows.Data;

namespace FACULTATIVE_REINSURANCE.Converter
{
    internal class MyValueConvertor : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] as string == "Coverage")
            {
                CoverageDeatils section = new CoverageDeatils();
                section.DisplayName = values[1].ToString();
                if (!string.IsNullOrWhiteSpace(values[2] as string))
                {
                    section.InputValue = System.Convert.ToInt32(values[2]);
                }
                else
                    section.InputValue = 0;
                return section;
            }
            else if (values[0] as string == "Extension")
            {
                ExtenstionDetails section = new ExtenstionDetails();
                section.DisplayName = values[1].ToString();
                section.InputValue = values[2].ToString();
                return section;
            }
            else
                return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}