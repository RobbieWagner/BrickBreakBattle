using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobbieWagnerGames.BrickBallGame
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Brick brickPrefab;
        List<Brick> brickInstances = new List<Brick>();
        public int currentLevelPoints = 1;

        public static LevelManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;
        }

        public void StartNewLevel()
        {
            for (int i = 0; i < 5; i++)
            {
                Brick newBrick = Instantiate(brickPrefab);
                newBrick.transform.position = new Vector2(5 - i * 2, 0);
                newBrick.OnBrickHit += HandleBrickHit;
                brickInstances.Add(newBrick); 
            }
        }

        private void HandleBrickHit(Brick brick, float pointMultiplier)
        {
            brickInstances.Remove(brick);
            ScoreManager.Instance.BoostPlayerScore((int) (currentLevelPoints * pointMultiplier), ScoreManager.Instance.isPlayer1Earning);
        }
    }
}