namespace Hashing;

public abstract class Divisions
{
    private static int Function(string key, int m)
    {
        int k = 0;
        foreach (var c in key)
        {
            k += c;
        }
        int hash = ((k % 163) + 1) % m;
        return hash;
    }
    
    public static void Add(ref Data data, string key)
    {
        int h = Function(key, data.table.Count);
        data.table[h].Add(new Game(key , h));
    }

    public static int Search(ref Data data, string key)
    {
        int h = Function(key, data.table.Count());
        for (int i = 0; i < data.table[h].Count(); ++i)
        {
            if (data.table[h][i].Key == key)
            {
                return data.table[h][i].Id;
            }
        }
        return -1;
    }
    
    public static bool CanDelete(ref Data table, string key)
    {
        int h = Function(key, table.table.Count());
        for (int i = 0; i < table.table[h].Count(); ++i)
        {
            if (table.table[h][i].Key == key)
            {
                table.table[h].RemoveAt(i);
                return true;
            }
        }
        return false;
    }
}