using ItemSystem;
using UniRx;

namespace UI
{
    public class ContainerSwitchAreaModel : UIModel 
    {
        public ReactiveProperty<EContainerAction> SwitcherActionIcon { get; } = new ReactiveProperty<EContainerAction>(EContainerAction.ContainerContantShown);
        public ReactiveProperty<string> ContainerName { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> InventoryName { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<bool> IsInventoryShown { get; } = new ReactiveProperty<bool>();
        public ReactiveProperty<bool> IsHovered { get; } = new ReactiveProperty<bool>();
    } 
}
