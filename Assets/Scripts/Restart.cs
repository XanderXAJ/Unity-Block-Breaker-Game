using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void CheckIfAllBlocksDestroyed()
	{
		GameObject[] blockObjects = GameObject.FindGameObjectsWithTag("Block");

		if (blockObjects.Length < 1)
		{
			RestartLevel();
		}
	}
}
