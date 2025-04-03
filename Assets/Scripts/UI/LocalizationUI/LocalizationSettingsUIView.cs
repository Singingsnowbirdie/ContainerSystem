using Localization;
using UI.ReactiveViews;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI
{
    public class LocalizationSettingsUIView : MonoBehaviour
    {
        [Inject] private readonly LocalizationModel _localizationModel;

        [Header("Flag Buttons")]
        [SerializeField] private Button _englishFlagButton;
        [SerializeField] private Button _russianFlagButton;

        [Header("Flag Icons")]
        [SerializeField] private LanguageFlagIconView _englishFlagIcon;
        [SerializeField] private LanguageFlagIconView _russianFlagIcon;

        internal void SetUIModel(LocalizationSettingsUIModel uiModel)
        {
            Debug.Log($"SetUIModel {uiModel}");

            _englishFlagIcon.SetUIModel(uiModel.LanguageButtonIcon_En);
            _russianFlagIcon.SetUIModel(uiModel.LanguageButtonIcon_Ru);

            _englishFlagButton.OnClickAsObservable()
                .Subscribe(_ => SetLanguage(ELanguage.English))
                .AddTo(this);

            _russianFlagButton.OnClickAsObservable()
                .Subscribe(_ => SetLanguage(ELanguage.Russian))
                .AddTo(this);
        }

        private void SetLanguage(ELanguage lang)
        {
            Debug.Log($"SetLanguage {lang}");

            _localizationModel.CurrentLanguage.Value = lang;

            PlayerPrefs.SetString("AppLanguage", lang == ELanguage.English ? "en" : "ru");
            PlayerPrefs.Save();
        }
    }
}
