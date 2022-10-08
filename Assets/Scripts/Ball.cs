using UnityEngine;

public class Ball : MonoBehaviour
{
	// Initial position of the ball
	Vector3 initialPosition = new Vector3(0, -3, 0);
	// Initial velocity of the ball
	Vector2 initialVelocity = new Vector2(3f, 3f);
	// Minimum change in velocity upon collision
	const float collisionVelocityDeltaMin = 0f;
	// Maximum change in velocity upon collision
	const float collisionVelocityDeltaMax = 1f;

	// Whether the game has started
	bool gameBegan;
	// Whether the ball is the original or cloned
	public bool clone;

	Rigidbody2D ballRigidbody;

	// Start is called before the first frame update
	void Start()
	{
		ballRigidbody = GetComponent<Rigidbody2D>();

		if (clone)
		{
			ballRigidbody.velocity = initialVelocity;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (!clone)
		{
			if (!gameBegan)
			{
				// FIXME: This causes the ball to generate momentum for as long as the game has not started
				this.transform.position = initialPosition;
			}

			if (Input.GetKey(KeyCode.Space))
			{
				gameBegan = true;

				// FIXME: Advanced Ball Tech: Holding the start key will reset the ball to initial velocity
				// This feels like it could be turned in to a fun mechanic, but it doesn't seem intentional on the course maker's part...
				ballRigidbody.velocity = initialVelocity;
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Vector2 randomVelocity = new Vector2(
			Random.Range(collisionVelocityDeltaMin, collisionVelocityDeltaMax),
			Random.Range(collisionVelocityDeltaMin, collisionVelocityDeltaMax)
		);
		ballRigidbody.velocity += randomVelocity;
	}
}
