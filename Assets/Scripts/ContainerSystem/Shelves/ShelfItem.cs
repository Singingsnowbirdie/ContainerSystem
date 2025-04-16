using UnityEngine;

namespace ContainerSystem
{
    public class ShelfItem : MonoBehaviour
    {
        [field: SerializeField] public EShelfItemType ShelfItemType { get; private set; }

        internal void ShowItem(bool show)
        {
            gameObject.SetActive(show);
        }
    }
}