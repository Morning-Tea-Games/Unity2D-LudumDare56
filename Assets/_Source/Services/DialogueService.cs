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

        [SerializeField]
        private float _interval;

        private Coroutine _coroutine;

        private void Awake()
        {
            _textFixeld.alpha = 0f;
        }

        public void Display(string msg, float fadeDuration)
        {
            _textFixeld.text = msg;
            _coroutine = StartCoroutine(AnimateRoutine(fadeDuration));
        }

        private IEnumerator AnimateRoutine(float fadeDuration)
        {
            if (_coroutine != null)
                yield break;

            _textFixeld.DOFade(1f, fadeDuration);
            yield return new WaitForSeconds(_interval);
            _textFixeld.DOFade(0f, fadeDuration);
            _coroutine = null;
        }
    }
}
