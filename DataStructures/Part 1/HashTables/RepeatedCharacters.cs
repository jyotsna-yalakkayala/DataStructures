using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Part_1.HashTables
{
    public class RepeatedCharacters
    {
        public char firstNonRepeatedCharacter(string input) { 
            var dictionary = new Dictionary<char, int>();

            foreach (char c in input) { 
                if (dictionary.ContainsKey(c)) 
                    dictionary[c]++;
                else dictionary[c] = 1;
            }

            foreach (char c in input) { 
                if (dictionary[c] == 1)
                    return c;
            }

            throw new Exception("No characters repeated");
        }


        public char getFirstRepeatedCharacter(string input) {
            var hashset = new HashSet<char>();

            foreach (char c in input) {
                if (hashset.Contains(c))
                    return c;
                hashset.Add(c);
            }

            throw new Exception("None of the characters were repeated");
        }
    }
}
