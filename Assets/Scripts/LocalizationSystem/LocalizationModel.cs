using System;
using System.Collections.Generic;
using System.IO;
using UI;
using UniRx;
using UnityEngine;

namespace Localization
{
    public class LocalizationModel
    {
        private const string TRANSLATIONS_PATH = "Localization/";
        private Dictionary<ELocalizationRegion, Dictionary<string, string>> _translationsCache;

        public ReactiveProperty<ELanguage> CurrentLanguage { get; } = new ReactiveProperty<ELanguage>(ELanguage.English);
        public IReadOnlyDictionary<ELocalizationRegion, Dictionary<string, string>> Translations { get; private set; }
        public LocalizationUIModel UiModel { get; } = new LocalizationUIModel();

        public bool TryGetLocalizationDictionary(ELocalizationRegion region, out Dictionary<string, string> dict)
        {
            if (Translations != null && Translations.TryGetValue(region, out dict))
                return true;

            dict = null;
            return false;
        }

        internal void LoadTranslations(ELanguage language)
        {
            _translationsCache = new Dictionary<ELocalizationRegion, Dictionary<string, string>>();

            foreach (ELocalizationRegion region in Enum.GetValues(typeof(ELocalizationRegion)))
            {
                string regionFileName = $"{region}.json";
                Dictionary<string, string> regionTranslations = LoadRegionTranslations(regionFileName, language);

                if (regionTranslations != null)
                {
                    _translationsCache[region] = regionTranslations;
                }
            }

            Translations = _translationsCache;
        }

        internal bool TryGetTranslation(ELocalizationRegion localizationRegion, string itemConfigKey, out string translation)
        {
            if (Translations.TryGetValue(localizationRegion, out Dictionary<string, string> dict))
            {
                if (dict.TryGetValue(itemConfigKey, out translation))
                    return true;
            }
            translation = null;
            return false;
        }

        // PRIVATE

        private Dictionary<string, string> LoadRegionTranslations(string fileName, ELanguage language)
        {
            string filePath = Path.Combine(TRANSLATIONS_PATH, fileName);

            try
            {
                TextAsset jsonFile = Resources.Load<TextAsset>(filePath);

                if (jsonFile == null)
                {
                    Debug.LogError($"Localization file not found: {filePath}");
                    return null;
                }

                var jsonData = JsonUtility.FromJson<LocalizationFileData>(jsonFile.text);
                var result = new Dictionary<string, string>();

                foreach (var item in jsonData.Items)
                {
                    string localizedText = language switch
                    {
                        ELanguage.English => item.English,
                        ELanguage.Russian => item.Russian,
                        _ => item.English
                    };

                    result[item.Key] = localizedText;
                }

                return result;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load localization file {filePath}: {e.Message}");
                return null;
            }
        }

        [Serializable]
        private class LocalizationFileData
        {
            public List<LocalizationItem> Items;
        }

        [Serializable]
        private class LocalizationItem
        {
            public string Key;
            public string English;
            public string Russian;
        }
    }
}

