using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBar : MonoBehaviour
{
    [SerializeField] private float midBounceSize = .2f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            // Set the ball velocity based on its distance at the time of impact
            Vector2 distanceVector = other.transform.position - transform.position;
            if(Mathf.Abs(distanceVector.x) > 0.2f/2)
            {
                Rigidbody2D ballRB = other.gameObject.GetComponent<Rigidbody2D>();
                ballRB.velocity = distanceVector * ballRB.velocity.magnitude;
            }
        }
    }
}
