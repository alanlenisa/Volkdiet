using System;
using System.Collections.Generic;

namespace VolkDiet.Core.Infrastructure
{
    


    public class Singleton<T> 
    {
        private static T instance;
        private static IDictionary<Type, object> Singletons { get; }
        static Singleton()
        {
            Singletons = new Dictionary<Type, object>();
        }
        public static T Instance
        {
            get => instance;
            set
            {
                instance = value;
                Singletons[typeof(T)] = value;
            }
        }
    }

    
}
