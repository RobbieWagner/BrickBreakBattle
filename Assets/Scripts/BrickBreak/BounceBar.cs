using UnityEngine;

namespace RobbieWagnerGames.BrickBallGame
{
    public class BounceBar : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private Vector2 yBounds;
        [SerializeField] private float midBounceSize = .2f;
        [SerializeField] private float barSpeed = 3f;

        [HideInInspector] public Vector2 moveVector;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                // Set the ball velocity based on its distance at the time of impact
                Vector2 distanceVector = other.transform.position - transform.position;
                if (Mathf.Abs(distanceVector.y) > midBounceSize / 2)
                {
                    Rigidbody2D ballRB = other.gameObject.GetComponent<Rigidbody2D>();
                    float speed = ballRB.velocity.magnitude;
                    ballRB.velocity = distanceVector.normalized * speed;
                }
            }
        }

        private void Update()
        {
            if((moveVector.y > 0 && transform.position.y < yBounds.y) || (moveVector.y < 0 && transform.position.y > yBounds.x))
                rb2d.velocity = moveVector * barSpeed * Time.deltaTime;
            else
                rb2d.velocity = Vector2.zero;
        }
    }
}