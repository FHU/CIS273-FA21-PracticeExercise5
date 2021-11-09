using System;
using System.Collections.Generic;

namespace PracticeExercise5
{
    public interface IHashTable<K, V>
    {
        // Add/Update the Key,Value pair.
        // Return true if the key already exists
        bool Add(K key, V value);

        // Remove the Key, Value pair. 
        // Return true if the key already existed
        bool Remove(K key);

        // Returns the value for given key.
        V Get(K key);

        // Returns true if the key is in the hashtable
        bool ContainsKey(K key);

        // Returns true if the key is in the hashtable
        bool ContainsValue(V value);

        // Returns a list of all the keys.
        List<K> GetKeys();
        // Returns a list of all the values.
        List<V> GetValues();

        // Returns the total number of key,value pairs 
        int Count { get; }

        // Returns the percent of the buckets that are filled,
        // a value within the range [0..1]. 
        double LoadFactor { get; }

    }
}
