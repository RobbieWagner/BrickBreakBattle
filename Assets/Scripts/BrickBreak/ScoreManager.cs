using System;
using UnityEngine;

namespace RobbieWagnerGames.BrickBallGame
{
    public class ScoreManager : MonoBehaviour
    {
        public bool isPlayer1Earning = true;

        public Action<int> OnPlayer1ScoreChanged = (int a) => { };
        public Action<int> OnPlayer2ScoreChanged = (int a) => { };

        private int player1Score;
        private int player2Score;
        public int Player1Score
        {
            get
            {
                return player1Score;
            }
            set
            {
                if(value == player1Score)
                    return;
                player1Score = value;
                OnPlayer1ScoreChanged?.Invoke(player1Score);
            }
        }
        public int Player2Score
        {
            get
            {
                return player2Score;
            }
            set
            {
                if (value == player2Score)
                    return;
                player2Score = value;
                OnPlayer2ScoreChanged?.Invoke(player2Score);
            }
        }

        public static ScoreManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;
        }

        public void BoostPlayerScore(int amount, bool isForPlayer1)
        {
            if (isForPlayer1)
                Player1Score += amount;
            else
                Player2Score += amount;
        }
    }
}