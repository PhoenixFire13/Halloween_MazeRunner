using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    Maze mazeInstance;
    Player playerInstance;

    public Maze mazePrefab;
	public Player playerPrefab;

    public static bool mazeGenerated = false;

	void Start () {
        StartCoroutine(BeginGame());
    }
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			RestartGame();
		}
	}

	IEnumerator BeginGame () {
		Camera.main.clearFlags = CameraClearFlags.Skybox;
		Camera.main.rect = new Rect(0f, 0f, 1f, 1f);

		mazeInstance = Instantiate(mazePrefab) as Maze;

        // Q: Why do we need a yield statement to start a new coroutine?
		yield return StartCoroutine(mazeInstance.Generate());

		playerInstance = Instantiate(playerPrefab) as Player;
        // instantiates player specifically at first cell
        playerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.InitialCoordinates));

        // Q: What does setting the "Clear Flags" property of the camera to "Depth" do?
		Camera.main.clearFlags = CameraClearFlags.Depth;
		Camera.main.rect = new Rect(0f, 0f, 0.5f, 0.5f);

        mazeGenerated = true;
	}

	void RestartGame () {
		StopAllCoroutines();
		Destroy(mazeInstance.gameObject);
		if (playerInstance != null) {
			Destroy(playerInstance.gameObject);
		}
		StartCoroutine(BeginGame());
	}
}