using System.Collections;
using UnityEngine;

namespace RobbieWagnerGames.BrickBallGame
{
    public class Brick : MonoBehaviour
    {
        [SerializeField] private float brickPointMultiplier = 1;
        private Coroutine destroyCoroutine = null;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ball") && destroyCoroutine == null)
                destroyCoroutine = StartCoroutine(DelayDestroy());
        }

        private IEnumerator DelayDestroy()
        {
            OnBrickHit?.Invoke(this, brickPointMultiplier);
            yield return null;
            Destroy(gameObject);
        }
        public delegate void OnBrickHitDelegate(Brick brick, float pointMultiplier);
        public event OnBrickHitDelegate OnBrickHit;
    }
}