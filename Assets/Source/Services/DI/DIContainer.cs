using System;
using System.Collections.Generic;

namespace Assets.Source.Services.DI
{
    public class DIContainer
    {
        private static DIContainer _diContainer;

        public static DIContainer Instance
        {
            get { return _diContainer ?? (_diContainer = new DIContainer()); }
        }

        private readonly Dictionary<Type, object> _dependencies;

        private DIContainer()
        {
            _dependencies = new Dictionary<Type, object>();
        }

        public T Resolve<T>()
        {
            return _dependencies.TryGetValue(typeof(T), out object value) ? (T)value : default;
        }

        public void Bind<T>(T value)
        {
            _dependencies[typeof(T)] = value;
        }
    }
}