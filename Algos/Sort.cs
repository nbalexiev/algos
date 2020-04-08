using System;

namespace Algos
{
    public class Sort<T> where T : IComparable<T>
    {
        #region Mergesort
        public static void MergeSort(T[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1, new T[arr.Length]);
        }

        private static void MergeSort(T[] arr, int l, int r, T[] buff)
        {
            if (l < r)
            {
                int m = (l + r) / 2;
                // Sort Left
                MergeSort(arr, l, m, buff);
                // Sort Right 
                MergeSort(arr, m + 1, r, buff);
                // Merge
                Merge(arr, l, m, r, buff);
            }
        }

        private static void Merge(T[] arr, int l, int m, int r, T[] buff)
        {
            for (int i = l; i <= r; i++)
            {
                buff[i] = arr[i];
            }

            int helperLeft = l;
            int helperRight = m + 1;
            int current = l;

            while (helperLeft <= m && helperRight <= r)
            {
                if (buff[helperLeft].CompareTo(buff[helperRight]) <= 0)
                {
                    arr[current] = buff[helperLeft];
                    helperLeft++;
                }
                else
                {
                    arr[current] = buff[helperRight];
                    helperRight++;
                }
                current++;
            }

            int remaining = m - helperLeft;
            for (int i = 0; i <= remaining; i++)
            {
                arr[current + i] = buff[helperLeft + i];
            }
        }
        #endregion

        #region QuickSort
        public static void QuickSort(T[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        private static void QuickSort(T[] arr, int l, int r)
        {
            int index = Partition(arr, l, r);

            if(l < index - 1)
            {
                QuickSort(arr, l, index - 1);
            }

            if(index < r)
            {
                QuickSort(arr, index, r);
            }
        }

        private static int Partition(T[] arr, int l, int r)
        {
            T pivot = arr[(l + r) / 2];

            while(l <= r)
            {
                while (arr[l].CompareTo(pivot) < 0) l++;
                while (arr[r].CompareTo(pivot) > 0) r--;

                if(l <= r)
                {
                    Swap(arr, l, r);
                    l++;
                    r--;
                }
            }

            return l;
        }

        #endregion

        private static void Swap(T[] arr, int l, int r)
        {
            var t = arr[l];
            arr[l] = arr[r];
            arr[r] = t;
        }
    }
}
