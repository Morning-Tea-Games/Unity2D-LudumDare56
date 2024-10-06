using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Trunk : MonoBehaviour
    {
        [field: SerializeField]
        public SpriteRenderer SpriteRenderer { get; private set; }

        [field: SerializeField]
        public List<GameObject> LeftBranchesStarts { get; private set; }

        [field: SerializeField]
        public List<GameObject> RightBranchesStarts { get; private set; }

        private void OnValidate()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}
