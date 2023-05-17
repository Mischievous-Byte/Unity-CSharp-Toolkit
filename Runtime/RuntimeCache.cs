#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MischievousByte.CSharpToolkit
{
    public struct RuntimeCache<T>
    {
        public Func<T> retrievalFunc;

        private T? cache;
        public T Value => Application.isPlaying ? cache == null ? cache = retrievalFunc() : cache : retrievalFunc();
    }
}
