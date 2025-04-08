using ItemSystem;
using UniRx;

namespace UI
{
    public class SortingButtonsAreaUIModel : UIModel
    {
        public ReactiveProperty<ESortingType> SortingType { get; }= new ReactiveProperty<ESortingType>(ESortingType.TypeUp);

        // Localization
        public ReactiveProperty<string> Sorting_Name { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> Sorting_Type { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> Sorting_Weight { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> Sorting_Cost { get; } = new ReactiveProperty<string>();

        // Icons
        public ReactiveProperty<EContainerAction> SortByNameArrowIcon { get; } = new ReactiveProperty<EContainerAction>(EContainerAction.ArrowDown);
        public ReactiveProperty<EContainerAction> SortByTypeArrowIcon { get; } = new ReactiveProperty<EContainerAction>(EContainerAction.ArrowDown);
        public ReactiveProperty<EContainerAction> SortByWeightArrowIcon { get; } = new ReactiveProperty<EContainerAction>(EContainerAction.ArrowDown);
        public ReactiveProperty<EContainerAction> SortByCostArrowIcon { get; } = new ReactiveProperty<EContainerAction>(EContainerAction.ArrowDown);

        public void UpdateArrowIcons()
        {
            SortByNameArrowIcon.Value =
                (SortingType.Value == ESortingType.NameDown) ? EContainerAction.ArrowUp : EContainerAction.ArrowDown;

            SortByTypeArrowIcon.Value =
                (SortingType.Value == ESortingType.TypeDown) ? EContainerAction.ArrowUp : EContainerAction.ArrowDown;

            SortByWeightArrowIcon.Value =
                (SortingType.Value == ESortingType.WeightDown) ? EContainerAction.ArrowUp : EContainerAction.ArrowDown;

            SortByCostArrowIcon.Value =
                (SortingType.Value == ESortingType.CostDown) ? EContainerAction.ArrowUp : EContainerAction.ArrowDown;
        }
    }
}







