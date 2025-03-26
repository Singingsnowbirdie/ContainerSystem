using UnityEngine;
using VContainer.Unity;
using VContainer;

namespace ContainerSystem
{
    public class ContainerView : MonoBehaviour, IContainerView
    {
        //[SerializeField] private GameObject interactionUI;
        //[SerializeField] private Transform itemsParent;

        //public UnityEvent OnInteracted = new UnityEvent();

        //public void ShowUI(bool show) => interactionUI.SetActive(show);

        //public void UpdateItemsUI(List<ItemData> items)
        //{
        //    // Очищаем и пересоздаем UI элементы
        //    foreach (Transform child in itemsParent)
        //        Destroy(child.gameObject);

        //    foreach (var item in items)
        //    {
        //        var itemUI = Instantiate(itemUIPrefab, itemsParent);
        //        itemUI.Initialize(item);
        //    }
        //}

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.CompareTag("Player"))
        //        OnInteracted.Invoke();
        //}
    }

    internal interface IContainerView
    {
    }
}