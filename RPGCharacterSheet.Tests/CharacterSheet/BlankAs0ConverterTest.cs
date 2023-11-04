using System.Globalization;
using RPGCharacterSheet.Services;

namespace RPGCharacterSheet.Tests.CharacterSheet
{
    public class BlankAs0ConverterTest
    {
        [Fact]
        public void Converter_Converts_Int_To_String()
        {
            BlankAs0Converter converter = new BlankAs0Converter();
            object result = converter.Convert(0, null, null, CultureInfo.InvariantCulture);
            Assert.Equal(typeof(string), result.GetType());
            Assert.Equal("0", result);

        }
    }
}
