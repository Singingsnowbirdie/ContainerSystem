using InteractionSystem;
using Player;
using UnityEngine;

namespace ContainerSystem
{
    public class ContainerView : MonoBehaviour, IContainerView, IInteractable
    {
        [field: SerializeField] public string UniqueID { get; private set; }
        [field: SerializeField] public EContainerType ContainerType { get; private set; }

        private ContainerModel _containerModel;

        // IInteractable

        public void Interact(PlayerInteractionPresenter playerInteractionPresenter)
        {
            ContainerOpenData openData = new ContainerOpenData(UniqueID, ContainerType);
            _containerModel.TryOpen.OnNext(openData);
        }

        public void OnInteractionCompleted()
        {
            Debug.Log("OnInteractionCompleted");
        }

        // IContainerView

        public bool TryGetUniqueID(out string uniqueID)
        {
            uniqueID = UniqueID;
            return !string.IsNullOrEmpty(uniqueID);
        }

        public void SetContainerModel(ContainerModel model) => _containerModel = model;
    }

    internal interface IContainerView
    {
        public bool TryGetUniqueID(out string UniqueID);
        public void SetContainerModel(ContainerModel model);
    }
}