using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MischievousByte.CSharpToolkit
{
    [System.Serializable]
    public struct Optional<T>
    {
        public T value;
        public bool enabled;
    }
}
