using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		HandleBlockCollision();
	}

	private void HandleBlockCollision()
	{
		Destroy(this.gameObject);
	}
}
