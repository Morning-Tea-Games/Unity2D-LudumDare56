using System;
using System.Collections.Generic;

namespace ServiceLocatorSystem
{
    public class ServiceLocator
    {
        private readonly Dictionary<Type, IService> _services;

        public ServiceLocator()
        {
            _services = new Dictionary<Type, IService>();
        }

        public void Register<T>(T service)
            where T : IService
        {
            var key = typeof(T);
            if (_services.ContainsKey(key))
            {
                UnityEngine.Debug.LogError($"Service {nameof(key)} already registered");
                return;
            }

            _services.Add(key, service);
        }

        public void Unregister<T>()
            where T : IService
        {
            var key = typeof(T);
            if (!_services.ContainsKey(key))
            {
                UnityEngine.Debug.LogError($"Service {key} not registered");
                return;
            }

            _services.Remove(key);
        }

        public T GetService<T>()
            where T : IService
        {
            var key = typeof(T);
            if (!_services.ContainsKey(key))
            {
                UnityEngine.Debug.LogError($"Service {key} not registered");
                return default;
            }

            return (T)_services[key];
        }
    }
}
