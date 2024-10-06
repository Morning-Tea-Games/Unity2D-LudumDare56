using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Trunk : MonoBehaviour
    {
        [field: SerializeField]
        public SpriteRenderer Sr { get; private set; }

        [SerializeField]
        private List<GameObject> _branchesStarts;

        private void OnValidate()
        {
            Sr = GetComponent<SpriteRenderer>();
        }
    }
}
