using TMPro;
using UnityEngine;

namespace RobbieWagnerGames.BrickBallGame
{
    public class ScoreUI : MonoBehaviour
    {
        public TextMeshProUGUI player1ScoreText;
        public TextMeshProUGUI player2ScoreText;

        private void Awake()
        {
            ScoreManager.Instance.OnPlayer1ScoreChanged += UpdatePlayer1ScoreText;
            ScoreManager.Instance.OnPlayer2ScoreChanged += UpdatePlayer2ScoreText;
        }

        private void UpdatePlayer1ScoreText(int score)
        {
            player1ScoreText.text = $"{score}";
        }

        private void UpdatePlayer2ScoreText(int score)
        {
            player2ScoreText.text = $"{score}";
        }
    }
}