using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace SortingAlgorithmComparison
{
    public partial class MainWindow : Window
    {
        private const int ArraySize = 10000;
        private int[] arrayToSort;
        private List<int> listToSort;
        private Stopwatch stopwatch;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            arrayToSort = GenerateRandomArray(ArraySize);
            stopwatch = Stopwatch.StartNew();
            QuickSort(arrayToSort, 0, arrayToSort.Length - 1);
            stopwatch.Stop();
            arrayTimeLabel.Text = $"Tömb rendezése gyorsrendezéssel: {stopwatch.Elapsed.TotalMilliseconds} ms";

            listToSort = GenerateRandomList(ArraySize);
            stopwatch.Restart();
            SelectionSort(listToSort);
            stopwatch.Stop();
            listTimeLabel.Text = $"Lista rendezése kiválasztásos rendezéssel: {stopwatch.Elapsed.TotalMilliseconds} ms";
        }

        private int[] GenerateRandomArray(int size)
        {
            int[] array = new int[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1000);
            }
            return array;
        }

        private List<int> GenerateRandomList(int size)
        {
            List<int> list = new List<int>();
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                list.Add(random.Next(1000));
            }
            return list;
        }

        private void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        private int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, right);
            return i + 1;
        }

        private void SelectionSort(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    int temp = list[i];
                    list[i] = list[minIndex];
                    list[minIndex] = temp;
                }
            }
        }

        private void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
