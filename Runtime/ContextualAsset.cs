using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MischievousByte.CSharpToolkit
{
    public interface IContextualAsset
    {
        public Type ContextType { get; }
        public void SetContext(object context);
    }

    /*public abstract class BaseContextualAsset : ScriptableObject
    {
        public abstract Type ContextType { get; }
        
    }*/

    public class ContextualAsset<T> : ScriptableObject, IContextualAsset where T : new()
    {
        public Type ContextType => typeof(T);
        public T Context { get; set; }

        public void SetContext(object context) => Context = (T)context;
    }
}
