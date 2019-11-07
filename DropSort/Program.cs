using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropSort
{
    class Program
    {
        static uint[] DropSortArray(uint[] arrA)
        {
            uint[] sortedArray = new uint[arrA.Length];

            uint max = arrA[0];
            for (int i = 1; i < arrA.Length; i++)
            {
                if (max < arrA[i])
                    max = arrA[i];
            }
            Dictionary<uint, ICollection<uint>>[] keyArray = new Dictionary<uint, ICollection<uint>>[max + 1];
            for (uint i = 0; i < arrA.Length; i++)
            {
                if (keyArray[arrA[i]] == null)
                    keyArray[arrA[i]] = new Dictionary<uint, ICollection<uint>>();
                if (!keyArray[arrA[i]].ContainsKey(1))
                {
                    keyArray[arrA[i]].Add(1, new List<uint>());
                    keyArray[arrA[i]][1].Add(arrA[i]);
                    continue;
                }
                List<uint> items = keyArray[arrA[i]][1] as List<uint>;
                if (items != null)
                {
                    items.Add(arrA[i]);
                }
                
            }
            int counter = 0;
            for (uint i = 0; i < keyArray.Length; i++)
            {
                if (keyArray[i]!= null && keyArray[i].ContainsKey(1))
                {
                    foreach (uint ui in keyArray[i][1])
                    {
                        sortedArray[counter] = i;
                        counter++;
                    }
                }
            }

            return sortedArray;
        }
        static void Main(string[] args)
        {
            uint[] A = { 12, 3, 3, 3, 1, 50, 17, 31, 2, 9, 44, 11, 4, 12, 3, 1, 50, 17, 31, 2, 9, 44, 11, 4 };
            uint[] B = DropSortArray(A);
            for (int i = 0; i < B.Length; i++)
            {
                Console.WriteLine(B[i].ToString());
            }
        }
    }
}
