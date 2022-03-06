using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BlazorApp.Shared
{
    public static class StringExtensions
    {
        public static string LookupNormalize(this string input)
        {
            if (input == null)
            {
                return "";
            }

            var inputWithoutDiacritics = input
                .Replace("ă", "a").Replace("â", "a").Replace("ș", "s").Replace("ț", "t").Replace("î", "i")
                .Replace("Ă", "A").Replace("Â", "A").Replace("Ș", "S").Replace("Ț", "T").Replace("Î", "I");
            var stringBuilder = new StringBuilder(inputWithoutDiacritics.Length);
            var previousCharWasSeparator = false;

            foreach (char c in inputWithoutDiacritics)
            {
                switch (CharUnicodeInfo.GetUnicodeCategory(c))
                {
                    case UnicodeCategory.SpaceSeparator:
                    case UnicodeCategory.ConnectorPunctuation:
                    case UnicodeCategory.DashPunctuation:
                    case UnicodeCategory.OpenPunctuation:
                    case UnicodeCategory.ClosePunctuation:
                    case UnicodeCategory.MathSymbol:
                        if (previousCharWasSeparator)
                        {
                            break;
                        }
                        stringBuilder.Append('_');
                        previousCharWasSeparator = true;
                        break;
                    case UnicodeCategory.LowercaseLetter:
                        previousCharWasSeparator = false;
                        stringBuilder.Append(char.ToUpper(c, CultureInfo.InvariantCulture));
                        break;
                    default:
                        previousCharWasSeparator = false;
                        stringBuilder.Append(c);
                        break;
                }
            }

            return stringBuilder.ToString();
        }
    }
}
