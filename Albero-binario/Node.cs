using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Albero_binario
{
    class Node<T>
    {
        public T Value;
        public Node<T> Left;
        public Node<T> Right;

        public Node(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
        public int Compare(T obj)
        {
            return Comparer<T>.Default.Compare(Value, obj);
        }
    }
}

