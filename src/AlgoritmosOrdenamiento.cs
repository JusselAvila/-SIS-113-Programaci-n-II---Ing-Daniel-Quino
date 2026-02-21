using System;

namespace AlgoritmosOrdenamiento
{
    public class Ordenamiento
    {
        public int[] Arreglo { get; private set; }

        // El constructor ahora se encarga de crear y llenar el arreglo
        public Ordenamiento(int tamano)
        {
            Random rnd = new Random();
            Arreglo = new int[tamano];
            for (int i = 0; i < tamano; i++)
                Arreglo[i] = rnd.Next(1, 101);
        }

        public int[] ObtenerCopia() => (int[])Arreglo.Clone();

        // Método solicitado para centralizar la impresión
        public void Mostrar(string mensaje, int[] arr)
        {
            Console.WriteLine($"{mensaje}: [{string.Join("][", arr)}]");
        }

        public void ShellSort(int[] arr)
        {
            int n = arr.Length;
            for (int brecha = n / 2; brecha > 0; brecha /= 2)
            {
                for (int i = brecha; i < n; i++)
                {
                    int temp = arr[i];
                    int j;
                    for (j = i; j >= brecha && arr[j - brecha] > temp; j -= brecha)
                        arr[j] = arr[j - brecha];
                    arr[j] = temp;
                }
            }
        }

        public void HeapSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                Amontonar(arr, n, i);
            for (int i = n - 1; i > 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                Amontonar(arr, i, 0);
            }
        }

        private void Amontonar(int[] arr, int n, int i)
        {
            int raiz = i, izq = 2 * i + 1, der = 2 * i + 2;
            if (izq < n && arr[izq] > arr[raiz]) raiz = izq;
            if (der < n && arr[der] > arr[raiz]) raiz = der;
            if (raiz != i)
            {
                int intercambio = arr[i];
                arr[i] = arr[raiz];
                arr[raiz] = intercambio;
                Amontonar(arr, n, raiz);
            }
        }

        public void QuickSort(int[] arr, int bajo, int alto)
        {
            if (bajo < alto)
            {
                int pi = Particionar(arr, bajo, alto);
                QuickSort(arr, bajo, pi - 1);
                QuickSort(arr, pi + 1, alto);
            }
        }

        private int Particionar(int[] arr, int bajo, int alto)
        {
            int pivote = arr[alto], i = (bajo - 1);
            for (int j = bajo; j < alto; j++)
            {
                if (arr[j] < pivote)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[alto];
            arr[alto] = temp1;
            return i + 1;
        }
    }
}