using System.Globalization;

namespace RPGCharacterSheet
{
    public class BlankAs0Converter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
            
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = value as string;
            if (string.IsNullOrEmpty(val))
            {
                return 0;
            }
            else
            {
                int.TryParse(val, out int result);
                return result;
            }
        }
    }
}
