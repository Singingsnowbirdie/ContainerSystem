using Gameplay.UI.ReactiveViews;

namespace UI
{
    public class ItemUIView : UIReactiveView<ItemUIModel>
    {
        public ItemUIModel UIModel { get; private set; }

        protected override void OnSetModel(ItemUIModel uiModel)
        {
            UIModel = uiModel;
        }
    }
}