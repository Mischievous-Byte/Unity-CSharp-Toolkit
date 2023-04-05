using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MischievousByte.CSharpToolkit
{
    /// <summary>
    /// Never derive from this class directly!
    /// </summary>
    public abstract class BaseContextualAsset : ScriptableObject
    {
        public abstract Type ContextType { get; }
        public abstract void SetContext(object context);
    }

    public class ContextualAsset<T> : BaseContextualAsset where T : new()
    {
        public override Type ContextType => typeof(T);
        public T Context { get; set; }

        public override void SetContext(object context) => Context = (T)context;
    }
}
