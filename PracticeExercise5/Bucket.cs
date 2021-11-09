using System;
namespace PracticeExercise5
{
    public enum BucketState
    {
        EmptySinceStart,
        EmptyAfterRemoval,
        Full
    }

    public class Bucket<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }

        public BucketState State { get; set; }

        public Bucket()
        {
            State = BucketState.EmptySinceStart;
        }

        public Bucket(K key, V value)
        {
            if(key == null || value == null)
            {
                State = BucketState.EmptySinceStart;
            }
            else
            {
                State = BucketState.Full;
            }

            Key = key;
            Value = value;
        }

        public void Clear()
        {
            Key = default;
            Value = default;
            State = BucketState.EmptyAfterRemoval;
        }



    }
}
