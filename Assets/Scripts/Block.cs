using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	Restart restart;

	void Start()
	{
		restart = FindObjectOfType<Restart>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		HandleBlockCollision();
	}

	private void HandleBlockCollision()
	{
		Destroy(this.gameObject);
		restart.CheckIfAllBlocksDestroyed();
	}
}
