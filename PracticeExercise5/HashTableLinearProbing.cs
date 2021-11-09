using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeExercise5
{
    public class HashTableLinearProbing<K,V>: IHashTable<K,V>
    {

        private Bucket<K,V>[] buckets;
        private int initialCapacity = 16;
        private const double MAX_LOAD_FACTOR = 0.75;

        public HashTableLinearProbing()
        {
            buckets = new Bucket<K, V>[initialCapacity];

            for(int i=0; i < initialCapacity; i++)
            {
                buckets[i] = new Bucket<K, V>();
            }
        }

        private int count = 0;
        public int Count => count;

        public double LoadFactor => (double)count / buckets.Length;

        public bool Add(K key, V value)
        {
            if( LoadFactor > MAX_LOAD_FACTOR)
            {
                Resize();
            }

            var bucket = new Bucket<K, V>(key, value);
            int hash = Hash(key);

            int bucketIndex = hash % buckets.Length;
            int initialIndex = bucketIndex;

            while ( buckets[bucketIndex].State == BucketState.Full)
            {
                // Update existing key/value pair
                if(buckets[bucketIndex].Key.Equals(key))
                {
                    buckets[bucketIndex].Value = value;
                    return true;
                }

                bucketIndex = (bucketIndex + 1) % buckets.Length;

                if( bucketIndex == initialIndex)
                {
                    throw new OutOfMemoryException();                    
                }
            }

            // Add new key/value pair
            buckets[bucketIndex] = bucket;
            count++;

            return false;
        }

        public bool ContainsKey(K key)
        {
            int hash = Hash(key);

            int bucketIndex = hash % buckets.Length;
            int initialIndex = bucketIndex;

            while (buckets[bucketIndex].State != BucketState.EmptySinceStart)
            {
                if(buckets[bucketIndex].State == BucketState.Full && buckets[bucketIndex].Key.Equals(key))
                {
                    return true;
                }

                bucketIndex = (bucketIndex + 1) % buckets.Length;

                // checked every bucket
                if(bucketIndex == initialIndex)
                {
                    return false;
                }

            }
            
            return false;

        }

        public bool ContainsValue(V value)
        {
            foreach( var bucket in buckets)
            {
                if( bucket.Value.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        public V Get(K key)
        {
            if(!ContainsKey(key))
            {
                throw new KeyNotFoundException();
            }

            // hash the key


            // start looking at that index


            // while the key doens't match, go to the next bucket in array


            // when we find the bucket with matching key, return the value

            return default;

        }

        public List<K> GetKeys()
        {
            List<K> keys = new List<K>();

            foreach(var bucket in buckets)
            {
                if( bucket.State == BucketState.Full)
                {
                    keys.Add(bucket.Key);
                }
            }

            return keys;
        }

        public List<V> GetValues()
        {
            throw new NotImplementedException();
        }

        // TODO
        public bool Remove(K key)
        {
            
            count--;

            return true;
        }


        private int Hash(K key)
        {
            int hash = key.GetHashCode();

            return hash > 0 ? hash : -hash;
        }

        private void Resize()
        {
            var newBuckets = new Bucket<K, V>[2 * buckets.Length];
            var oldBuckets = buckets;

            buckets = newBuckets;
            for (int i = 0; i < newBuckets.Length; i++)
            {
                buckets[i] = new Bucket<K, V>();
            }

            count = 0;

            // rehash all the buckets into the new array
            foreach (var bucket in oldBuckets)
            {
                if (bucket.State == BucketState.Full)
                {
                    Add(bucket.Key, bucket.Value);
                }
            }
        }


    }
}
