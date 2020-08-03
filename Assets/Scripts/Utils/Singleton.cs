using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

namespace Assets.Scripts.Utils
{
    class Singleton<T> where T:new()
    {
        private static T _instance;
        public T Instance {
            get { 
                if(_instance == null)
                {
                    _instance = new T();
                }
                return _instance;
            }
            set { }
            }

    }
}
