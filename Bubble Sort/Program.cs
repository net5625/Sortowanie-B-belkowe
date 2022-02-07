using System;
using System.Diagnostics;

namespace Bubble_Sort
{
    /// <summary>
    /// Sortowanie Bąbelkowe
    /// </summary>
    class Program
    {
        /// <summary>
        /// Liczebność zbioru sortowanego
        /// </summary>
        public static int N = 20;
        /// <summary>
        /// Funkcja główna.
        /// </summary>
        static void Main()
        {
            #region Zmienne
            int i;
            int[] tablica = new int[N];
            Random random = new Random(); /// Generator liczb pseudolosowych
            #endregion

            /// Uzupełnienie tablicy liczbami pseudolosowymi w zakresie do 50000
            for (i = 0; i < N; i++)
            {
                tablica[i] = random.Next(50000);
            }

            /// Wyświetlenie tablicy nieposortowanej
            Console.WriteLine("Tablica nieposortowana: ");           
            Print(tablica);

            #region Sortowanie
            Console.WriteLine("\nSortowanie...");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int p, pmi, pma;
            pmi = 0;
            pma = N - 1;
            do
            {
                p = -1;
                for(i = pmi; i < pma; i++)
                {
                    if(tablica[i] > tablica[i + 1])
                    {
                        Swap<int>(ref tablica[i], ref tablica[i+1]);
                        if(p < 0)
                        {
                            pmi = i;
                        }
                        p = i;
                    }
                }
                if (pmi != 0) 
                { 
                    pmi--; 
                }
                pma = p;
            } while (p >= 0);
            #endregion
            stopwatch.Stop();
            Console.WriteLine("Sortowanie trwało {0}.", stopwatch.Elapsed);

            /// Wyswietlenie tablic posortowanej
            Console.WriteLine("Tablica posortowana: ");
            Print(tablica);
        }
        /// <summary>
        /// Funkcja wyświetlająca w konsoli zawartość tabeli.
        /// </summary>
        /// <param name="tablica">Tabela N-elementowa.</param>
        static void Print(int[] tablica)
        {
            for (int i = 0; i < N; i++)
            {
                Console.Write(tablica[i] + " ");
            }
        }
        /// <summary>
        /// Metoda ogólna, generyczna  z parametrami typu.
        /// </summary>
        /// <remarks>https://docs.microsoft.com/pl-pl/dotnet/csharp/programming-guide/generics/generic-methods</remarks>
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
}
