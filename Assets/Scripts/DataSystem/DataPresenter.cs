using ContainerSystem;
using InventorySystem;
using VContainer;
using VContainer.Unity;
using UnityEngine;

namespace DataSystem
{
    public class DataPresenter : ITickable
    {
        [Inject] private readonly ContainersModel _containersModel;
        [Inject] private readonly InventoryModel _inventoryModel;

        private float _timer;
        private const float SaveInterval = 2f; // Interval in seconds

        public void Tick()
        {
            _timer += Time.deltaTime;

            if (_timer >= SaveInterval)
            {
                _timer = 0f;
                TimeToSave();
            }
        }

        private void TimeToSave()
        {
            _containersModel?.ContainersRepository.OnTimeToSave();
            _inventoryModel?.InventoryRepository.OnTimeToSave();
        }
    }
}