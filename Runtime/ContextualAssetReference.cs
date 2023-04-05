using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace MischievousByte.CSharpToolkit
{
    [System.Serializable]
    public struct ContextualAssetReference<A, C> : ISerializationCallbackReceiver where A : ContextualAsset<C> where C : new()
    {
        [SerializeField] private A asset;
        [SerializeReference] private object context;

        public A Asset => asset;
        public C Context => (C) context;

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
            if (context == null || context.GetType() != typeof(C))
                context = new C();
        }

        public A Prepare()
        {
            asset.Context = (C) context;
            return asset;
        }
    }
}

