using DataSystem;
using UniRx;
using VContainer.Unity;
using VContainer;

namespace UI
{
    public class ContainerUIPresenter : IStartable
    {
        [Inject] private readonly ContainerUIModel _containerUIModel;
        [Inject] private readonly ContainerUIView _containerUIView;

        public void Start()
        {
            _containerUIView.OnSetModel(_containerUIModel);

            _containerUIModel.OpenContainerUI
                .Subscribe(OpenContainerUI)
                .AddTo(_containerUIView);
        }

        private void OpenContainerUI(ContainerData data)
        {
            _containerUIView.ShowContainerUI(true);
        }
    }
}
