using UnityEngine;
using System.Collections;

public class GameStatus : MonoBehaviour {

    Animator anim;

    public static bool gameWin = false;

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (GameManager.gameOver)
        {
            anim.SetTrigger("GameOver");
            this.enabled = false;
        }

        if (CollectObjects.keyCount == 2)
        {
            anim.SetTrigger("GameWin");
            gameWin = true;
            this.enabled = false;
        }
	}
}
