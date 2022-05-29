using SQLite;

namespace DartGame.Models
{
    [Table("Player")]
    public class Player
    {
        [PrimaryKey]
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }        
        public string PlayerScore => $"W: {GamesWon} - L: {GamesLost}";
        public double BestAvgScore { get; set; }
        public int HighestScore { get; set; }
        public int MinimumDartsUsed { get; set; }
    }
}
