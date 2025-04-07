using ItemSystem;
using UniRx;

namespace UI
{
    public class ContainerSwitchAreaModel : UIModel 
    {
        public ReactiveProperty<EContainerAction> ContainerActionIcon { get; } = new ReactiveProperty<EContainerAction>(EContainerAction.Container_Active);
        public ReactiveProperty<EContainerAction> InventoryActionIcon { get; } = new ReactiveProperty<EContainerAction>(EContainerAction.Container_Inactive);
        public ReactiveProperty<EContainerAction> SwitcherActionIcon { get; } = new ReactiveProperty<EContainerAction>(EContainerAction.TakeItem);
        public ReactiveProperty<string> ContainerName { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> InventoryName { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<bool> IsInventoryActive { get; } = new ReactiveProperty<bool>();
    } 
}
