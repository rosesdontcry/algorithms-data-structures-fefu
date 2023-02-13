namespace Hashing;

public class Data
{
    public List<List<Game>> table = new List<List<Game>>();

    public Data(int size)
    {
        for (int i = 0; i < size; i++)
        {
            table.Add(new List<Game>());
        }
    }

    public void Print()
    {
        for (int i = 0; i < table.Count; i++)
            if (table[i].Count != 0)
            {
                int h = i;
                string tmp = "";
                for (int j = 0; j < table[h].Count; ++j)
                {
                    if (table[h][j].Id == i)
                    {
                        tmp += table[h][j].Key + " -> ";
                    }
                }
                Console.WriteLine(i + ". " + tmp);
            }
    }
}