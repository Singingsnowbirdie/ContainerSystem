using UI;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Localization
{
    public class LocalizationPresenter : IStartable
    {
        [Inject] private readonly LocalizationModel _localizationModel;
        [Inject] private readonly LocalizationUIView _localizationUIView;

        public void Start()
        {
            _localizationModel.CurrentLanguage.Value = GetCurrentLanguage();

            _localizationModel.CurrentLanguage
                .Subscribe(val => OnCurrentLanguageUpdated(val))
                .AddTo(_localizationUIView);

            _localizationUIView.SetUIModel(_localizationModel.UiModel);
        }

        private ELanguage GetCurrentLanguage()
        {
            string langCode = PlayerPrefs.GetString("AppLanguage", "en");
            return langCode == "ru" ? ELanguage.Russian : ELanguage.English;
        }

        private void OnCurrentLanguageUpdated(ELanguage lang)
        {
            _localizationModel.LoadTranslations(lang);

            if (lang == ELanguage.Russian)
            {
                _localizationModel.UiModel.LanguageButtonIcon_Ru.Value = ELanguageFlagIcon.Russian_Active;
                _localizationModel.UiModel.LanguageButtonIcon_En.Value = ELanguageFlagIcon.English_Inactive;
            }
            else
            {
                _localizationModel.UiModel.LanguageButtonIcon_Ru.Value = ELanguageFlagIcon.Russian_Inactive;
                _localizationModel.UiModel.LanguageButtonIcon_En.Value = ELanguageFlagIcon.English_Active;
            }
        }
    }
}

