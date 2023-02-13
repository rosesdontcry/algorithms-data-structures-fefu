namespace DifferentSortings
{
    public struct Game
    {
        public string Name { get; set; }
        public string GameType { get; set; }
        public int Rating { get; set; }

        public Game(string name, string gameType, int rating)
        {
            Name = name;
            GameType = gameType;
            Rating = rating;
        }
    }
}