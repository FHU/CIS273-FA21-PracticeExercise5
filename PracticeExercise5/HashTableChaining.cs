using System;
using System.Collections.Generic;

namespace PracticeExercise5
{
    public class HashTableChaining<K,V>:IHashTable<K,V>
    {
        public HashTableChaining()
        {
        }

        public int Count => throw new NotImplementedException();

        public double LoadFactor => throw new NotImplementedException();

        public bool Add(K key, V value)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(K key)
        {
            throw new NotImplementedException();
        }

        public bool ContainsValue(V value)
        {
            throw new NotImplementedException();
        }

        public V Get(K key)
        {
            throw new NotImplementedException();
        }

        public List<K> GetKeys()
        {
            throw new NotImplementedException();
        }

        public List<V> GetValues()
        {
            throw new NotImplementedException();
        }

        public bool Remove(K key)
        {
            throw new NotImplementedException();
        }
    }
}
