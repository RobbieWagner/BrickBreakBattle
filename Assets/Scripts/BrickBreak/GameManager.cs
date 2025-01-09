using System;
using UnityEngine;

namespace RobbieWagnerGames.BrickBallGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Ball gameBallPrefab;
        [SerializeField] private float ballSpeed = 10f;
        [SerializeField] private BounceBar player1BounceBar;
        [SerializeField] private BounceBar player2BounceBar;

        private Ball currentBallInstance = null;

        private void Awake()
        {
            StartGame();
        }

        private void StartGame()
        {
            currentBallInstance = Instantiate(gameBallPrefab);
            currentBallInstance.transform.position = (Vector2) player1BounceBar.transform.position + Vector2.right * .5f;
            currentBallInstance.rb2d.velocity = new Vector2(.67f, .33f).normalized * ballSpeed;
        }
    }
}