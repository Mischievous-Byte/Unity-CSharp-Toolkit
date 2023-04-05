using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MischievousByte.CSharpToolkit
{
    [System.Serializable]
    public struct DynamicContextualAssetReference<T> : ISerializationCallbackReceiver
    {
        [SerializeField] private BaseContextualAsset asset;
        [SerializeReference] private object context;
        [SerializeField, HideInInspector] private string typeName;

        public T Asset => asset is T x ? x : default(T);
        public object Context => context;

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
            typeName = typeof(T).FullName;

            if(asset == null)
            {
                context = null;
                return;
            }

            if (context == null || context.GetType() != asset.ContextType)
                context = Activator.CreateInstance(asset.ContextType);
        }

        public T Prepare()
        {
            asset.SetContext(context);
            return (T)Asset;
        }
    }
}
