using System.Collections.Generic;

public class LanguageProperties
{
	public static List<string> languages = new List<string>
	{
		"en", "fr", "it", "de", "es", "br", "pt", "ru", "jp", "cn",
		"tc", "kr"
	};

	public static Dictionary<string, string> languageNames = new Dictionary<string, string>
	{
		{ "en", "ID_ENGLISH" },
		{ "fr", "ID_FRENCH" },
		{ "it", "ID_ITALIAN" },
		{ "de", "ID_GERMAN" },
		{ "es", "ID_SPANISH" },
		{ "br", "ID_BRAZILIANPORTUGUESE" },
		{ "pt", "ID_PORTUGUESE" },
		{ "ru", "ID_RUSSIAN" },
		{ "jp", "ID_JAPANESE" },
		{ "cn", "ID_SIMPCHINESE" },
		{ "tc", "ID_TRADCHINESE" },
		{ "kr", "ID_KOREAN" }
	};

	private static Dictionary<string, Language> convertLanguage = new Dictionary<string, Language>
	{
		{
			"en",
			Language.English
		},
		{
			"fr",
			Language.French
		},
		{
			"it",
			Language.Italian
		},
		{
			"de",
			Language.German
		},
		{
			"es",
			Language.Spanish
		},
		{
			"br",
			Language.Brazil
		},
		{
			"pt",
			Language.Portugal
		},
		{
			"ru",
			Language.Russian
		},
		{
			"jp",
			Language.Japanesse
		},
		{
			"cn",
			Language.SimplChinese
		},
		{
			"tc",
			Language.TradChinese
		},
		{
			"kr",
			Language.Korean
		}
	};

	public static Language GetLanguage(string shortLanguageName)
	{
		if (convertLanguage.ContainsKey(shortLanguageName))
		{
			return convertLanguage[shortLanguageName];
		}
		return Language.English;
	}

	public static string GetTranslation(string shortLanguageName)
	{
		if (languageNames.ContainsKey(shortLanguageName))
		{
			return Localization.Localize(languageNames[shortLanguageName]);
		}
		return shortLanguageName.ToUpper();
	}
}
