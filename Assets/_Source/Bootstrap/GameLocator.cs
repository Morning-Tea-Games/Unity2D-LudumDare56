using ServiceLocatorSystem;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace BootstrapSystem
{
    public class GameLocator : MonoBehaviour
    {
        public static ServiceLocator GameSeiviceLocator;

        [SerializeField]
        private Text _clicksField;

        private void Awake()
        {
            GameSeiviceLocator = new ServiceLocator();

            // Register services
            GameSeiviceLocator.Register(new ClicksViewService(_clicksField));
            GameSeiviceLocator.Register(new ResourcesService());
        }

        private void OnDestroy()
        {
            GameSeiviceLocator = null;
        }
    }
}
