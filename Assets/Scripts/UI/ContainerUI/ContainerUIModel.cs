using DataSystem;
using UniRx;

namespace UI
{
    public class ContainerUIModel : UIModel
    {
        public ContainerSwitchAreaModel ContainerSwitchAreaModel { get; } = new ContainerSwitchAreaModel();
        public ISubject<ContainerData> OpenContainerUI { get; } = new Subject<ContainerData>();
        public ReactiveCollection<ItemUIModel> Items { get; } = new ReactiveCollection<ItemUIModel>();
        public ReactiveProperty<bool> IsContainerUIOpen { get; } = new ReactiveProperty<bool>(false);
        public ReactiveProperty<string> SelectedItemID { get; } = new ReactiveProperty<string>(null);

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

