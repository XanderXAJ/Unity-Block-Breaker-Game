using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	// Whether the game has started
	bool gameBegan;
	// Initial position of the ball
	Vector3 initialPosition = new Vector3(0, -3, 0);
	// Initial velocity of the ball
	Vector2 initialVelocity = new Vector2(3f, 3f);

	Rigidbody2D ballRigidbody;

	// Start is called before the first frame update
	void Start()
	{
		ballRigidbody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
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
			ballRigidbody.velocity = new Vector2(3f, 3f);
		}
	}
}
