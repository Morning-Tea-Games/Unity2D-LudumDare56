using System.Collections.Generic;
using ServiceLocatorSystem;
using UnityEngine;

namespace Services
{
    public class GroupHierarchyService : IService
    {
        private List<Transform> _groups;

        public GroupHierarchyService(List<Transform> groups)
        {
            _groups = groups;
        }

        public Transform GetGroup(string name)
        {
            foreach (var group in _groups)
            {
                if (group.gameObject.name == name)
                {
                    return group;
                }
            }

            throw new System.Exception($"Group {name} not found");
        }
    }
}
