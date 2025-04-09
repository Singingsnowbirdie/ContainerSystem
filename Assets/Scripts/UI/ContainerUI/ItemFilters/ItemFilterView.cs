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
        private Color _inactiveColor = new Color(0.5f, 0.5f, 0.5f);

        protected override void OnSetModel(ItemFilterUIModel uiModel)
        {
            _filterTypeIconView.SetUIModel(uiModel.FilterType);

            uiModel.IsSelected
                .Subscribe(val => UpdateIconColor(val))
                .AddTo(this);

            uiModel.SelectedFilter
                .Subscribe(val => OnFilterSelected(val))
                .AddTo(this);

            _button.OnClickAsObservable()
                .Subscribe(_ => OnClick())
                .AddTo(this);
        }

        private void OnFilterSelected(EContainerFilter val)
        {
            uiModel.IsSelected.Value = val == uiModel.FilterType.Value;
        }

        private void OnClick()
        {
            SelectFilterData filterData = new SelectFilterData(uiModel.FilterType.Value);
            uiModel.SelectFilter.OnNext(filterData);
        }

        private void UpdateIconColor(bool isActive)
        {
            if (_iconImage != null)
            {
                _iconImage.color = isActive ? _activeColor : _inactiveColor;
            }
        }
    }
}







