using UI.ReactiveViews;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SortingButtonsAreaView : UIView
    {
        [Header("LOCALIZATION")]
        [SerializeField] private TextMeshProReactiveStringView _nameTF;
        [SerializeField] private TextMeshProReactiveStringView _typeTF;
        [SerializeField] private TextMeshProReactiveStringView _weightTF;
        [SerializeField] private TextMeshProReactiveStringView _costTF;

        [Header("Arrows")]
        [SerializeField] private ContainerActionIconView _sortByNameArrow;
        [SerializeField] private ContainerActionIconView _sortByTypeArrow;
        [SerializeField] private ContainerActionIconView _sortByWeightArrow;
        [SerializeField] private ContainerActionIconView _sortByCostArrow;

        [Header("BUTTONS")]
        [SerializeField] private Button _sortByNameBtn;
        [SerializeField] private Button _sortByTypeBtn;
        [SerializeField] private Button _sortByWeightBtn;
        [SerializeField] private Button _sortByCostBtn;

        private SortingButtonsAreaUIModel _uiModel;

        private bool IsSortedByName => IsSortedBy(ESortingType.NameDown, ESortingType.NameUp);
        private bool IsSortedByType => IsSortedBy(ESortingType.TypeDown, ESortingType.TypeUp);
        private bool IsSortedByWeight => IsSortedBy(ESortingType.WeightDown, ESortingType.WeightUp);
        private bool IsSortedByCost => IsSortedBy(ESortingType.CostDown, ESortingType.CostUp);

        private bool IsSortedBy(ESortingType downState, ESortingType upState) =>
            _uiModel.SortingType.Value == downState || _uiModel.SortingType.Value == upState;

        public override void OnSetModel(UIModel uiModel)
        {
            base.OnSetModel(uiModel);

            if (uiModel is SortingButtonsAreaUIModel sortingButtonsUIModel)
            {
                _uiModel = sortingButtonsUIModel;

                _uiModel.SortingType
                    .Subscribe(_ => OnSort())
                    .AddTo(this);

                // Localization
                _nameTF.SetUIModel(_uiModel.Sorting_Name);
                _typeTF.SetUIModel(_uiModel.Sorting_Type);
                _weightTF.SetUIModel(_uiModel.Sorting_Weight);
                _costTF.SetUIModel(_uiModel.Sorting_Cost);

                // Buttons
                _sortByNameBtn.OnClickAsObservable()
                    .Subscribe(_ => SortByName())
                    .AddTo(this);

                _sortByTypeBtn.OnClickAsObservable()
                    .Subscribe(_ => SortByType())
                    .AddTo(this);

                _sortByWeightBtn.OnClickAsObservable()
                    .Subscribe(_ => SortByWeight())
                    .AddTo(this);

                _sortByCostBtn.OnClickAsObservable()
                    .Subscribe(_ => SortByCost())
                    .AddTo(this);

                // Arrows
                _sortByNameArrow.SetUIModel(_uiModel.SortByNameArrowIcon);
                _sortByTypeArrow.SetUIModel(_uiModel.SortByTypeArrowIcon);
                _sortByWeightArrow.SetUIModel(_uiModel.SortByWeightArrowIcon);
                _sortByCostArrow.SetUIModel(_uiModel.SortByCostArrowIcon);
            }
        }

        private void SortByCost() =>
            SetSortingDirection(ESortingType.CostDown, ESortingType.CostUp);

        private void SortByWeight() =>
            SetSortingDirection(ESortingType.WeightDown, ESortingType.WeightUp);

        private void SortByType() =>
            SetSortingDirection(ESortingType.TypeDown, ESortingType.TypeUp);

        private void SortByName() =>
            SetSortingDirection(ESortingType.NameDown, ESortingType.NameUp);

        private void SetSortingDirection(ESortingType defaultDownState, ESortingType oppositeUpState)
        {
            if (_uiModel.SortingType.Value == defaultDownState || _uiModel.SortingType.Value == oppositeUpState)
            {
                _uiModel.SortingType.Value =
                    (_uiModel.SortingType.Value == defaultDownState) ? oppositeUpState : defaultDownState;
            }
            else
            {
                _uiModel.SortingType.Value = defaultDownState;
            }
        }

        private void OnSort()
        {
            _sortByNameArrow.gameObject.SetActive(IsSortedByName);
            _sortByTypeArrow.gameObject.SetActive(IsSortedByType);
            _sortByWeightArrow.gameObject.SetActive(IsSortedByWeight);
            _sortByCostArrow.gameObject.SetActive(IsSortedByCost);

            _uiModel.UpdateArrowIcons();
        }
    }
}