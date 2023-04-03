using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace MischievousByte.CSharpToolkit
{
    [System.Serializable]
    public class DynamicContextualAssetReference<T> : ISerializationCallbackReceiver where T : IContextualAsset
    {
        [SerializeField] private ScriptableObject value;
        [SerializeReference] private object context;

        [SerializeField, HideInInspector] private string typeName;

        public T Value => value is T x ? x : default(T);
        public object Context => context;

        public DynamicContextualAssetReference()
        {
            typeName = typeof(T).FullName;
        }

        public void OnAfterDeserialize()
        {
            Validate();
        }

        public void OnBeforeSerialize()
        {
            Validate();
        }

        private void Validate()
        {

            if(value == null)
            {
                context = null;
                return;
            }

            if(!(value is T x))
            {
                Debug.Log("Whoops");
                return;
            }
            

            if (context == null || context.GetType() != x.ContextType)
                context = Activator.CreateInstance(x.ContextType);
        }

        public T Prepare()
        {
            if (!(value is T x))
                return default(T);

            x.SetContext(context);
            return x;
        }
    }
}
