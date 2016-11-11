using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameMenu : MonoBehaviour {

    Animator anim;
    Button btn;

	// Use this for initialization
	IEnumerator Start () {
        anim = GetComponentInParent<Animator>();
        btn = GetComponent<Button>();

        yield return new WaitForSeconds(2f);
        btn.onClick.AddListener(TaskOnClick);
	}

    void TaskOnClick() {
        // load first level
        if (btn.name == "StartGame (1)") {
            // Debug.Log("Start Game");
            StartCoroutine(TransitionToGame());
        }

        // load instructions scene
        else if (btn.name == "Instructions (1)") {
            // Debug.Log("Instructions");
            StartCoroutine(TransitionToInstructions());
        }

        // close application
        else if (btn.name == "ExitGame (1)") {
            Debug.Log("Exit Game");
            // Application.Quit();
        }
    }

    IEnumerator TransitionToGame()
    {
        anim.SetTrigger("transitionScene");
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("Game_MainFlr");
    }

    IEnumerator TransitionToInstructions()
    {
        anim.SetTrigger("transitionScene");
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("Instructions");
    }
}
