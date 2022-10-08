using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	// Paddle movement in units per second
	const float paddleSpeed = 3f;
	// Paddle movement bounds
	const float paddleMinXPosition = -2.31f + (1f / 2);
	const float paddleMaxXPosition = 2.31f - (1f / 2);

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		float paddlePositionX = this.transform.position.x;

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			paddlePositionX -= paddleSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			paddlePositionX += paddleSpeed * Time.deltaTime;
		}

		paddlePositionX = Mathf.Clamp(paddlePositionX, paddleMinXPosition, paddleMaxXPosition);

		this.transform.position = new Vector3(
			paddlePositionX,
			this.transform.position.y,
			this.transform.position.z
		);
	}
}
