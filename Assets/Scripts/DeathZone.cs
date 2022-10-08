using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
	Restart restart;

	void Start()
	{
		restart = FindObjectOfType<Restart>();
	}

	// Note: OnTriggerEnter2D requires one of the participants in the collision to have "Is Trigger" enabled.
	// Here, it's been enabled on the Death Zone.
	private void OnTriggerEnter2D(Collider2D trigger)
	{
		// Destroy destroys the object _after_ the current game update (but before rendering),
		// meaning that the destroyed ball will still exist when we search for its tag.
		Destroy(trigger.gameObject);

		GameObject[] ballObjects = GameObject.FindGameObjectsWithTag("Ball");
		// As noted above, since destroy doesn't remove the ball immediately but it's known one has been destroyed, take an extra one off.
		// FIXME: If multiple balls die in a single update loop, the game will softlock as we're only accounting for one ball dying per update.
		int ballsRemaining = ballObjects.Length - 1;
		Debug.Log("Ball lost. Balls remaining: " + ballsRemaining);

		if (ballsRemaining < 1)
		{
			restart.RestartLevel();
		}
	}
}
