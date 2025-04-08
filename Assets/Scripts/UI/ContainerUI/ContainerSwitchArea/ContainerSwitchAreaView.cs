using TMPro;
using UI.ReactiveViews;
using UniRx;
using UnityEngine;

namespace UI
{
    public class ContainerSwitchAreaView : UIView
    {
        [Header("ICONS")]
        [SerializeField] private ContainerActionIconView _containerActionIcon;
        [SerializeField] private ContainerActionIconView _inventoryActionIcon;
        [SerializeField] private ContainerActionIconView _switcherActionIcon;

        [Header("REACTIVE TEXT")]
        [SerializeField] private TextMeshProReactiveStringView _containerNameTF;
        [SerializeField] private TextMeshProReactiveStringView _inventoryNameTF;

        [Header("TMP")]
        [SerializeField] private TMP_Text _containerNameTMP;
        [SerializeField] private TMP_Text _inventoryNameTMP;

        private readonly Color _activeColor = Color.white;
        private readonly Color _inactiveColor = new Color(0.5f, 0.5f, 0.5f);

        private ContainerSwitchAreaModel _switchAreaModel;

        public override void OnSetModel(UIModel uiModel)
        {
            base.OnSetModel(uiModel);

            if (uiModel is ContainerSwitchAreaModel switchAreaModel)
            {
                _switchAreaModel = switchAreaModel;

                _containerActionIcon.SetUIModel(_switchAreaModel.ContainerActionIcon);
                _inventoryActionIcon.SetUIModel(_switchAreaModel.InventoryActionIcon);
                _switcherActionIcon.SetUIModel(_switchAreaModel.SwitcherActionIcon);

                _containerNameTF.SetUIModel(_switchAreaModel.ContainerName);
                _inventoryNameTF.SetUIModel(_switchAreaModel.InventoryName);

                _switchAreaModel.IsInventoryActive
                    .Subscribe(val => OnInventoryActive(val))
                    .AddTo(this);
            }
        }

        private void OnInventoryActive(bool val)
        {
            if (val)
            {
                _containerNameTMP.color = _inactiveColor;
                _inventoryNameTMP.color = _activeColor;

                _switchAreaModel.SwitcherActionIcon.Value = ItemSystem.EContainerAction.TakeItem;
            }
            else
            {
                _containerNameTMP.color = _activeColor;
                _inventoryNameTMP.color = _inactiveColor;

                _switchAreaModel.SwitcherActionIcon.Value = ItemSystem.EContainerAction.PutItem;
            }
        }
    }
}







