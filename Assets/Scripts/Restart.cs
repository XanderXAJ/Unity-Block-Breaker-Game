using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
	bool checkIfAllBlocksDestroyed;

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void CheckIfAllBlocksDestroyed()
	{
		// Check blocks on next update to give Unity the opportunity to destroy any blocks during this update
		// Note: Is this bullet-proof? What if Restart's Update() call happens during the same update as a Block's destroyed?
		checkIfAllBlocksDestroyed = true;
	}

	void Update()
	{
		if (checkIfAllBlocksDestroyed)
		{
			GameObject[] blockObjects = GameObject.FindGameObjectsWithTag("Block");

			if (blockObjects.Length < 1)
			{
				RestartLevel();
			}

			checkIfAllBlocksDestroyed = false;
		}
	}
}
