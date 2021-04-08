using System.Globalization;

namespace CaseMaker.Localization
{
    public class ResourceSettings
    {
        public enum Language
        {
            English,
            Spanish,
            Deutsch
        }


        public static void setLanguage(Language _lang)
        {
            switch (_lang)
            {
                case Language.English:
                    Resources.Culture = new CultureInfo("en-US");
                    break;

                case Language.Spanish:
                    Resources.Culture = new CultureInfo("es-ES");
                    break;

                case Language.Deutsch:
                    Resources.Culture = new CultureInfo("de-DE");
                    break;
            }
        }
    }
}