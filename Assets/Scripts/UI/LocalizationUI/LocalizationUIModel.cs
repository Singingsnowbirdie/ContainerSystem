using Localization;
using UniRx;

namespace UI
{
    public class LocalizationUIModel
    {
        public ReactiveProperty<ELanguageFlagIcon> LanguageButtonIcon_En { get; } = new ReactiveProperty<ELanguageFlagIcon>();
        public ReactiveProperty<ELanguageFlagIcon> LanguageButtonIcon_Ru { get; } = new ReactiveProperty<ELanguageFlagIcon>();
    }
}

