using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    internal static class ArrayUtils
    {
        public static void Reverse(int[] arr)
        {
            int l = 0, r = arr.Length - 1;
            while(l <= r)
            {
                int temp = arr[r];
                arr[r] = arr[l];
                arr[l] = temp;

                l++;
                r--;
            }
        }

        public static int FindMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if(arr[i] > max )
                    max = arr[i];
            }

            return max;
        }
        public static int FindMin(int[] arr)
        {
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if(arr[i] < min )
                    min = arr[i];
            }

            return min;
        }

        public static bool isSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                    return false;
            }

            return true;
        }

        public static int CountOccurrences(int[] arr, int _val)
        {
            int cnt = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == _val)
                    cnt++;
            }

            return cnt;
        }

        public static int[] MergeSorted(int[] arr1, int[] arr2)
        {
            int i = 0, j = 0;
            int[] arr = new int[arr1.Length + arr2.Length];
            int idx = 0;
            while(i <  arr1.Length && j < arr2.Length)
            {
                if( arr1[i] < arr2[j])
                {
                    arr[idx] = arr1[i];
                    i++;
                    idx++;
                }
                else if ( arr1[i] > arr2[j])
                {
                    arr[idx] = arr2[j];
                    j++;
                    idx++;
                }
                else
                {
                    arr[idx] = arr1[i];
                    idx++;
                    arr[idx] = arr2[j];
                    i++; j++;
                    idx++;

                }

            }

            while (i < arr1.Length)
            { 
                arr[idx] = arr1[i];
                idx++;
                i++;
            }

            while (j < arr2.Length)
            {
                arr[idx] = arr2[j];
                j++;
                idx++;
            }

            return arr;
        }

    }
}
