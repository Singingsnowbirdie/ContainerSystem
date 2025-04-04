using DataSystem;
using UnityEngine;

namespace Tools
{
    public class RepositoriesTool : MonoBehaviour
    {
        private ContainersRepository _containersRepository;
        private InventoryRepository _inventoryRepository;

        public ContainersRepository ContainersRepository
        {
            get
            {
                _containersRepository ??= new ContainersRepository();
                return _containersRepository;
            }
        }

        public InventoryRepository InventoryRepository
        {
            get
            {
                _inventoryRepository ??= new InventoryRepository();
                return _inventoryRepository;
            }
        }

        public void ResetAllData()
        {
            ContainersRepository.ResetData();
            InventoryRepository.ResetData();
        }

        public void ResetContainersRepository()
        {
            ContainersRepository.ResetData();
        }

        public void ResetInventoryRepository()
        {
            InventoryRepository.ResetData();
        }
    }
}

