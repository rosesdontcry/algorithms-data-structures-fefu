namespace DifferentSortings
{
    public abstract class Sortings
    {
        internal static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int barrier = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > barrier)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = barrier;
            }
        }
        
        internal static void InsertionSort(int[] array, ref int counterSwap, ref int counterСomparison)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int barrier = array[i];
                int j = i - 1;

                counterСomparison++;
                while (j >= 0 && array[j] > barrier)
                {
                    counterСomparison++;
                    array[j + 1] = array[j];
                    counterSwap++;
                    j--;
                }
                
                array[j + 1] = barrier;
                counterSwap++;
            }
        }
        
        internal static void BubbleSort(int[] array)
        {
            bool t = true;
            int j = array.Length - 1;
            while (t)
            {
                t = false;
                for(int i = 0; i < j; i++)
                    if (array[i] > array[i + 1])
                    {
                        t = true;
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                    }
                j--;
            }
        }
        
        internal static void BubbleSort(int[] array, ref int counterSwap, ref int counterСomparison)
        {
            bool t = true;
            int j = array.Length - 1;
            
            while (t)
            {
                t = false;
                for (int i = 0; i < j; i++)
                {
                    counterСomparison++;
                    if (array[i] > array[i + 1])
                    {
                        t = true;
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                        counterSwap++;
                    }
                }

                j--;
            }
        }
        
        internal static void SelectionSort(int[] array)
        {
            for (int i = array.Length - 1; i >= 0; i --)
            {
                int max = array[0];
                int k = 0;
                for (int j = 0; j < i; j++)
                {
                    if (max < array[j])
                    {
                        max = array[j];
                        k = j;
                    }
                }

                if (max > array[i])
                    (array[i], array[k]) = (array[k], array[i]);
            }
        }

        internal static void SelectionSort(int[] array, ref int counterSwap, ref int counterComparison)
        {
            for (int i = array.Length - 1; i >= 0; i --)
            {
                int max = array[0];
                int k = 0;
                for (int j = 0; j < i; j++)
                {
                    counterComparison++;
                    if (max < array[j])
                    {
                        max = array[j];
                        k = j;
                    }
                }

                counterComparison++;
                if (max > array[i])
                {
                    counterSwap++;
                    (array[i], array[k]) = (array[k], array[i]);
                }
            }
        }
        
        internal static void GnomeSort(int[] array)
        {
            int i = 1;
            int j = 1;
            while (i < array.Length)
            {
                if (array[i - 1] < array[i])
                {
                    i = j;
                    j++;
                }
                else
                {
                    (array[i], array[i - 1]) = (array[i - 1], array[i]);
                    i--;
                    
                    if (i == 0)
                    {
                        i = j;
                        j++;
                    }
                }
            }
        }
        
        internal static void GnomeSort(Game[] array)
        {
            int i = 1;
            int j = 1;
            while (i < array.Length)
            {
                if (array[i - 1].Rating < array[i].Rating)
                {
                    i = j;
                    j++;
                }
                else
                {
                    (array[i], array[i - 1]) = (array[i - 1], array[i]);
                    i--;
                    if (i == 0)
                    {
                        i = j;
                        j++;
                    }
                }
            }
        }
        internal static void GnomeSort(int[] array, ref int counterSwap, ref int counterComparison)
        {
            int i = 1;
            int j = 1;
            while (i < array.Length)
            {
                counterComparison++;
                if (array[i - 1] < array[i])
                {
                    i = j;
                    j++;
                }
                else
                {
                    counterSwap++;
                    (array[i], array[i - 1]) = (array[i - 1], array[i]);
                    i--;
                    if (i == 0)
                    {
                        i = j;
                        j++;
                    }
                }
            }
        }

        internal static void QuickSort(int[] array, int ilo, int ihi)
        {
            int lo = ilo;
            int hi = ihi;
            int mid = array[(ilo + ihi) / 2];

            do
            {
                while (array[lo] < mid) lo++;
                while (array[hi] > mid) hi--;

                if (lo > hi)
                {
                    break;
                }
                if (array[lo] > array[hi])
                    (array[lo], array[hi]) = (array[hi], array[lo]);

                lo++;
                hi--;

            } while (lo <= hi);

            if (lo < ihi)
                QuickSort(array, lo, ihi);
            if (ilo < hi)
                QuickSort(array, ilo, hi);
        }
        internal static void QuickSort(int[] array, int ilo, int ihi, ref int counterSwap, ref int counterComparison)
                {
                    int lo = ilo;
                    int hi = ihi;
                    int mid = array[(ilo + ihi) / 2];

                    do
                    {
                        while (array[lo] < mid) lo++;
                        while (array[hi] > mid) hi--;
                        
                        if (lo > hi)
                        {
                            break;
                        }

                        counterComparison++;
                        if (array[lo] > array[hi])
                        {
                            counterSwap++;
                            (array[lo], array[hi]) = (array[hi], array[lo]);
                        }

                        lo++;
                        hi--;
                        
                    } while (lo <= hi);

                    if (lo < ihi)
                        QuickSort(array, lo, ihi, ref counterSwap, ref counterComparison);
                    if (ilo < hi)
                        QuickSort(array, ilo, hi, ref counterSwap, ref counterComparison);
                }
    }
}