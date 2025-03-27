using UnityEngine;

namespace UI
{
    public class ContainerUIView : UIView
    {
        [SerializeField] private UIView _hintView_EquipMode;

        public override void OnSetModel(UIModel uiModel)
        {
            base.OnSetModel(uiModel);

            if (_hintView_EquipMode != null)
            {
                _hintView_EquipMode.OnSetModel(uiModel);
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







