using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Part_1.HashTables
{
    public class LinkedListHashTable
    {
        private class Entry {
            public int Key { get; set; }
            public string Value { get; set; }

            public Entry(int Key, string Value)
            {
                this.Key = Key;
                this.Value = Value;
            }
        }

        private LinkedList<Entry>[] entries;

        public LinkedListHashTable(int capacity)
        {
            entries = new LinkedList<Entry>[capacity];       
        }

        public void Put(int Key, string value) { 
            var index = hash(Key);

            if (entries[index] == null)
                entries[index] = new LinkedList<Entry>();
            
            var bucket = entries[index];

            foreach (var entry in bucket) {
                if (entry.Key == Key) {
                    entry.Value = value;
                    return;
                }
            }

            bucket.AddLast(new Entry(Key, value));
        }

        public string Get(int Key) {
            var bucket = getBucket(Key);

            if (bucket != null) {
                foreach (var entry in bucket)
                {
                    if (entry.Key == Key)
                        return entry.Value;
                }
            }
            return null;
        }

        public void Remove(int Key) { 
            var bucket = getBucket(Key);

            if (bucket == null)
                throw new InvalidOperationException();

            if (bucket != null) {
                foreach (var entry in bucket) {
                    if (entry.Key == Key) {
                        bucket.Remove(entry);
                        return;
                    }
                }
            }

            throw new InvalidOperationException();
        }

        private int hash(int key) { 
            return key % entries.Length;
        }

        private LinkedList<Entry> getBucket(int key) {
            return entries[hash(key)];
        }
    }
}
