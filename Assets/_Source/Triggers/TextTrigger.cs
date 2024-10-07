using GameData;
using Services;
using UnityEngine;

namespace Triggers
{
    public class TextTrigger : MonoBehaviour
    {
        [SerializeField]
        private string[] textOptions;

        private DialogueService _dialogueService;

        private void Start()
        {
            _dialogueService = ServiceController_Game.ServiceLocator.GetService<DialogueService>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                var msg = textOptions[Random.Range(0, textOptions.Length)];
                _dialogueService.Display(msg, 1f, 5f);
            }
        }
    }
}
