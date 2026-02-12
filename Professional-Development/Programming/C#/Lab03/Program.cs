using System.Numerics;
using System.Runtime.Intrinsics;

namespace Lab03
{
    internal class Program
    {
        // [1]
        static void reverse(int[] arr, int l, int r)
        {
            while(l <= r)
            {
                int temp = arr[l];
                arr[l] = arr[r];
                arr[r] = temp;
                l++;
                r--;
            }
        }
        static void RotateArray(int[] arr, int k)
        {
            //while (k > 0)
            //{
            //    int temp = arr[arr.Length - 1];
            //    for (int i = arr.Length - 1; i > 0; i--)
            //    {
            //        arr[i] = arr[i - 1];
            //    }

            //    arr[0] = temp;
            //    k--;
            //}

            reverse(arr, 0, k); // 3 2 1 4 5
            reverse(arr, 0, arr.Length - 1); // 5 4 1 2 3
            reverse(arr, 0, k - 1); // 4 5 1 2 3

            for(int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
        }
        // [2]
        static void SpiralMatrix(int[,] arr, int n)
        {
            int left = 0, right = n - 1;
            int top = 0, bottom = n - 1;

            int cnt = 1;
            while (right >= left && bottom >= top)
            {
                for (int i = left; i <= right; i++)
                    arr[top, i] = cnt++;

                top++;
                for (int i = top; i <= bottom; i++)
                    arr[i, right] = cnt++;

                right--;
                for (int i = right; i >= left; i--)
                    arr[bottom, i] = cnt++;

                bottom--;
                for (int i = bottom; i >= top; i--)
                    arr[i, left] = cnt++;

                left++;
            }

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (arr[i, j] <= 9)
                        Console.Write($"{arr[i, j]}  ");
                    else
                        Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        // [3]
        static void Pascal(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new int[i + 1];
                arr[i][0] = 1;
                arr[i][i] = 1;
                for(int j = 0; j < arr[i].Length; j++)
                {
                    if (j == 0 || j == arr[i].Length - 1) continue;
                    arr[i][j] = i-1 >= 0 && j < arr[i -1].Length ? arr[i - 1][j] : 0;
                    arr[i][j] += i - 1 >= 0 && j - 1 >=0 ? arr[i - 1][j - 1] : 0;
                        
                }
            }

            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write($"{arr[i][j]} ");
                }
                Console.WriteLine();
            }
        }
        // [4]
        static void Bubble(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                bool swaped = false;
                for(int j = 1; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        swaped = true;
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }

                }
                if (!swaped)
                    break;
            }

            foreach(int i in arr)
                Console.Write($"{i} ");
        }
        static void Selection(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                int mnIdx = i;
                int mn = arr[i];
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < mn)
                    {
                        mn = arr[j];
                        mnIdx = j;
                    }
                }

               
                arr[mnIdx] = arr[i];
                arr[i] = mn;
                
            }

            foreach (int i in arr)
                Console.Write($"{i} ");
        }

        // [5]
        static void VarLimitation() // passing a var
        {
            // var x;
            // x = 5

            // var x = 7, y = 48;

            // var x = null;

            // var can't be a member of a class

            // var can't be used a return type

            // var i = i + 4;

            // var x = 5;
            // x = "kamel";
        }

        // [8]
        static void WordFreq(string str)
        {
            str = str.ToLower();
            var words = str.Split(' ');
            var freqs = new int[words.Length];
            var strs = new string[words.Length];
            var currentSize = 0;

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                int idx = -1;
                for (int j = 0; j < currentSize; j++)
                {
                    if (string.Compare(word, strs[j]) == 0)
                    {
                        idx = j;
                    }
                }
                
                if(idx == -1)
                {
                    strs[currentSize] = word;
                    freqs[currentSize] = 1;
                    currentSize++;
                }
                else
                {
                    freqs[idx]++;
                }
            }

            for (int i = 0; i < freqs.Length - 1; i++)
            {
                bool swaped = false;
                for (int j = 1; j < freqs.Length - i - 1; j++)
                {
                    if (freqs[j] > freqs[j - 1])
                    {
                        // swap ints
                        int temp = freqs[j];
                        freqs[j] = freqs[j - 1];
                        freqs[j - 1] = temp;

                        // swap strs
                        string tempStr = strs[j];
                        strs[j] = strs[j - 1];
                        strs[j - 1] = tempStr;
                    }
                }

                if (!swaped)
                    break;
            }

            for (int i = 0; i < currentSize; i++) {
                Console.WriteLine($"{strs[i]} : {freqs[i]}");
            }
        }

        static void Main(string[] args)
        {
            

        }
    }
}
