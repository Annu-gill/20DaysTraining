using System;

class IntroSort
{
    static void InsertionSort(int[] arr, int left, int right)
    {
        for (int i = left + 1; i <= right; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= left && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = key;
        }
    }

    static void HeapSort(int[] arr, int left, int right)
    {
        int size = right - left + 1;

        for (int i = size / 2 - 1; i >= 0; i--)
            Heapify(arr, size, i, left);

        for (int i = size - 1; i > 0; i--)
        {
            Swap(arr, left, left + i);
            Heapify(arr, i, 0, left);
        }
    }

    static void Heapify(int[] arr, int size, int root, int offset)
    {
        int largest = root;
        int left = 2 * root + 1;
        int right = 2 * root + 2;

        if (left < size && arr[offset + left] > arr[offset + largest])
            largest = left;

        if (right < size && arr[offset + right] > arr[offset + largest])
            largest = right;

        if (largest != root)
        {
            Swap(arr, offset + root, offset + largest);
            Heapify(arr, size, largest, offset);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, high);
        return i + 1;
    }

    static void IntroSortUtil(int[] arr, int low, int high, int depthLimit)
    {
        int size = high - low + 1;

        if (size <= 16)
        {
            InsertionSort(arr, low, high);
            return;
        }

        if (depthLimit == 0)
        {
            HeapSort(arr, low, high);
            return;
        }

        int pivot = Partition(arr, low, high);

        IntroSortUtil(arr, low, pivot - 1, depthLimit - 1);
        IntroSortUtil(arr, pivot + 1, high, depthLimit - 1);
    }

    static void IntroSortAlgorithm(int[] arr)
    {
        int depthLimit = 2 * (int)Math.Log(arr.Length, 2);
        IntroSortUtil(arr, 0, arr.Length - 1, depthLimit);
    }

    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    static void Main()
    {
        int[] arr = { 29, 4, 71, 15, 92, 8, 46, 33, 60, 1 };

        Console.WriteLine("Introspective Sort");
        Console.WriteLine("Before: " + string.Join(", ", arr));

        IntroSortAlgorithm(arr);

        Console.WriteLine("After : " + string.Join(", ", arr));
    }
}