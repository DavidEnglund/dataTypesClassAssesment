using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class HashTable
    {
        // here is my implmentation of a hash table
        // I am gonig to use the average of a number of letters as the size if the hash then
        // cut each key into  section containing that many letters, adding 0's to the last one if needed
        // then get the remainder of the adding of those as my hash.
        // because I am out of time and just need to get this done I am going to use a dbly link list 
        // for duplicate entrys
        // going to start with 2 letters long which is a pretty big size anyway
        private int keySize = 65535;
        private dblLinked[] storage = new dblLinked[65535];
        private List<int> hashedKeys = new List<int>();
        private List<string> keys = new List<string>();

        private int getHash(string key)
        {
            byte[] keyChunk = Encoding.UTF8.GetBytes(key);
            long sumOfKey = 0;
            for(int i = 0;i< keyChunk.Length;i++)
            {
                int twoLetters;
                if (i == keyChunk.Length - 1)
                {
                    twoLetters = Combine(keyChunk[i], 0);
                }
                else
                {
                    twoLetters = Combine(keyChunk[i], keyChunk[i + 1]);
                }
                sumOfKey += twoLetters;
            }

            return Convert.ToInt32(sumOfKey % keySize);
        }

        public void addEntry(string key,object data)
        {
            int hashedKey = getHash(key);
            Debug.WriteLine(hashedKey + " =============== ");
            if (storage[hashedKey] == null)
            {
                storage[hashedKey] = new dblLinked(new object[] { key, data });
            }
            else
            {
                storage[hashedKey].addRight(new object[] { key, data });
            }
            hashedKeys.Add(hashedKey);
            keys.Add(key);
         
        }
        // here we will go to the box the hash function has for the key and then look though the link list
        // until we either find an entry or hit the end of the list
        public object GetEntry(string key)
        {
            // lets get our list
            dblLinked bucket = storage[getHash(key)];
            // first lets see if there is any entry here
            if (!bucket.IsEmpty())
            {
                // get the start of the list
                bucket.goToStart();
                //check the first
                if ((string)((object[])bucket.getData())[0] == key)
                {
                    return ((object[])bucket.getData())[1];
                }
                // then loop and check the rest
                while (bucket.isRight())
                {
                    if ((string)((object[])bucket.getData())[0] == key)
                    {
                        return ((object[])bucket.getData())[1];
                    }
                    bucket.goRight();
                }
            }
                return null;
        }

        // this is to check to see if a key exists
        public bool CheckKey(string key)
        {
            // lets get our list
            dblLinked bucket = storage[getHash(key)];
            // first lets see if there is any entry here
            if (!bucket.IsEmpty())
            {
                // get the start of the list
                bucket.goToStart();
            //check the first
            if ((string)((object[])bucket.getData())[0] == key)
            {
                return true;
            }
            // then loop and check the rest
            while (bucket.isRight())
            {
                if ((string)((object[])bucket.getData())[0] == key)
                {
                    return true;
                }
                bucket.goRight();
            }
        }
                return false;
        }

        public string[] GetKeys()
        {
            return keys.ToArray();
        }

        public int[] GetHashs()
        {
            return hashedKeys.ToArray();
        }

        // this will get me the concat of two of the letters in the array
        public int Combine(byte b1, byte b2)
        {
            int combined = b1 << 8 | b2;
            return combined;
        }
    }
}
