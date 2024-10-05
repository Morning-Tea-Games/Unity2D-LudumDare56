using BootstrapSystem;
using Services;
using UnityEngine;

namespace ClickerSystem
{
    public class Clicker : MonoBehaviour
    {
        private ResourcesService _resources;

        private void Start()
        {
            _resources = GameLocator.GameSeiviceLocator.GetService<ResourcesService>();
        }

        public void Click()
        {
            _resources.Add(1);
        }
    }
}
