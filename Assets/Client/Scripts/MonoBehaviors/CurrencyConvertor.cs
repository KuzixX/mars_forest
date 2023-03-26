namespace Client.Scripts.MonoBehaviors
{
    public class CurrencyConvertor
    {
        public static string CurrencyToString(float valueToConvert)
        {
            if (valueToConvert >= 1000000f) // millions
            {
                valueToConvert = (valueToConvert / 1000000f);
                if (valueToConvert >= 100f) return valueToConvert.ToString("0") + "c";
                if (valueToConvert >= 10f) return valueToConvert.ToString("0.0") + "c";
                return valueToConvert.ToString("0.00") + "c";
            }
            if (valueToConvert >= 1000) // thousands
            {
                valueToConvert = (valueToConvert / 1000f);
                if (valueToConvert >= 100f) return valueToConvert.ToString("0") + "b";
                if (valueToConvert >= 10f) return valueToConvert.ToString("0.0") + "b";
                return valueToConvert.ToString("0.00") + "b";
            }
            if (valueToConvert >= 100) // hungered
            {
                valueToConvert = (valueToConvert / 100f);
                if (valueToConvert >= 100f) return valueToConvert.ToString("0") + "a";
                if (valueToConvert >= 10f) return valueToConvert.ToString("0.0") + "a";
                return valueToConvert.ToString("0.00") + "a";
            }
     
            return valueToConvert.ToString();
        }
    }
}