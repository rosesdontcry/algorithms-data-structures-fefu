namespace Hashing;

public class Game
{
    public string Key { get; set; }
    public int Id { get; set; }
	public int Rating { get; set; }
    
    public Game(string key, int id)
    {
	    this.Key = key;
	    this.Id = id;
    }
}