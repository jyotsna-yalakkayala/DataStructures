namespace DataStructures.Part_1.HashTables
{
    public class HastableExercise
    {
        public int mostFrequent(int[] input) { 
            var dictionary = new Dictionary<int, int>();

            foreach (var item in input) { 
                if (dictionary.ContainsKey(item)) 
                    dictionary[item]++;
                else 
                    dictionary[item] = 1;
            }

            var mostFrequent = dictionary.Keys.FirstOrDefault();
            int maxCount = 0; 

            foreach (var item in dictionary) {
                if (item.Value > maxCount) {
                    maxCount = item.Value;
                    mostFrequent = item.Key;
                }
            }

            return mostFrequent;
        }

        public int CountPairsWithDiff(int[] input, int k) {
            var hashset = new HashSet<(int, int)>();
            var count = 0;

            for (int i = 0; i < input.Length; i++) {
                for (int j = 0; j < input.Length; j++) {
                    if (i != j && input[j] - input[i] == k) {
                        var pair = (Math.Max(input[i], input[j]), Math.Min(input[i], input[j]));
                        if (!hashset.Contains(pair)) { 
                            hashset.Add(pair);
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        public (int, int) TwoSums(int[] input, int sum) {
            var dictionary = new Dictionary<int, int>();

            for (int i = 0; i < input.Length; i++) { 
                var complement = sum - input[i];

                if (dictionary.ContainsKey(complement)) { 
                    return (dictionary[complement], i);
                }

                if (!dictionary.ContainsKey(input[i]))
                    dictionary[input[i]] = i;
            }

            throw new Exception("No two numbers add upto to the given target");
        } 
    }
}
