using DataSystem;
using ItemSystem;
using UniRx;

namespace UI
{
    public class ContainerUIModel : UIModel
    {
        public string ContainerID { get; set; }

        // OPENING
        public ISubject<ContainerData> OpenContainerUI { get; } = new Subject<ContainerData>();
        public ReactiveProperty<bool> IsContainerUIOpen { get; } = new ReactiveProperty<bool>(false);

        // INTERACTION
        public ReactiveProperty<string> InteractedItemID { get; } = new ReactiveProperty<string>(null);

        // SELECTION
        public ReactiveProperty<string> SelectedItemID { get; } = new ReactiveProperty<string>(null);

        // FILTERING
        public ReactiveProperty<EContainerFilter> SelectedFilter { get; } = new ReactiveProperty<EContainerFilter>();

        // COLLECTIONS
        public ReactiveCollection<ItemUIModel> Items { get; } = new ReactiveCollection<ItemUIModel>();
        public ReactiveCollection<ItemFilterUIModel> ItemFilters { get; } = new ReactiveCollection<ItemFilterUIModel>();

        // MODELS
        public ContainerSwitchAreaModel ContainerSwitchAreaModel { get; } = new ContainerSwitchAreaModel();
        public SortingButtonsAreaUIModel SortingButtonsAreaModel { get; } = new SortingButtonsAreaUIModel();

        // LOCALIZATION 
        public ReactiveProperty<string> HintText_Take { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> HintText_TakeAll { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> HintText_EquipMode { get; } = new ReactiveProperty<string>();

        public void SetContainerOpenState(bool isOpen, ContainerData data = null)
        {
            IsContainerUIOpen.Value = isOpen;
            if (isOpen && data != null)
            {
                OpenContainerUI.OnNext(data);
            }
        }
    }
}

