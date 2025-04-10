using ItemSystem;
using UI.ReactiveViews;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ItemFilterView : UIReactiveView<ItemFilterUIModel>
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private FilterTypeIconView _filterTypeIconView;
        [SerializeField] private Button _button;

        private Color _activeColor = Color.white;
        private Color _inactiveColor = new(0.5f, 0.5f, 0.5f);
        private Color _noItemsColor = new(0.2f, 0.2f, 0.2f);

        protected override void OnSetModel(ItemFilterUIModel uiModel)
        {
            _filterTypeIconView.SetUIModel(uiModel.FilterType);

            uiModel.IsSelected
                .Subscribe(val => UpdateIconColor(val, uiModel.HasItemsOfThisType.Value))
                .AddTo(this);

            uiModel.HasItemsOfThisType
                .Subscribe(val => OnHasItemsOfThisType(val))
                .AddTo(this);

            uiModel.SelectedFilter
                .Subscribe(val => OnFilterSelected(val))
                .AddTo(this);

            _button.OnClickAsObservable()
                .Subscribe(_ => OnClick())
                .AddTo(this);
        }

        private void OnHasItemsOfThisType(bool val)
        {
            UpdateIconColor(uiModel.IsSelected.Value, val);
            _button.interactable = val;
        }

        private void OnFilterSelected(EContainerFilter val)
        {
            uiModel.IsSelected.Value = val == uiModel.FilterType.Value;
        }

        private void OnClick()
        {
            uiModel.SelectedFilter.Value = uiModel.FilterType.Value;
        }

        private void UpdateIconColor(bool isActive, bool hasItems)
        {
            if (_iconImage != null)
            {
                if (isActive)
                    _iconImage.color = _activeColor;
                else if (hasItems)
                    _iconImage.color = _inactiveColor;
                else
                    _iconImage.color = _noItemsColor;
            }           
        }
    }
}







