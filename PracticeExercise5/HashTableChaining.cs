using System;
using System.Collections.Generic;

namespace PracticeExercise5
{
    public class HashTableChaining<K,V>:IHashTable<K,V>
    {
        private LinkedList< Bucket<K,V>>[] bucketLists;

        private int initialCapacity = 16;
        private const double MAX_LOAD_FACTOR = 0.75;

        public HashTableChaining()
        {
            bucketLists = new LinkedList<Bucket<K, V>>[initialCapacity];

            for(int i=0; i< bucketLists.Length; i++)
            {
                bucketLists[i] = new LinkedList<Bucket<K, V>>();
            }


        }

        private int count = 0;
        public int Count => count;

        public double LoadFactor => throw new NotImplementedException();

        public bool Add(K key, V value)
        {
            if (LoadFactor > MAX_LOAD_FACTOR)
            {
                Resize();
            }

            // find the hash
            int hash = Hash(key);

            // compute the bucket index
            int index = hash % bucketLists.Length;

            foreach( var bucket in bucketLists[index])
            {
                // If the key already exists
                // update the value
                if (bucket.Key.Equals(key))
                {
                    bucket.Value = value;
                    return true;
                }
            }

            // else
            // add the new key/value pair
            Bucket<K, V> newBucket = new Bucket<K, V>(key, value);
            bucketLists[index].AddLast(newBucket);
            count++;


            return false;
        }

        public bool ContainsKey(K key)
        {
            int hash = Hash(key);

            // find index
            int index = hash % bucketLists.Length;

            var list = bucketLists[index];

            // check linked list
            foreach (var bucket in list)
            {
                if (bucket.Key.Equals(key))
                {
                    return true;
                }
            }

            return false;

        }

        public bool ContainsValue(V value)
        {
            foreach( var list in bucketLists)
            {
                foreach(var bucket in list)
                {
                    if (bucket.Value.Equals(value))
                    {
                        return true;
                    }
                }
            }

            return false;
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

            count--;
            throw new NotImplementedException();
        }


        private int Hash(K key)
        {
            int hash = key.GetHashCode();

            return hash > 0 ? hash : -hash;
        }

        private void Resize()
        {

        }
    }
}
