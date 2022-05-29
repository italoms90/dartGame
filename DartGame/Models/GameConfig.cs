using SQLite;

namespace DartGame.Models
{
    [Table("GameConfig")]
    public class GameConfig
    {
        public GameConfig()
        {
            ApplyDefaultValues();
        }

        [PrimaryKey]
        public int GameConfigId { get; set; }
        public string PlayerOneName { get; set; }
        public string PlayerTwoName { get; set; }
        public string GameStartPoints { get; set; }
        public string GameLegs { get; set; }
        public int PlayerOneId { get; set; }
        public int PlayerTwoId { get; set; }
        public int P1LegsWon { get; set; }
        public int P2LegsWon { get; set; }   

        private void ApplyDefaultValues()
        {
            GameConfigId = 0;
            PlayerOneName = "";
            PlayerTwoName = "";
            GameStartPoints = "";
            GameLegs = "";
        }
    }
}
