using BootstrapSystem;
using ServiceLocatorSystem;

namespace Services
{
    public class ResourcesService : IService
    {
        public int Count { get; private set; }
        private ClicksViewService _view;

        public ResourcesService()
        {
            _view = GameLocator.GameSeiviceLocator.GetService<ClicksViewService>();
        }

        public void Add(int count)
        {
            Count += count;
            _view.Display(Count.ToString());
        }
    }
}
