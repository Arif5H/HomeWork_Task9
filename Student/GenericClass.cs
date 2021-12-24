using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Student
{   [Serializable]
    class GenericClass<T> : IEnumerable<T>
    {
        T[] data = new T[0];

        public T this[int index]
        {
            get
            {
                if (index<0 || index>=data.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return data[index];
            }
        }

        public void Add (T student)
        {
            Array.Resize(ref data, data.Length + 1);
            data[data.Length - 1] = student;
        }


        public void RemoveAt(uint index)
        {
            if (index < 0 || index >= data.Length)
                return;
            
            for(uint i = index; i< data.Length; i++)
            {
                data[index] = data[index + 1];
            }
            Array.Resize(ref data, data.Length-1);
        }

        public int Length
        {
            get
            {
                return data.Length;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
           foreach (var item in data)
           {
                yield return item;     
           }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator ();
        }
    }
}
