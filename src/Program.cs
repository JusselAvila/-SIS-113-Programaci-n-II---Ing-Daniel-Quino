using System;

namespace AlgoritmosOrdenamiento
{
    class Program
    {
        static void Main()
        {
            Console.Write("Ingrese el tamaño del arreglo: ");
            if (!int.TryParse(Console.ReadLine(), out int n)) return;

            Ordenamiento ord = new Ordenamiento(n);
            ord.Mostrar("Original", ord.Arreglo);

            // Shell Sort
            int[] sArr = ord.ObtenerCopia();
            ord.ShellSort(sArr);
            ord.Mostrar("Shell Sort", sArr);

            // Heap Sort
            int[] hArr = ord.ObtenerCopia();
            ord.HeapSort(hArr);
            ord.Mostrar("Heap Sort", hArr);

            // Quick Sort
            int[] qArr = ord.ObtenerCopia();
            ord.QuickSort(qArr, 0, qArr.Length - 1);
            ord.Mostrar("Quick Sort", qArr);
            
        }
    }
}