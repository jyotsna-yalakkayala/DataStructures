namespace DataStructures.Part_1.HashTables
{
    public class HashtableWithProbing
    {
        private Entry[] entries;

        public HashtableWithProbing(int capacity)
        {
            entries = new Entry[capacity];
        }

        private class Entry
        {
            public int Key { get; set; }
            public string Value { get; set; }

            public Entry(int Key, string Value)
            {
                this.Key = Key;
                this.Value = Value;
            }
        }

        public void Put(int key, string value)
        {
            var index = getHash(key);
            var startingIndex = index;

            while (entries[index] != null)
            {
                if (entries[index].Key == key)
                {
                    entries[index].Value = value;
                    return;
                }

                index = (index + 1) % entries.Length;

                if (index == startingIndex)
                    throw new Exception("Hashtable is full, no place to insert");

            }

            entries[index] = new Entry(key, value);
        }

        public string Get(int key)
        {
            var index = getHash(key);
            var startingIndex = index;

            while (entries[index] != null)
            {
                if (entries[index].Key == key)
                    return entries[index].Value;

                index = (index + 1) % entries.Length;

                if (index == startingIndex)
                    throw new Exception("Couldn't find the key");

            }

            throw new Exception("Couldn't find the Key");
        }

        private int getHash(int key)
        {
            return Math.Abs(key) % entries.Length;
        }
    }
}
