using System;

namespace Lab3Solution
{
    class Program
    {
        void LinearSearch(int[] arr, int key)
        {
            int N = arr.Length;
            for (int i = 0; i < N; i++)
                if (arr[i] == key)
                    Console.WriteLine(i+1);
            Console.WriteLine("-1");
        }

        void BubbleSort(int[] arr, int key)
        {
            int temp;

            for (int j = 0; j <= arr.Length - 2; j++)
            {
                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }

            Console.WriteLine("Sorted:");
            foreach (int p in arr)
                Console.Write(p + " ");
            Console.Read();
        }

        void BinarySearch(int[] arr, int key)
        {
            int minNum = 0, max, min;
            int maxNum = arr.Length - 1;

            while (minNum <= maxNum)
            {
                int mid = (minNum + maxNum) / 2;
                if (key == arr[mid])
                {
                    Console.WriteLine(++mid);
                }
                else if (key < arr[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            Console.Write("None");
        }
        public static void Main()
        {
            int[] arr = { 155, 34, 67, 89, 23, 25 };
            int key = int.Parse(Console.ReadLine());
            Program program = new Program(); // new line
            program.LinearSearch(arr,key);
            program.BubbleSort(arr,key);
            program.BinarySearch(arr,key);

        }
    }
}
