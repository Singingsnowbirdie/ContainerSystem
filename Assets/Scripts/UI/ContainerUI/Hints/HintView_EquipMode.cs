using UniRx;

namespace UI
{
    public class HintView_EquipMode : UIView
    {
        public override void OnSetModel(UIModel uiModel)
        {
            base.OnSetModel(uiModel);

            if (uiModel is ContainerUIModel containerUIModel)
            {
                containerUIModel.SelectedItem
                    .Subscribe(val => OnItemSelected(val))
                .AddTo(this);
            }
        }

        private void OnItemSelected(ItemUIView itemView)
        {
            gameObject.SetActive(itemView.UIModel.CanBeEquipped);
        }
    }
}
