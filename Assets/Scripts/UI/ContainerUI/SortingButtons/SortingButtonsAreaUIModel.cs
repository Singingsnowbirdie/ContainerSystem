using ItemSystem;
using UniRx;

namespace UI
{
    public class SortingButtonsAreaUIModel : UIModel
    {
        public ReactiveProperty<ESortingType> SortingType { get; }= new ReactiveProperty<ESortingType>(ESortingType.NameDown);

        // Localization
        public ReactiveProperty<string> Sorting_Name { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> Sorting_Type { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> Sorting_Weight { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> Sorting_Cost { get; } = new ReactiveProperty<string>();

        // Icons
        public ReactiveProperty<EContainerAction> SortByNameArrowIcon { get; } = new ReactiveProperty<EContainerAction>(EContainerAction.Up);
        public ReactiveProperty<EContainerAction> SortByTypeArrowIcon { get; } = new ReactiveProperty<EContainerAction>(EContainerAction.Up);
        public ReactiveProperty<EContainerAction> SortByWeightArrowIcon { get; } = new ReactiveProperty<EContainerAction>(EContainerAction.Up);
        public ReactiveProperty<EContainerAction> SortByCostArrowIcon { get; } = new ReactiveProperty<EContainerAction>(EContainerAction.Up);

        public void UpdateArrowIcons()
        {
            SortByNameArrowIcon.Value =
                (SortingType.Value == ESortingType.NameDown) ? EContainerAction.Down : EContainerAction.Up;

            SortByTypeArrowIcon.Value =
                (SortingType.Value == ESortingType.TypeDown) ? EContainerAction.Down : EContainerAction.Up;

            SortByWeightArrowIcon.Value =
                (SortingType.Value == ESortingType.WeightDown) ? EContainerAction.Down : EContainerAction.Up;

            SortByCostArrowIcon.Value =
                (SortingType.Value == ESortingType.CostDown) ? EContainerAction.Down : EContainerAction.Up;
        }
    }
}







