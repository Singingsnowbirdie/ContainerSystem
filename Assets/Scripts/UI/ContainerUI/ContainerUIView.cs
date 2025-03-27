using UnityEngine;

namespace UI
{
    public class ContainerUIView : UIView
    {
        [SerializeField] private UIView _hintView_EquipMode;
        [SerializeField] private ItemUIViewsList _itemsList;

        public override void OnSetModel(UIModel uiModel)
        {
            base.OnSetModel(uiModel);

            _hintView_EquipMode.OnSetModel(uiModel);

            if (uiModel is ContainerUIModel containerUIModel)
            {
                _itemsList.SetUIModel(containerUIModel.Items);
            }
        }

        internal void ShowContainerUI(bool value)
        {
            if (value)
            {
                gameObject.SetActive(true);
            }
        }
    }
}







