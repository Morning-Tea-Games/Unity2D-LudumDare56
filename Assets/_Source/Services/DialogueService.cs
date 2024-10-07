using System.Collections;
using DG.Tweening;
using ServiceLocatorSystem;
using TMPro;
using UnityEngine;

namespace Services
{
    public class DialogueService : MonoBehaviour, IService
    {
        [SerializeField]
        private TMP_Text _textFixeld;

        private Coroutine _coroutine;

        private void Awake()
        {
            _textFixeld.alpha = 0f;
        }

        public void Display(string msg, float fadeDuration, float pauseDelay)
        {
            _textFixeld.text = msg;
            _coroutine = StartCoroutine(AnimateRoutine(fadeDuration, pauseDelay));
        }

        private IEnumerator AnimateRoutine(float fadeDuration, float pauseDelay)
        {
            if (_coroutine != null)
                yield break;

            _textFixeld.DOFade(1f, fadeDuration);
            yield return new WaitForSeconds(fadeDuration);
            yield return new WaitForSeconds(pauseDelay);
            _textFixeld.DOFade(0f, fadeDuration);
            yield return new WaitForSeconds(fadeDuration);
            _coroutine = null;
        }
    }
}
